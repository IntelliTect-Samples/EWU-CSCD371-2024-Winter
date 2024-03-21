using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using Assignment;


namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    PingProcess Sut { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        PingResult result = Sut.Run("google.com");
        Assert.AreEqual<int>(0, result.ExitCode);
    }


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, var stdOutput) = Sut.Run("badaddress");
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<string?>(
            "Ping request could not find host badaddress. Please check the name and try again.".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(1, exitCode);
    }

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        PingProcess pingProcess = new();
        string hostNameOrAddress = "localhost";


        var pingTask = PingProcess.RunTaskAsync(hostNameOrAddress);

        var result = pingTask.Result;
        Assert.IsNotNull(result.StdOutput);
        Assert.IsTrue(result.ExitCode == 0);
    }
    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {

        PingProcess pingProcess = new();
        string hostNameOrAddress = "localhost";


        var task = PingProcess.RunAsync(hostNameOrAddress);
        var res = task.Result;


        Assert.IsNotNull(res.StdOutput);
        AssertValidPingOutput(task.Result);
    }

    [TestMethod]

    async public Task RunAsync_UsingTpl_Success()
    {

        PingProcess pingProcess = new();
        string hostNameOrAddress = "localhost";


        var result = await PingProcess.RunAsync(hostNameOrAddress);


        Assert.IsNotNull(result.StdOutput);
        Assert.IsTrue(result.ExitCode == 0);
    }



    [TestMethod]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        PingProcess pingProcess = new();
        string hostNameOrAddress = "localhost";
        CancellationTokenSource cancellationTokenSource = new();

        var task = PingProcess.RunAsync(hostNameOrAddress, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        try
        {
            task.Wait();
            Assert.Fail("Expected an AggregateException to be thrown.");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerExceptions.Any(innerEx => innerEx is TaskCanceledException));
        }
    }

    [TestMethod]
    public async Task RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {

        PingProcess pingProcess = new();
        string hostNameOrAddress = "localhost";
        using CancellationTokenSource cancellationTokenSource = new();

        Task<PingResult> task = PingProcess.RunAsync(hostNameOrAddress, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        await Assert.ThrowsExceptionAsync<OperationCanceledException>(() => task);
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {

        var pingProcess = new PingProcess();
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };


        foreach (var hostName in hostNames)
        {
            PingResult result = await PingProcess.RunAsync(hostName);

            Assert.AreEqual(0, result.ExitCode);

            Assert.AreEqual("Success", result.StdOutput);
        }
    }

    [TestMethod]
    public void RunLongRunningAsync_Success()
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "ping",
            Arguments = "localhost -n 5",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        StringBuilder outputBuilder = new();
        StringBuilder errorBuilder = new();

        Action<string?> outputHandler = (output) => outputBuilder.AppendLine(output);
        Action<string?> errorHandler = (error) => errorBuilder.AppendLine(error);

        PingProcess ping = new();
        CancellationTokenSource tokenSource = new();

        var task = PingProcess.RunLongRunningAsync(startInfo, outputHandler, errorHandler, tokenSource.Token);

        var exitCode = task.Result;

        Assert.AreEqual(0, exitCode);
        Assert.IsFalse(string.IsNullOrEmpty(outputBuilder.ToString()));


    }



    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        StringBuilder stringBuilder = new();

        try
        {
            numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        }catch (AggregateException) { }
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count() + 1);
    }

    
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);

    private readonly string PingOutputLikeExpression = @"
Pinging * with 32 bytes of data:
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*

Ping statistics for ::1:
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *".Trim();
}
