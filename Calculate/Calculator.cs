namespace Calculate;

public class Calculator
{
    public static int Add(int a, int b)
    {
        int answer = a + b;
        return answer;
    }

    public static int Subtract(int a, int b)
    {
        int answer = a - b;
        return answer;
    }

    public static int Multiple(int a, int b)
    {
        int answer = a * b;
        return answer;
    }

    public static int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Divide by 0 Error");
        }

        int answer = a / b;
        return answer;
    }

    public static void TryCalculate()
    {

    }
}
