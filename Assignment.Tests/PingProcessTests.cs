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
    //[TestMethod]
    //public void TEMPHOLDER()
    //{
    //    Assert.AreNotEqual("CAT", "MEOW");
    //}
    //[TestMethod]
    //public void TEMPHOLDER2()
    //{
    //    Assert.AreEqual("CAT", "CAT");
    //}
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

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {

        int exitCode = Environment.GetEnvironmentVariable("GITHUB_ACTIONS") is null ? 0 : 1;

        int realExit = Sut.Run("-c 4 google.com").ExitCode;
        Assert.AreEqual<int>(exitCode, realExit);
    }

    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput) = Sut.Run("badaddress");
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<string?>(
            "ping: badaddress: Temporary failure in name resolution".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(2, exitCode);
    }

    //[TestMethod]
    //public void Run_CaptureStdOutput_Success()
    //{
    //    PingResult result = Sut.Run("localhost");
    //    AssertValidPingOutput(result);
    //}

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        // Do NOT use async/await in this test.
        // Test Sut.RunTaskAsync("localhost");
        var pingProcess = new PingProcess();
        var result = pingProcess.RunTaskAsync("localhost -c 4").Result;

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        var pingProcess = new PingProcess();
        var result = pingProcess.RunAsync("localhost -c 4").Result;

        Assert.IsNotNull(result);
    }

    [TestMethod]

    async public Task RunAsync_UsingTpl_Success()
    {
        var pingProcess = new PingProcess();
        var result = await pingProcess.RunAsync("localhost -c 4");

        Assert.IsNotNull(result);
    }



    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public async Task RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        string hostName = "-c 4 localhost";
        CancellationTokenSource token = new CancellationTokenSource();
        token.Cancel();
        await Sut.RunAsync(hostName, token.Token);
    }

    [TestMethod]
    public async Task RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Arrange
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        string hostName = "-c 4 localhost";
        // Act & Assert
        try
        {
            await Sut.RunAsync(hostName, cancellationTokenSource.Token);
        }
        catch (AggregateException ex)
        {
            ex = ex.Flatten();
            if (ex.InnerExceptions != null)
            {
                foreach (var innerEx in ex.InnerExceptions)
                {
                    if (innerEx is TaskCanceledException)
                    {
                        // Expected exception found, test passes
                        return;
                    }
                }
            }

            // If no TaskCanceledException found, rethrow the exception
            throw;
        }

        // If no exception thrown, fail the test
        Assert.Fail("Expected TaskCanceledException was not thrown.");
    }

    [TestMethod]
    public async Task RunLongRunningAsync_Success()
    {
        // Arrange
        ProcessStartInfo startInfo = new ProcessStartInfo("ping", "-c 4 localhost");
        CancellationToken cancellationToken = CancellationToken.None; 
        Action<string?> progressOutput = null!; 
        Action<string?> progressError = null!; 

        
        Task<int> task = Sut.RunLongRunningAsync(startInfo, progressOutput, progressError, cancellationToken);
        int exitCode = await task;

        
        Assert.AreEqual(0, exitCode); 
    }
    [TestMethod]
    public async Task RunLongRunningAsync_UsingTpl_Success()
    {
        // Arrange
        ProcessStartInfo startInfo = new ProcessStartInfo("ping", "-c 4 localhost");
        CancellationToken cancellationToken = CancellationToken.None; 

        // Act
        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, cancellationToken);

        // Assert
        Assert.AreEqual(0, exitCode); 
    }

    //[TestMethod]
    //async public Task RunAsync_MultipleHostAddresses_True()
    //{
    //    // Pseudo Code - don't trust it!!!
    //    string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
    //    int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;
    //    PingResult result = await Sut.RunAsync(hostNames);
    //    int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
    //    Assert.AreEqual(expectedLineCount, lineCount);
    //}

    //[TestMethod]
    //async public Task RunLongRunningAsync_UsingTpl_Success()
    //{
    //    PingResult result = await PingProcess.RunLongRunningAsync("localhost");
    //    AssertValidPingOutput(result);
    //}





    //[TestMethod]
    //public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    //{
    //    IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
    //    System.Text.StringBuilder stringBuilder = new();
    //    numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
    //    int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
    //    Assert.AreNotEqual(lineCount, numbers.Count() + 1);
    //}

    //readonly string PingOutputLikeExpression = @"
    //Pinging * with 32 bytes of data:
    //Reply from ::1: time<*
    //Reply from ::1: time<*
    //Reply from ::1: time<*
    //Reply from ::1: time<*

    //Ping statistics for ::1:
    //    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
    //Approximate round trip times in milli-seconds:
    //    Minimum = *, Maximum = *, Average = *".Trim();
    //private void AssertValidPingOutput(int exitCode, string? stdOutput)
    //{
    //    Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
    //    stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
    //    Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false,
    //        $"Output is unexpected: {stdOutput}");
    //    Assert.AreEqual<int>(0, exitCode);
    //}
    //private void AssertValidPingOutput(PingResult result) =>
    //    AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
