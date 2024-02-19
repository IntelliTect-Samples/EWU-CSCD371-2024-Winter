namespace Calculate;

public class Calculator
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    public static int Multiple(int a, int b)
    {
        return a * b;
    }

    public static int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Divide by 0 Error");
        }

        return a / b;
    }

    public static void TryCalculate()
    {

    }
}
