
namespace Calculate;

public class Calculator
{

    public static int Add(int value1, int value2)
    {
        ArgumentNullException.ThrowIfNull(value1);
        ArgumentNullException.ThrowIfNull(value2);

        return value1 + value2;
    }

    public static int Subtract(int value1, int value2)
    {
        throw new NotImplementedException();
    }

    public static int Multiple(int multiplicand, int multiplier)
    {
        return multiplicand * multiplier;
    }

    public static double Divide(int dividend, int divisor)
    {
        return dividend / (double) divisor;
    }
}
