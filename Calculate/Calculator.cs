using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate;
    public class Calculator
    {


    public static double Add(double x, double y) => x + y;
    public static double Subtract(double x, double y) => x - y;
    public static double Multiply(double x, double y) => x * y;
    public static double Divide(double x, double y)
    {
        if (y == 0)
            throw new ArgumentException("Can't divide by zero");
     return x / y;
    }

    public IReadOnlyDictionary<char, Func<double, double, double>> MathematicalOperations { get; } =
    new Dictionary<char, Func<double, double, double>>
    {
            { '+', Add },
            { '-', Subtract }, 
            { '*', Multiply },
            { '/', Divide }  
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

