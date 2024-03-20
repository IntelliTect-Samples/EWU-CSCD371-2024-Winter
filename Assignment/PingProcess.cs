using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput, string? StdError);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stdOutStringBuilder = null;
        StringBuilder? stdErrorStringBuilder = null;
        void updateStdOutput(string? line) =>
            (stdOutStringBuilder??=new StringBuilder()).AppendLine(line);
        void updateStdError(string? line) => 
            (stdErrorStringBuilder??=new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, updateStdError, default);
        return new PingResult( process.ExitCode, stdOutStringBuilder?.ToString(), stdErrorStringBuilder?.ToString());
    }

    // 1.)
    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return new Task<PingResult>(() => Run(hostNameOrAddress));
    }

    // 2.) and 3?
    async public Task<PingResult> RunAsync(string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
      cancellationToken.ThrowIfCancellationRequested();

      try
      {
        PingResult result = await Task<PingResult>.Run(() => Run(hostNameOrAddress));
          
        return result;
      }
      catch (OperationCanceledException ex)
      {   
          throw new TaskCanceledException("Operation was canceled", ex);
      }
      catch (AggregateException)
      {
        throw;
      }
    }

    // 4.)
    async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    {
        StringBuilder? stringBuilder = new();
        int total = 0;
        ParallelQuery<Task<int>>? all = hostNameOrAddresses.AsParallel().Select(async item =>
        {

            Task<PingResult> task = RunAsync(item);
            lock (stringBuilder)
            {
                stringBuilder.AppendLine(task.Result.StdOutput?.Trim());
                ++total;
            }

            await task.WaitAsync(cancellationToken);
            return task.Result.ExitCode;
        });

        await Task.WhenAll(all);
        //int total = all.Aggregate(0, (total, item) => total + item.Result);
        return new PingResult(total, stringBuilder?.ToString().Trim(), null);
    }

    // 5.)
    async public Task<int> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token)
    {
      var task = Task.Factory.StartNew(() =>
      {
        Process process = RunProcessInternal(startInfo, progressOutput, progressError, token);
        return process.ExitCode;
      }, token, TaskCreationOptions.LongRunning, TaskScheduler.Current);

      int exitCode = await task;

      return exitCode;
    }

/*
    async public Task<PingResult> RunLongRunningAsync(string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        //NOTE: This method does NOT use Task.Ru      
        Task<PingResult> task = Task.Factory.StartNew<PingResult>(() =>
        {
          var process = RunAsync(hostNameOrAddress, cancellationToken).Result;
        }, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Current);

        return await task;
    }

  */

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
