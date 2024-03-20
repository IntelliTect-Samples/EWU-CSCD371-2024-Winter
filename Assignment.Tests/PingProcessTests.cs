using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
[DoNotParallelize]
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
        Process process = new();
        process.StartInfo.FileName = "ping";
        process.StartInfo.Arguments = "-c 4 localhost";
        process.Start();
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }


    [TestMethod]
    public void Run_LocalHost_Success()
    {
        int exitCode = Sut.Run("localhost").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }

    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput) = Sut.Run("badaddress");
        Assert.IsTrue(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<string?>(
            "ping: badaddress: Temporary failure in name resolution".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(2, exitCode); // 2 is the exit code for invalid address
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
        // Do NOT use async/await in this test.
         Task<PingResult> result = Sut.RunTaskAsync("localhost");
         AssertValidPingOutput(result.Result);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {

        // Do NOT use async/await in this test.
        PingResult result = Sut.RunAsync("localHost").Result;
        // Test Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        PingResult result = await Sut.RunAsync("localhost");

        // Test Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        CancellationTokenSource cancelSource = new();
        cancelSource.Cancel();
        Task<PingResult> task = Sut.RunAsync("localhost", cancelSource.Token);
        task.Wait();
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Use exception.Flatten()
        CancellationTokenSource cancelSource = new();
        cancelSource.Cancel();
        Task<PingResult> task = Sut.RunAsync("localhost", cancelSource.Token);
        try
        {
            task.Wait();
        }
        catch (AggregateException a)
        {
            if (a.Flatten().InnerException != null)
            {
                throw a.Flatten().InnerException!;
            }
            else
            {
                Console.WriteLine("No inner exception");
            }
        }
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        // Pseudo Code - don't trust it!!!
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);

        //placeholder test for valid ping format
        /*string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        PingResult result = await Sut.RunAsync(hostNames);
        AssertValidPingOutput(result);*/
    }


    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        ProcessStartInfo startInfo = new("ping", "localhost");

        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, default);

        Assert.AreEqual(0, exitCode);
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        Assert.ThrowsException<AggregateException>(() => numbers.AsParallel().ForAll(item => stringBuilder.AppendLine("")));
        /*int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count()+1);*/
    }

    /*    readonly string PingOutputLikeExpression = @"
    Pinging * with 32 bytes of data:
    Reply from ::1: time<*
    Reply from ::1: time<*
    Reply from ::1: time<*
    Reply from ::1: time<*

    Ping statistics for ::1:
        Packets: Sent = *, Received = *, Lost = 0 (0% loss),
    Approximate round trip times in milli-seconds:
        Minimum = *, Maximum = *, Average = *".Trim();*/
    readonly string PingOutputLikeExpression = @"
PING * * bytes*
64 bytes from * (*): icmp_seq=* ttl=* time=* ms
64 bytes from * (*): icmp_seq=* ttl=* time=* ms
64 bytes from * (*): icmp_seq=* ttl=* time=* ms
64 bytes from * (*): icmp_seq=* ttl=* time=* ms

--- * ping statistics ---
* packets transmitted, * received, *% packet loss, time *ms
rtt min/avg/max/mdev = */*/*/* ms
".Trim();
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression)??false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
