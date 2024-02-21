namespace Calculate;

public class Program
{

    public Action<string> WriteLine { get; init; } = System.Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = System.Console.ReadLine;


    public Program() { }

    public static void Main(string[] args)
        {
        //Implement the Program class to instantiate the calculator
        Program program = new();
         
        Calculator calcutron = new();


        string? userInput;

        program.WriteLine("Welcome to the mighty Calcutron, please enter an expression using either +, -, *, / operators:");

        userInput = program.ReadLine();
            ArgumentException.ThrowIfNullOrEmpty(userInput);

        while (!calcutron.TryCalculate(userInput, out double answer))
        {
            program.WriteLine($"{answer}");
        }






    }//end of main

}//end of class


