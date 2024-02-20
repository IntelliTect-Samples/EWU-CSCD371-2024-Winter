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

    public bool TryCalculate(string expression, out double result)
        {
            result = 0;
            
            // Split the expression by whitespace
            string[] parts = expression.Split(' ');
            
            // Check if the expression has the correct number of parts
            if (parts.Length != 3)
                return false;
            
            // Extract operands and operator
            double operand1, operand2;
            char operation;
            if (!double.TryParse(parts[0], out operand1) || !double.TryParse(parts[2], out operand2) || 
                parts[1].Length != 1 || !char.TryParse(parts[1], out operation))
                return false;
            
            // Check if the operator is supported
            if (!MathematicalOperations.ContainsKey(operation))
                return false;
            
            // Perform the calculation
            if (MathematicalOperations.TryGetValue(operation, out var operationFunc))
            {
                result = operationFunc(operand1, operand2);
                return true;
            }
            
            return false;
        }

}

