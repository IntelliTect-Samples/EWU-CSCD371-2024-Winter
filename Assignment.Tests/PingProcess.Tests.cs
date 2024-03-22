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
        Process process = Process.Start("ping", "-c 4 localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        if (Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true")
        {
            Console.WriteLine("Skipping test in GitHub Actions environment.");
            return;
        }

        PingResult result = Sut.Run("google.com");
        AssertValidPingOutput(result);
    }


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, var stdOutput) = Sut.Run("badaddress");
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<int>(2, exitCode);
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
        string hostNameOrAddress = "localhost";
        var result = PingProcess.RunTaskAsync(hostNameOrAddress);
        AssertValidPingOutput(result);

    }
    [TestMethod]
    public async Task RunAsync_UsingTaskReturn_Success()
    {
        string hostNameOrAddress = "localhost";
        var result = await PingProcess.RunAsync(hostNameOrAddress);
        AssertValidPingOutput(result);


    }

    [TestMethod]

    async public Task RunAsync_UsingTpl_Success()
    {
        string hostNameOrAddress = "localhost";


        var result = await PingProcess.RunAsync(hostNameOrAddress);

        AssertValidPingOutput(result);

    }



    [TestMethod]

    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        PingProcess pingProcess = new PingProcess();
        string hostNameOrAddress = "localhost";
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        var task = PingProcess.RunAsync(hostNameOrAddress, cancellationTokenSource.Token);

        try
        {
            task.Wait();
            Assert.Fail("Expected a TaskCanceledException to be thrown.");
        }
        catch (AggregateException ex)
        {
            throw ex.Flatten().InnerException!;
        }
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        PingProcess pingProcess = new PingProcess();
        string hostNameOrAddress = "localhost";
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        var task = PingProcess.RunAsync(hostNameOrAddress, cancellationTokenSource.Token);

        task.Wait();

    }


   /* [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;
        PingResult result = await PingProcess.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);
    }*/

    [TestMethod]
    public void RunLongRunningAsync_Success()
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "ping",
            Arguments = "localhost -c 4",
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


    }



    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        StringBuilder stringBuilder = new();

        try
        {
            numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        }
        catch (AggregateException) { }
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count() + 1);
    }

    string PingOutputLikeExpression = @"
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
        PingOutputLikeExpression = WildcardPattern.NormalizeLineEndings(PingOutputLikeExpression);
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression.Trim()) ?? false,
         $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);


}