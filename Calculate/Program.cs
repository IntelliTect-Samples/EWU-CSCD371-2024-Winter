using System.Globalization;
using ConsoleUtilites;
namespace Calculate;

public class Program : ProgramBase
{
    public Program()
    {
    }

    public static void Main(string[] args)
    {

        int res;
        string? expression;
        Program program = new();
        Calculator calculator = new Calculator();
        do
        {
            program.WriteLine("Please Enter Your Expression: ");
            expression = program.ReadLine();

        } while (!calculator.TryCalculate(expression!, out res));

        program.WriteLine(res.ToString(CultureInfo.InvariantCulture));
 
    }
}
