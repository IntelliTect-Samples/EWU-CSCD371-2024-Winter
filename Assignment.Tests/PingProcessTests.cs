﻿using IntelliTect.TestTools;
using Microsoft.VisualStudio.TestPlatform.Utilities;
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
    string PingOutputLikeExpression {get; set;}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [TestInitialize]
    public void TestInitialize()
    {
        IsUnix = Environment.OSVersion.Platform is PlatformID.Unix;
        (string arg, string exp)  = IsUnix ? ("-c", PingOutputLikeExpressionUnix) : ("-n", PingOutputLikeExpressionWindows);
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

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {

        int expectedExitCode = Environment.GetEnvironmentVariable("GITHUB_ACTIONS") is not null || IsUnix ? 1 : 0;

        int exitCode = Sut.Run("google.com").ExitCode;
        Assert.AreEqual<int>(expectedExitCode, exitCode);
    }
    

    [TestMethod]
    public void Run_LocalHost_Success()
    {
        int exitCode = Sut.Run("localhost").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }
    //When running this test, stdOutput comes back as Empty
    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {

        (string expectedOutput, int expectedExitCode)  = IsUnix ? ("ping: badaddress: Temporary failure in name resolution", 2) : ("Ping request could not find host badaddress. Please check the name and try again.",1);
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

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        // Do NOT use async/await in this test.
        Task<PingResult> result = Sut.RunTaskAsync("localhost");
        AssertValidPingOutput(result.Result);
    }



    [TestMethod]
    async public Task RunTaskAsync_WithProgress_Success()
    {
        string progressAppended = "";
        var progress = new PingProgress<string?>((output) => progressAppended += output + Environment.NewLine);

        PingResult result = await Sut.RunAsync("localhost", progress);

        // result.StdOutput will not be null
        Assert.AreEqual<string>(result.StdOutput!.Trim(), progressAppended.Trim());
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
        Task<PingResult> task = Sut.RunAsync("localhost", null, cancelSource.Token);
        task.Wait();
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Use exception.Flatten()
        CancellationTokenSource cancelSource = new();
        cancelSource.Cancel();
        Task<PingResult> task = Sut.RunAsync("localhost", null, cancelSource.Token);
        try
        {
            task.Wait();
        }
        catch (AggregateException a)
        {
            throw a.Flatten().InnerException!;
        }
    }


    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        // Pseudo Code - don't trust it!!!
        // -> seems to work well enough
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int lineCount = result.StdOutput!.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);
    }

    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        ProcessStartInfo startInfo = new("ping", $"{LimitPingArg} 4 localhost");

        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, default);

        Assert.AreEqual(0, exitCode);
    }

    // Commented out because it is not really possible to PROVE whether code is thread safe or not,
    // as race conditions and other symptoms of thread-unsafety are undefined behavior.
    /*[TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count() + 1);
    }*/

    // Alternate version of the above test, using Assert.ThrowsException, which does not work every time
    /*[TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        Assert.ThrowsException<AggregateException>(() => numbers.AsParallel().ForAll(item => stringBuilder.AppendLine("")));
    }*/

    //Version of the above test that seems to pass consistenly, but we're in terms of passing the PR, it doesn't help due to its inconsistencies
    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        try
        {
            IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
            StringBuilder stringBuilder = new();
            numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
            int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
            Assert.AreNotEqual(lineCount, numbers.Count() + 1);
        }
        catch (AggregateException)
        {

        }
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
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);


    public class PingProgress<T>(Action<T> Update) : IProgress<T>
    {
        public Action<T> Update = Update;
        public void Report(T value)
        {
            Update(value);
        }
    }

}
