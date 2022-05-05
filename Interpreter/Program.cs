// https://www.dofactory.com/net/interpreter-design-pattern

using System.Text;

class Program
{
    public static void Main()
    {
        var expression = "1 * 2 ( 3 + 4 / 2 - 5 )";
        var calculator = new Calculator(new Context());

        //var postfix = calculator.InfixToPostfix(expression);
        //Console.WriteLine("{0}: {1} => {2}", nameof(Calculator.InfixToPostfix), expression, postfix);

        var result = calculator.Calculate(expression);
        Console.WriteLine("{0}: {1} => {2}", nameof(Calculator.Calculate), expression, result);

    }
}

class Calculator
{

    private readonly Context _context;

    public Calculator(Context context) => _context = context;

    public decimal Calculate(string expression)
    {
        var postfix = InfixToPostfix(expression);
        var rootExpression = BuildExpressionTree(postfix);
        return rootExpression.Interpret(_context);
    }

    public string InfixToPostfix(string expression)
    {
        var stack = new Stack<string>();
        var tokens = expression.Split(" ",
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var postfix = new StringBuilder();

        foreach (var token in tokens)
        {
            if (_context.IsOperand(token))
            {
                postfix.Append(token + " ");
                continue;
            }

            if (_context.IsOpenBracket(token))
            {
                stack.Push(token);
                continue;
            }

            if (_context.IsCloseBracket(token))
            {
                while (stack.Count > 0
                    && !_context.IsOpenBracket(stack.Peek()))
                {
                    postfix.Append(stack.Pop() + " ");
                }

                if (stack.Count > 0
                    && !_context.IsOpenBracket(stack.Peek()))
                    throw new InvalidDataException();
                else
                    stack.Pop();

                continue;
            }

            // Operator
            while (stack.Count > 0
                && _context.OperatorPriority(token)
                    <= _context.OperatorPriority(stack.Peek()))
                postfix.Append(stack.Pop() + " ");
            stack.Push(token);
        }

        // All operators left in stack
        while (stack.Count > 0)
            postfix.Append(stack.Pop() + " ");

        return postfix.ToString();
    }

    private IExpression BuildExpressionTree(string postfixExpression)
    {
        var stack = new Stack<IExpression>();
        var tokens = postfixExpression.Split(" ",
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var token in tokens)
        {
            if (_context.IsOperand(token))
            {
                var numberExpression = new NumberExpression(token);
                stack.Push(numberExpression);
            }
            else
            {
                var right = stack.Pop();
                var left = stack.Pop();
                var operandExpression = OperationExpression.GetExpression(token, left, right);
                stack.Push(operandExpression);
            }
        }

        return stack.Peek();
    }
}

class Context
{
    public decimal GetValue(string number) => decimal.Parse(number);

    public bool IsOperator(string c) => "+-*/".IndexOf(c) != -1;

    public int OperatorPriority(string symbol) => symbol switch
    {
        "-" => 0,
        "+" => 1,
        "/" => 2,
        "*" => 3,
        _ => -1
    };

    public bool IsOperand(string number) => decimal.TryParse(number, out decimal _);

    public bool IsOpenBracket(string c) => "(" == c;

    public bool IsCloseBracket(string c) => ")" == c;
}

interface IExpression
{
    decimal Interpret(Context context);
}

// Terminal
class NumberExpression : IExpression
{
    protected readonly string _number;

    public NumberExpression(string number) => _number = number;

    public decimal Interpret(Context context) => context.GetValue(_number);
}

// NonTerminal
abstract class OperationExpression : IExpression
{
    protected readonly IExpression _left, _right;

    public OperationExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public abstract decimal Interpret(Context context);

    public static OperationExpression GetExpression(
        string symbol, IExpression left, IExpression right) => symbol switch
    {
        "+" => new AddExpression(left, right),
        "-" => new SubtractExpression(left, right),
        "*" => new MultiplyExpression(left, right),
        "/" => new DivideExpression(left, right),
        _ => throw new ArgumentOutOfRangeException(nameof(symbol))
    };
}

class AddExpression : OperationExpression
{
    public AddExpression(IExpression left, IExpression right) : base(left, right)
    {

    }

    public override decimal Interpret(Context context)
    {
        return _left.Interpret(context) + _right.Interpret(context);
    }
}

class SubtractExpression : OperationExpression
{
    public SubtractExpression(IExpression left, IExpression right) : base(left, right)
    {

    }

    public override decimal Interpret(Context context)
    {
        return _left.Interpret(context) - _right.Interpret(context);
    }
}

class MultiplyExpression : OperationExpression
{
    public MultiplyExpression(IExpression left, IExpression right) : base(left, right)
    {

    }

    public override decimal Interpret(Context context)
    {
        return _left.Interpret(context) * _right.Interpret(context);
    }
}

class DivideExpression : OperationExpression
{
    public DivideExpression(IExpression left, IExpression right) : base(left, right)
    {

    }

    public override decimal Interpret(Context context)
    {
        return _left.Interpret(context) / _right.Interpret(context);
    }
}