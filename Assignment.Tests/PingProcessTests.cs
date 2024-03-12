﻿using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    [DataRow(1)]
    [DataRow(4)]
    [DataRow(5)]
    [DataRow(64)]
    public void CrossPlatformNumPingFlags_ReturnsProperValue(int numPings)
    {
        string args = PingProcess.CrossPlatformNumPingFlags(numPings);
        if(PingProcess.IsWindows)
        {
            Assert.AreEqual($"-n {numPings}", args);
        }
        else
        {
            Assert.AreEqual($"-c {numPings}", args);
        }
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        string pingCountArg = PingProcess.CrossPlatformNumPingFlags(4);
        Process process = Process.Start("ping", $"{pingCountArg} localhost");
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
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput) = Sut.Run("badaddress");
        stdOutput = stdOutput?.Trim();
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput) && PingProcess.IsWindows, $"stdOutput: '{stdOutput}'");
        string expected = PingProcess.IsWindows?
            "Ping request could not find host badaddress. Please check the name and try again.":"";

        Assert.AreEqual<string?>(expected, stdOutput);
        Assert.AreNotEqual<int>(0, exitCode);
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
        // Test Sut.RunTaskAsync("localhost");
        PingResult result = Sut.RunTaskAsync("localhost").Result;
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        PingResult result = default;

        // Test Sut.RunAsync("localhost");
        Task<PingResult> task = Sut.RunAsync("::1");
        task.Wait();
        result = task.Result;

        AssertValidPingOutput(result);
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        PingResult result = await Sut.RunAsync("::1");

        // Test Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Use exception.Flatten()
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
    }

    [TestMethod]
#pragma warning disable CS1998 // Remove this
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        PingResult result = default;
        // Test Sut.RunLongRunningAsync("localhost");
        AssertValidPingOutput(result);
    }
#pragma warning restore CS1998 // Remove this

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine("line"));
        Assert.AreNotEqual<int>(0, stringBuilder.Length);
        int lineCount = stringBuilder.ToString().Split("\n").Length;
        Assert.AreNotEqual(lineCount, numbers.Count()+1);
    }

    readonly string PingOutputLikeExpression = (PingProcess.IsWindows?@"
Pinging * with 32 bytes of data:
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*

Ping statistics for ::1:
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *":@"
PING ::1 (::1) 64 data bytes
64 bytes from ::1: icmp_seq=1 ttl=64 time=0.* ms
64 bytes from ::1: icmp_seq=2 ttl=64 time=0.* ms
64 bytes from ::1: icmp_seq=3 ttl=64 time=0.* ms
64 bytes from ::1: icmp_seq=4 ttl=64 time=0.* ms

--- ::1 ping statistics ---
4 packets transmitted, 4 received, 0% packet loss, time *ms
rtt min/avg/max/mdev = 0.*/0.*/0.*/0.* ms").Trim();

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
