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
    bool IsUnix { get; set; }
    //Will never be null as its set in TestInitalize
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    string LimitPingArg { get; set; }
    string PingOutputLikeExpression { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [TestInitialize]
    public void TestInitialize()
    {
        IsUnix = Environment.OSVersion.Platform is PlatformID.Unix;
        (string arg, string exp) = IsUnix ? ("-c", PingOutputLikeExpressionUnix) : ("-n", PingOutputLikeExpressionWindows);
        LimitPingArg = arg;
        PingOutputLikeExpression = exp;
        Sut = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", $"{LimitPingArg} 4 localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }


    /*[TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }
    */

    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (string expectedOutput, int expectedExitCode) = IsUnix ? ("ping: badaddress: Temporary failure in name resolution", 2) : ("Ping request could not find host badaddress. Please check the name and try again.", 1);
        (int exitCode, string? stdOutput, string? stdError) = Sut.Run("badaddress");
        string actualOutput = IsUnix ? stdError! : stdOutput!;
        //In Unix, error is logged to StdError, not StdOutput
        Assert.IsFalse(string.IsNullOrWhiteSpace(actualOutput));
        actualOutput = WildcardPattern.NormalizeLineEndings(actualOutput!.Trim());
        Assert.AreEqual<string?>(expectedOutput, actualOutput, $"Output is unexpected: {stdOutput}");
        // 2 is the exit code for invalid address in Unix
        // 1 is the exit code for invalid address in Windows
        Assert.AreEqual<int>(expectedExitCode, exitCode);
    }
    

     [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod, TestCategory("RequiresAdmin")]
    public void RunTaskAsync_Success()
    {
        // Do NOT use async/await in this test.
        // Test Sut.RunTaskAsync("localhost");
        Task<PingResult> task = Sut.RunTaskAsync("localhost");
        task.Start();
        AssertValidPingOutput(task.Result);
    }

    //1
    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
       // PingResult result = default;
        // Test Sut.RunAsync("localhost");
        Task<PingResult> task = Sut.RunAsync("localhost");
        AssertValidPingOutput(task.Result);
    }

    //2
    [TestMethod]
//#pragma warning disable CS1998 // Remove this
    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        // PingResult result = default;
        // Test Sut.RunAsync("localhost");
        PingResult result = await Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }
//#pragma warning restore CS1998 // Remove this

     

    //3
    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        CancellationTokenSource cancellationTokenSource = new();
        Task<PingResult> task = Task.Run(() => Sut.RunAsync("localhost", cancellationTokenSource.Token));
        cancellationTokenSource.Cancel();
        task.Wait();
    }

    //3
    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Use exception.Flatten()
        CancellationTokenSource cancellationTokenSource = new();
        cancellationTokenSource.Cancel();
        Task<PingResult> task = Sut.RunAsync("localhost", cancellationTokenSource.Token);
        try
        {
            task.Wait();
        } catch (AggregateException aggregateException)
        {
            aggregateException = aggregateException.Flatten();

            if(aggregateException != null)
            {
                throw aggregateException.InnerException!;
            }
            throw;
        }
    }

    /* commented out due to we have another test
    [TestMethod]
//#pragma warning disable CS1998 // Remove this
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        PingResult result = default;
        // Test Sut.RunLongRunningAsync("localhost");
        AssertValidPingOutput(result);
    }
//#pragma warning restore CS1998 // Remove this
    */

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        try
        {
            IEnumerable<int> range = Enumerable.Range(0, short.MaxValue);
            StringBuilder stringBuilder = new();
            range.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
            int count = stringBuilder.ToString().Split(Environment.NewLine).Length;
            Assert.AreNotEqual(count, range.Count() + 1);
        } catch (AggregateException)
        {

        }
    }



    // Create a test for RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    [TestMethod]
    public async Task RunAsync_MultipleHostAddresses_True()
    {
        string[] hostNames = { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = 10 * hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual<int?>(expectedLineCount, lineCount);
    }




    // Create a test for public Task<int> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token)
    [TestMethod]
    public void RunLongRunningAsync_ProcessStartInfo_Success()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "ping",
            Arguments = "localhost",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            ErrorDialog = false,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8,
            WorkingDirectory = Environment.CurrentDirectory,
            ErrorDialogParentHandle = IntPtr.Zero,
            Verb = "runas",
            UserName = Environment.UserName
        };
    }

    // Windows version of ping output
    readonly string PingOutputLikeExpressionWindows = @"
Pinging * with 32 bytes of data:
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Ping statistics for ::1:
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *".Trim();

    //Linux version of ping output
    readonly string PingOutputLikeExpressionUnix = @"
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
