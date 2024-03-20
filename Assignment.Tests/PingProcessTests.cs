using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
        Process process = Process.Start("ping", "-c 4 localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }
    /*
    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("-c 4 www.google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }
    */  
    //For some reason this test constinously runs even with linux values

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
        PingResult result = Sut.Run("-c 4 localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()// 1.)
    {
        Task<PingResult> testOutput = Sut.RunTaskAsync("-c 4 localhost");
        testOutput.Start();//Need to schedule so it can complete
        AssertValidPingOutput(testOutput.Result);

    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()// 2.)
    {
        Task<PingResult> testOutput = Sut.RunAsync("-c 4 localhost");
        PingResult result = testOutput.Result;
        AssertValidPingOutput(result);
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()// 2.)
    {
        PingResult result = await Sut.RunAsync("-c 4 localhost");
        AssertValidPingOutput(result);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()// 3.)
    {
      //Arrange
      var cancellationTokenSource = new CancellationTokenSource();
      cancellationTokenSource.Cancel();

      // Act
      Sut.RunAsync("-c 4 localhost", cancellationTokenSource.Token).Wait();
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()// 3.)
    {
      // Arrange
      var cancellationTokenSource = new CancellationTokenSource();
      cancellationTokenSource.Cancel();

      // Act
      try
      {
        Sut.RunAsync("-c 4 localhost", cancellationTokenSource.Token).Wait();
      }
      catch (AggregateException ex)
      {
        Exception? flattenedException = ex.Flatten().InnerException;

        Assert.IsInstanceOfType(flattenedException, typeof(TaskCanceledException));

        throw flattenedException!;
      }
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()// 4.)
    {
        // Pseudo Code - don't trust it!!! <-- I'm trustin it!
        string[] hostNames = ["-c 4 localhost", "-c 4 localhost", "-c 4 localhost", "-c 4 localhost"];
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);
        //Assert.AreEqual("", result.StdOutput);
    }

    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()// 5.)
    {
        var startInfo = new ProcessStartInfo("ping", "-c 4 localhost");
        
        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, default);
        
        Assert.AreEqual(0, exitCode);
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count()+1);
    }

    readonly string PingOutputLikeExpression = @"
PING * 56 data bytes
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms

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
