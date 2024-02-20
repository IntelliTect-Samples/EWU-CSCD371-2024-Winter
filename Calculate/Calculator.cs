using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate;
    public class Calculator
    {


    public static int Add(int x, int y) => x + y;
    public static int Subtract(int x, int y) => x - y;
    public static int Multiply(int x, int y) => x * y;
    public static int Divide(int x, int y) => x / y;

    public IReadOnlyDictionary<char, Func<double, double, double>> MathematicalOperations { get; } =
    new Dictionary<char, Func<double, double, double>>
    {
            { '+', (a, b) => a + b },
            { '-', (a, b) => a - b }, 
            { '*', (a, b) => a * b }, 
            { '/', (a, b) => a / b }  
    };

}

