Assignment
The purpose of this assignment is to learn how to work with delegates and lambda expressions. We will define a calculator class that stores 4 actions corresponding to +, -, *, /, and multiple. The calculator class will also support customizable behavior for reading and writing content.

Reading
Due 2/20:
Chapter 13: Delegates and Lambda Expressions Chapter 15: Collection Interfaces with Standard Query Operators

Due 2/27:
Chapter 17: Building Custom Collections (You can skim the More Collection Interfaces and Primary Collection Classes sections) Chapter 20: Programming with Task-Based Asynchronous Pattern Chapter 22: Thread Synchronization

Due 3/06
Chapter 19: Introducing Multithreading Chapter 21: Iterating in Parallel

Recommended But Not Required (in order of priority)
Chapter 19: Introducing Multithreading Chapter 21: Iterating in Parallel Chapter 18: Reflection, Attributes, and Dynamic Programming Chapter 16: LINQ with Query Expressions Chapter 14: Events

Instructions
Create a Console project called "Calculate.". ❌✔
Define a Program Class
Define two init-only setter properties, WriteLine and ReadLine, that contain delegates for writing a line of text and reading a line of text respectively ❌✔
Write a test that sets these properties at construction time and then invokes the properties and verifies the expected behavior occurs. ❌✔
Set the default behavior for the WriteLine and ReadLine properties to invoke System.Console versions of the methods and add an empty default constructor. ❌✔
Define a Calculator class ❌✔
Define static Add, Subtract, Multiple, and Divide methods that have two parameters and return a third parameter. ❌✔
Define a read-only property, MathematicalOperations, of type System.Collections.Generics.IReadOnlyDictionary<TKey,TValue> that:
is initialized to a System.Collections.Generics.Dictionary<<TKey,TValue> instance that. ❌✔
Uses char for the key corresponding to the operators +, -, *, and /. ❌✔
Has values that correspond with the Add, Subtract, Multiple, and Divide methods. ❌✔
Implement a TryCalculate method following "TryParse" pattern ❌✔
Valid calculation expressions include such strings as "3 + 4", "42 - 2", etc. ❌✔
If there is no whitespace around the operator, you can assume the calculation is invalid and return false. Similarly if the operands are not integers. ❌✔
Use string.Split(), pattern matching, logical and operators to parse the string in their entirety ❌✔
Index into the MathematicalOperations method using the operator parsed during pattern matching to find the corresponding implementation and invoke it. ❌✔
Implement the Program class to instantiate the calculator and invoke it based on user input from the console. ❌✔
Be sure to use the WriteLine/ReadLine properties on Program for testing the input and output of your program. ❌✔
Extra Credit
Do one of the following two options (or both if you want extra, extra credit) :)

Refactor the redirect portion of the Program class into 'ProgramBase`
Move ProgramBase into a ConsoleUtilities assembly to be used in other console-based projects
Use generics the mathematical operations methods and consider using generic constraints (requires .NET 7.0)
Fundamentals
Place all shared project properties into a Directory.Build.Props file.
Place all shared project items into a Directory.Build.targets file.
nullable reference types is enabled ❌✔
Ensure that you turn on code analysis for all projects(EnableNETAnalyzers) ❌✔
Set LangVersion and the TargetFramework to the latest released versions available (preview versions optional) ❌✔
and enabled .NET analyzers for both projects ❌✔
For this assignment, always use Assert.AreEqual<T>() (the generic version) ❌✔
All of the above should be unit tested ❌✔
Choose simplicity over complexity ❌✔
See Docs