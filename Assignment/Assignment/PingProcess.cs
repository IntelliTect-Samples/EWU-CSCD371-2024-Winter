using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new ProcessStartInfo
    {
        FileName = "ping",
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    public PingResult Run(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        var process = Process.Start(StartInfo);
        var output = process?.StandardOutput.ReadToEnd();
        process?.WaitForExit();
        return new PingResult(process?.ExitCode ?? 1, output);
    }

    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        var tcs = new TaskCompletionSource<PingResult>();
        Ping pingSender = new();

        pingSender.PingCompleted += (obj, eventArgs) =>
        {
            if (eventArgs.Error != null)
            {
                tcs.SetException(eventArgs.Error);
            }
            else if (eventArgs.Cancelled)
            {
                tcs.SetCanceled();
            }
            else if(eventArgs.Reply != null)
            {
                tcs.SetResult(new PingResult(0, eventArgs.Reply.ToString()));
            }
        };

        pingSender.SendAsync(hostNameOrAddress, new object());
        return tcs.Task;
    }


    public async Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        using Ping ping = new();
        var reply = await ping.SendPingAsync(hostNameOrAddress);
        cancellationToken.ThrowIfCancellationRequested();
        return new PingResult(reply.Status == IPStatus.Success ? 0 : 1, reply.Status.ToString());

    }



    public async Task<PingResult[]> RunAsync(IEnumerable<string> hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        var tasks = hostNameOrAddress.Select(hostName => RunAsync(hostName, cancellationToken));
        return await Task.WhenAll(tasks);
    }



    public static async Task<PingResult[]> RunLongRunningAsync( 
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        List<PingResult> pingResults = new();

        using Ping ping = new();
        bool keepRunning = true;

        cancellationToken.Register(() => keepRunning = false);

        while (keepRunning)
        {
            var reply = await ping.SendPingAsync(hostNameOrAddress);
            pingResults.Add(new PingResult(reply.Status == IPStatus.Success ? 0 : 1, reply.Status.ToString()));

            await Task.Delay(1000, cancellationToken);
            }
        return pingResults.ToArray();

    }

    private static Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        Process process = new Process { StartInfo = UpdateProcessStartInfo(startInfo) };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private static Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += (sender, e) => progressOutput?.Invoke(e.Data);
        process.ErrorDataReceived += (sender, e) => progressError?.Invoke(e.Data);

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(() =>
            {
                if(!process.HasExited)
                {
                    process.Kill();
                }
            });


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }



            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        return process;
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.CreateNoWindow = true;
        return startInfo;
    }
}
