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
        //if result is null, assign zero to exit code otherwise assign one 
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

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("-n 4 localhost");
        AssertValidPingOutput(result);
    }

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


    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        PingResult res = await Sut.RunAsync("-c 4 localhost");
        
        AssertValidPingOutput(res);
    }


    //[TestMethod]
    //public void RunLongRunningAsync_Ping_Succcess()
    //{
    //    ProcessStartInfo info = new ProcessStartInfo("-c -4 localhost");
    //    PingResult result =  Sut.RunLongRunningAsync(info, default, default, default);
    //    AssertValidPingOutput(result);
    //}


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
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
