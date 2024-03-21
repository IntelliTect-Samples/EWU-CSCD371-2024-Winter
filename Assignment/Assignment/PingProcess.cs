using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
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

    public static Task<PingResult> RunTaskAsync(string hostNameOrAddress)
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


    public static async Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        using Ping ping = new();
        var reply = await ping.SendPingAsync(hostNameOrAddress);
        cancellationToken.ThrowIfCancellationRequested();
        return new PingResult(reply.Status == IPStatus.Success ? 0 : 1, reply.Status.ToString());

    }



    public static async Task<PingResult[]> RunAsync(IEnumerable<string> hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        return await Task.WhenAll(hostNameOrAddress.Select(hostName => RunAsync(hostName, cancellationToken)));
    }



    public static Task<int> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token)
    {
        return Task.Factory.StartNew(() =>
        {
            var process = RunProcessInternal(startInfo, progressOutput, progressError, token);
            process.WaitForExit();
            return process.ExitCode;
        }, token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
    }

    private static Process RunProcessInternal(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token) {
        var process = new Process { StartInfo = startInfo };
        process.Start();

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        process.OutputDataReceived += (sender, e) => progressOutput?.Invoke(e.Data);
        process.ErrorDataReceived += (sender, e) => progressError?.Invoke(e.Data);

        token.Register(() =>
        {
            if (!process.HasExited)
            {
                process.Kill();
            }
        });
        return process;
    }
}
