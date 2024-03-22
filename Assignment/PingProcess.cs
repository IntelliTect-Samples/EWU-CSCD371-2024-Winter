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
        process?.WaitForExit();

        if (process != null && process.ExitCode == 0)
        {
            return new PingResult(0, null); 
        }
        else
        {
            string errorMessage = process != null ? process.StandardOutput.ReadToEnd() : "Process failed to execute.";
            return new PingResult(1, errorMessage); 
        }
    }

    public static PingResult RunTaskAsync(string hostNameOrAddress)
    {
        PingProcess pingProcess = new PingProcess();
        return pingProcess.Run(hostNameOrAddress);
    }

    public static async Task<PingResult> RunAsync(
    string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        using (Ping ping = new Ping())
        {
            try
            {
                var reply = await ping.SendPingAsync(hostNameOrAddress);
                if (reply.Status == IPStatus.Success)
                {
                    return new PingResult(0, null);
                }
                else
                {
                    return new PingResult(1, $"Ping failed with status: {reply.Status}");
                }
            }
            catch (PingException ex)
            {
                return new PingResult(1, $"Ping failed: {ex.Message}");
            }
        }
    }



    public static async Task<PingResult[]> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    {
        var tasks = hostNameOrAddresses.Select(async hostName =>
        {
            return await PingProcess.RunAsync(hostName, cancellationToken);
        });

        return await Task.WhenAll(tasks);
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
        //process.EnableRaisingEvents = true;
        //process.OutputDataReceived += OutputHandler;
        //process.ErrorDataReceived += ErrorHandler;
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
