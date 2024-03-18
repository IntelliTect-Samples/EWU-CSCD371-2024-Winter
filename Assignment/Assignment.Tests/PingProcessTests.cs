using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        (int exitCode, string? stdOutput) = Sut.Run("badaddress");
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


        var pingTask = pingProcess.RunTaskAsync(hostNameOrAddress);



        var result = pingTask.Result;
        Assert.IsNotNull(result.StdOutput);
        Assert.IsTrue(result.ExitCode == 0);
    }

    [TestMethod]
    public async void RunAsync_UsingTaskReturn_Success()
    {

        PingProcess pingProcess = new();
        string hostNameOrAddress = "localhost";


        var res = await pingProcess.RunAsync(hostNameOrAddress);


        Assert.IsNotNull(res.StdOutput);
        Assert.IsTrue(res.ExitCode == 0);
    }

    [TestMethod]

    async public Task RunAsync_UsingTpl_Success()
    {

        PingProcess pingProcess = new();
        string hostNameOrAddress = "localhost";


        var result = await pingProcess.RunAsync(hostNameOrAddress);


        Assert.IsNotNull(result.StdOutput);
        Assert.IsTrue(result.ExitCode == 0);
    }



    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public async void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        var pingProcess = new PingProcess();
        var hostNameOrAddress = "localhost";
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;

        try
        {
            // Act
            var task = pingProcess.RunAsync(hostNameOrAddress, cancellationToken);

            // Cancel the task immediately
            cancellationTokenSource.Cancel();

            // Await the completion of the task
            await task;

            // If the task completes successfully, fail the test
            Assert.Fail("Task should have been cancelled, but it completed successfully.");
        }
        catch (AggregateException ex)
        {
            // Assert that the AggregateException contains a TaskCanceledException
            Assert.IsTrue(ex.InnerException is TaskCanceledException);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public async void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {

        // Arrange
        var pingProcess = new PingProcess();
        var hostNameOrAddress = "localhost";
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;

        try
        {
            // Act
            var task = pingProcess.RunAsync(hostNameOrAddress, cancellationToken);

            // Cancel the task immediately
            cancellationTokenSource.Cancel();

            // Await the completion of the task
            await task;

            // If the task completes successfully, fail the test
            Assert.Fail("Task should have been cancelled, but it completed successfully.");
        }
        catch (AggregateException ex)
        {
            // Assert that the AggregateException contains only a TaskCanceledException
            Assert.AreEqual(1, ex.InnerExceptions.Count);
            Assert.IsTrue(ex.InnerException is TaskCanceledException);

        }
    }

    [TestMethod]
    public async Task RunAsync_MultipleHostAddresses_True()
    {

        var pingProcess = new PingProcess();
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };


        foreach (var hostName in hostNames)
        {
            PingResult result = await pingProcess.RunAsync(hostName);

            Assert.AreEqual(0, result.ExitCode);

            Assert.AreEqual(null, result.StdOutput);
        }
    }

    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        var results = await PingProcess.RunLongRunningAsync("localhost", default);
        Assert.IsNotNull(results);
        Assert.IsTrue(results.Length > 0);
        foreach (var result in results)
        {
            AssertValidPingOutput(result);
        }
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
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
