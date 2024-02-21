using System;



public class ProgramBase
{

    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;using System;

	public ProgramBase () = new Program();
	{
	}
}
