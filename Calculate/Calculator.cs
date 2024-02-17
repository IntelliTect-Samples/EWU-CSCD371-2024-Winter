﻿
namespace Calculate;

public class Calculator
{
    public static double Add(int value1, int value2)
    {
        ArgumentNullException.ThrowIfNull(value1);
        ArgumentNullException.ThrowIfNull(value2);

        return value1 + value2;
    }
}
