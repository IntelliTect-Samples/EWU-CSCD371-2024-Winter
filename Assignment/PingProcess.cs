using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        string pingArg = Environment.OSVersion.Platform is PlatformID.Unix ? "-c" : "-n";

        StartInfo.Arguments = $"{pingArg} 4 {hostNameOrAddress}";
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult(process.ExitCode, stringBuilder?.ToString());

    }

    public static PingResult RunTaskAsync(string hostNameOrAddress)
    {
        PingProcess pingProcess = new PingProcess();
        return pingProcess.Run(hostNameOrAddress);
    }

    public static async Task<PingResult> RunAsync(
    string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        PingProcess ping = new();
        Task<PingResult> task = Task.Run(() => ping.Run(hostNameOrAddress), cancellationToken);
        return await task;
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

    private static Process RunProcessInternal(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token)
    {
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
