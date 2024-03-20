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
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "localhost");
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
        // Do NOT use async/await in this test.
        // Test Sut.RunTaskAsync("localhost");
        Task<PingResult> task = Sut.RunTaskAsync("localhost");
        task.Wait();
        PingResult result = task.Result;
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        // Test Sut.RunAsync("localhost");
        Task<PingResult> task = Sut.RunAsync("localhost");
        task.Wait();
        PingResult result = task.Result;
        AssertValidPingOutput(result);
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        // Test Sut.RunAsync("localhost");
        PingResult result = await Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        CancellationTokenSource cts = new();
        cts.Cancel();
        Task<PingResult> task = Sut.RunAsync("localhost", cts.Token);
        task.Wait();
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Use exception.Flatten()
        CancellationTokenSource cts = new();
        cts.Cancel();
        Task<PingResult> task = Sut.RunAsync("localhost", cts.Token);
        try
        {
            task.Wait();
        }
        catch (AggregateException a)
        {
            if(a.Flatten().InnerException != null)
            {
                //Ignoring null possibility because of check
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
        //string[] hostNames = ["localhost", "localhost", "localhost", "localhost"];
        //int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;
        //PingResult result = await Sut.RunAsync(hostNames);
        //int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        //Assert.AreEqual(expectedLineCount, lineCount);
        string[] hostNames = ["localhost", "localhost", "localhost", "localhost"];
        bool countLines = true;
        string[] expectedLines = PingOutputLikeExpression.Split(Environment.NewLine);
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = 0;
        int hostCount = 0;
        string[]? extraLines = result.StdOutput?.Split('\n');
        // This is a really ugly looking pile of spaghetti, but it does work
        // This has the issue where the local hosts don't appear to be running in parallel
        if(extraLines is not null)
        {
            for (int i = 0; i < extraLines.Length; i++)
            {
                if (countLines && hostCount < hostNames.Length)
                {
#pragma warning disable CS8602
                    // Intellisense wants it to say if it doesn't contain Minimum, which I think is
                    // less readable than what it is now
                    if (extraLines[i].Contains("Minimum"))
#pragma warning restore CS8602
                    {
                        hostCount++;
                        countLines = false;
                    }
                    lineCount++;
                }
                else
                {
                    if(i != extraLines.Length -1) //Might not need this
                    {
                        if (extraLines[i + 1].Contains("Pinging"))
                        {
                            countLines = true;
                        }
                    }
                }
            }
            lineCount--;
        }
        else
        {
            throw new NullReferenceException();
        }
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
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count()+1);
    }

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
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression)??false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
