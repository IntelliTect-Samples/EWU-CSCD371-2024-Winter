using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {
        //StartInfo.Arguments = hostNameOrAddress;
        StartInfo.Arguments = $"-c 4 {hostNameOrAddress}";
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder??=new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult( process.ExitCode, stringBuilder?.ToString());
    }

    // bullet 1
    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return Task.Run(() => { return Run(hostNameOrAddress); });
    }

    // bullet 2
    async public Task<PingResult> RunAsync(string hostNameOrAddress)
    {       
        TaskCompletionSource<PingResult> tcs = new TaskCompletionSource<PingResult>();

       return await Task.Run(() =>
        {
            return Run(hostNameOrAddress);
        });
    }


    public async Task<PingResult> RunAsync(string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        try
        {

            cancellationToken.ThrowIfCancellationRequested();
            PingResult pr = await Task.Run<PingResult>(() => { return Run(hostNameOrAddress); }, cancellationToken);
            
            return pr;
        }
        catch (OperationCanceledException)
        {
            TaskCanceledException taskExc = new();
            AggregateException AggExc = new(innerExceptions: taskExc);
            throw AggExc;
        }

    }

    async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    {
        List<Task<PingResult>> tasks = new List<Task<PingResult>>();
        int total = 0;
        StringBuilder? builder = new StringBuilder();
        foreach(var host in hostNameOrAddresses)
        {
            tasks.Add(Task.Run(async () =>
            {
                PingResult res = await RunAsync(host, cancellationToken);
                if(res.StdOutput != null)
                {
                builder.AppendLine(res.StdOutput?.Trim());
                }
                total += res.ExitCode;
                return res;
            }));
        }

        await Task.WhenAll(tasks);
        int totalExitCode = tasks.Sum(task => task.Result.ExitCode);
        //int total = tasks.Sum(task => task.Result.ExitCode);

        return new PingResult(totalExitCode, builder.ToString().Trim());
    }

    //async public Task<PingResult> RunAsync(params string[] hostNameOrAddresses)
    //{
    //    StringBuilder? stringBuilder = new StringBuilder();
    //    ParallelQuery<Task<int>>? all = hostNameOrAddresses.AsParallel().Select(async item =>
    //    {
    //        Task<PingResult> task = RunAsync(item);
    //        stringBuilder.AppendLine(task.Result.StdOutput?.Trim());
    //        //await Task.WaitAll();
    //        return task.Result.ExitCode;
    //    });

    //    await Task.WhenAll(all);
    //    int total = all.Aggregate(0, (total, item) => total + item.Result);
    //    return new PingResult(total, stringBuilder?.ToString().Trim());
    //}

   
    public Task<int> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token)
    {
        //using updateprocessstartinfo
        ProcessStartInfo processStartInfo = UpdateProcessStartInfo(startInfo);
        //returning the exit code of the function
        return Task.Factory.StartNew(() =>
        {
            Process running =
                RunProcessInternal(processStartInfo, progressOutput, progressError, token);
            running.WaitForExit();
            return running.ExitCode;
        }, token, TaskCreationOptions.LongRunning, TaskScheduler.Current);

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