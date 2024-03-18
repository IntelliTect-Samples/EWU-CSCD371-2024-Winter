using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        UseShellExecute = true,
        CreateNoWindow = true
    };

    public PingResult Run(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult(process.ExitCode, stringBuilder?.ToString());
    }

    public static Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return Task.Run(() =>
        {
            try
            {
                using Ping ping = new();
                var reply = ping.Send(hostNameOrAddress);
                var success = reply.Status == IPStatus.Success;
                return new PingResult(success ? 0 : 1, reply.Status.ToString());
            }
            catch (Exception ex)
            {
                return new PingResult(1, ex.Message);
            }
        });
    }


    public async Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        using Ping ping = new Ping();
        var reply = await ping.SendPingAsync(hostNameOrAddress);
        cancellationToken.ThrowIfCancellationRequested();
        if (reply.Status == IPStatus.Success)
        {
            reply = null;
        }
        return new PingResult(reply == null ? 0 : 1, reply?.Status.ToString());

    }



    public async Task<PingResult[]> RunAsync(IEnumerable<string> hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        List<Task<PingResult>> tasks = new();
        foreach (var hostName in hostNameOrAddress)
        {
            tasks.Add(RunAsync(hostName, cancellationToken));
        }
        return await Task.WhenAll(tasks);
    }



    public static async Task<PingResult[]> RunLongRunningAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        var pingResults = new List<PingResult>();

        using Ping ping = new();
        bool keepRunning = true;

        cancellationToken.Register(() => keepRunning = false);

        while (keepRunning)
        {
            try
            {
                var reply = await ping.SendPingAsync(hostNameOrAddress);
                pingResults.Add(new PingResult(reply.Status == IPStatus.Success ? 0 : 1, reply.Status.ToString()));

                await Task.Delay(1000, cancellationToken);
            }
            catch (PingException e)
            {
                pingResults.Add(new PingResult(1, e.Message));
            }
            catch (TaskCanceledException)
            {
                break;
            }
        }
        return pingResults.ToArray();

    }

    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


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
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}
