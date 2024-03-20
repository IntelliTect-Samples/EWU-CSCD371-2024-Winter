using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment;
using System.Xml.Linq;

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

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("-c 8 google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput) = Sut.Run("-c 4 badaddress");
        //Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<string?>(
            "Ping request could not find host badaddress. Please check the name and try again.".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(2, exitCode);
    }

    //[TestMethod]
    //public void Run_CaptureStdOutput_Success()
    //{
    //    PingResult result = Sut.Run("-c 4 localhost");
    //    AssertValidPingOutput(result);
    //}

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        // Arrange
        string hostName = "-c 4 localhost";
        // Act
        Task<PingResult> task = Sut.RunTaskAsync($"-c 4 {hostName}");
        PingResult pingResult = task.Result;
        // Assert
        //Asserting that we got something back from the ping
        Assert.IsNotNull(pingResult);
        //Asserting we have a successful exit code (0)
        Assert.IsTrue(pingResult.ExitCode == 0);


    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Arrange
        string hostName = "-c 4 localhost";
        Task<PingResult> task = Sut.RunAsync($"-c 4 {hostName}");

        // Act
        PingResult pingResult = task.Result;

        // Assert
        // Asserting that we got something back from the ping
        Assert.IsNotNull(pingResult);
        // Asserting we have a successful exit code (0)
        Assert.AreEqual(0, pingResult.ExitCode);

    }

    /*[TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        PingResult result = default;
        // Test Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }*/


    [TestMethod]
    public async Task RunAsync_UsingTpl_Success()
    {
        // Arrange
        string hostName = "-c 4 localhost";

        // Act
        PingResult result = await Sut.RunAsync($"-c 4 {hostName}");

        // Assert
        // Asserting that we got something back from the ping
        Assert.IsNotNull(result);
        // Asserting we have a successful exit code (0)
        Assert.AreEqual(0, result.ExitCode);
        AssertValidPingOutput(result);

    }


    //[TestMethod]
    //public void RunLongRunningAsync_Ping_Succcess()
    //{
    //    ProcessStartInfo info = new ProcessStartInfo("-c -4 localhost");
    //    PingResult result =  Sut.RunLongRunningAsync(info, default, default, default);
    //    AssertValidPingOutput(result);
    //}



    /*[TestMethod]
#pragma warning disable CS1998 // Remove this
    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        PingResult result = default;

        // Test Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }*/
#pragma warning restore CS1998 // Remove this


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
        CancellationToken cancellationToken = CancellationToken.None; // Or use CancellationTokenSource to cancel
        Action<string?> progressOutput = null!; // Define progressOutput if needed
        Action<string?> progressError = null!; // Define progressError if needed

        // Act
        Task<int> task = Sut.RunLongRunningAsync(startInfo, progressOutput, progressError, cancellationToken);
        int exitCode = await task;

        // Assert
        Assert.AreEqual(0, exitCode); // Assert the expected exit code
    }





    /*[TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);
    }


    [TestMethod]
    async public Task RunAsync_MultipleHostAddressesWCancelImplemented_True()
    {
        CancellationTokenSource source = new();
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames, source.Token);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);
    }*/


    [TestMethod]
    public async Task RunLongRunningAsync_UsingTpl_Success()
    {
        // Arrange
        ProcessStartInfo startInfo = new ProcessStartInfo("ping", "-c 4 localhost");
        CancellationToken cancellationToken = CancellationToken.None; // Or use CancellationTokenSource to cancel

        // Act
        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, cancellationToken);

        // Assert
        Assert.AreEqual(0, exitCode); // Assert the expected exit code
    }


    /*[TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count() + 1);
    }*/

    readonly string PingOutputLikeExpression = @"
Pinging * with 32 bytes of data:
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*

Ping statistics for ::1:
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *".Trim();
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
}
