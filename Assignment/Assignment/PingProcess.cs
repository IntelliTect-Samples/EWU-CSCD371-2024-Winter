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
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder??=new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult( process.ExitCode, stringBuilder?.ToString());
    }

    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return Task.Run(() =>
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send(hostNameOrAddress);
                    return new PingResult(0, null);
                }
            }
            catch (Exception ex)
            {
                return new PingResult(1, ex.ToString());
            }
        });
    }


    public static async Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            using (var ping = new Ping())
            {
                PingReply? reply = null;
                var pingTask = Task.Run(() => reply = ping.Send(hostNameOrAddress), cancellationToken);

         
                await Task.WhenAny(pingTask, Task.Delay(Timeout.Infinite, cancellationToken));


                if (!pingTask.IsCompleted)
                {

                    throw new OperationCanceledException("The operation was canceled.", cancellationToken);
                }
                if (reply == null)
                {

                    throw new PingException("Ping operation failed.");
                }

                return new PingResult(0, null);
            }

           
        }
        catch (OperationCanceledException ex)
        {
            if (cancellationToken.IsCancellationRequested)
            {

                throw new TaskCanceledException("The operation was canceled.", ex);
            }
            else
            {

                throw;
            }
        }
        catch (Exception ex)
        {

            return new PingResult(1, ex.ToString());
        }
    }



    public async Task<PingResult> RunAsync(string hostNameOrAddress)
    {
        var process = new Process
        {
            StartInfo =
            {
                FileName = "ping",
                Arguments = hostNameOrAddress,
                RedirectStandardOutput = true
            }
        };

        process.Start();
        string output = await process.StandardOutput.ReadToEndAsync();
        process.WaitForExit();

        return new PingResult(process.ExitCode, output);
    }



    async public Task<PingResult> RunLongRunningAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        Task task = null!;
        await task;
        throw new NotImplementedException();
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
