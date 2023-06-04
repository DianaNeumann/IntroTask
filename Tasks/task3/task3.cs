using static System.Int32;

namespace task3;

internal static class Task3
{
    public static void Main()
    {
        var expression = Console.ReadLine();
        var calc = new Calculator(expression!);
        Console.WriteLine(calc.Compute());
    }
}


internal class Calculator
{
    private string _expression;
    private readonly string[] _tokens;

    public Calculator(string expression)
    {
        _expression = expression;
        _tokens = expression.Split(' ');
    }

    public double Compute()
    {
        double result = 0;
        var stack = new Stack<double>(); 

        foreach (var token in _tokens)
        {
            if (IsOperand(token))
            {
                var operand = Convert.ToDouble(token);
                stack.Push(operand);
            }
            else if (IsOperation(token))
            {
                var rhs = stack.Pop();
                var lhs = stack.Pop();
                
                result = CalculateAction(token, lhs, rhs);
                stack.Push(result);
            }
        }

        return result;
    }
    

    private static bool IsOperand(string value) => TryParse(value, out var res);

    private static bool IsOperation(string value) => value.Length == 1 && 
                                                     Enum
                                                         .GetValues(typeof(Operations))
                                                         .Cast<int>()
                                                         .Any(item => item == value[0]);
    

    private static double CalculateAction(string token, double lhs, double rhs)
    {
        var operation = (Operations)token.ToCharArray()[0];
        return operation switch
        {
            Operations.Plus => lhs + rhs,
            Operations.Minus => lhs - rhs,
            Operations.Devide => lhs / rhs,
            Operations.Mult => lhs * rhs,
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }


}

internal enum Operations
{
    Plus = '+',
    Minus = '-',
    Devide = '/',
    Mult = '*'
}