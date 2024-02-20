using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate;
public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, int>>
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiply,
        ['/'] = Divide
    };

    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
    public static int Divide(int a, int b) => b != 0 ? a / b : throw new ArgumentException("Can't divide by 0", nameof(b));
}

