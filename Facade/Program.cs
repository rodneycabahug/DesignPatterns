// https://www.dofactory.com/net/facade-design-pattern

class Program
{
    public static void Main()
    {
        var facade = new Facade();
        facade.OperationOne();
        facade.OperationTwo();
    }
}

internal class Facade
{
    private readonly SubSystemOne _one;
    private readonly SubSystemTwo _two;
    private readonly SubSystemThree _three;
    private readonly SubSystemFour _four;

    internal Facade()
    {
        _one = new SubSystemOne();
        _two = new SubSystemTwo();
        _three = new SubSystemThree();
        _four = new SubSystemFour();
    }

    internal void OperationOne()
    {
        _one.Operation();
        _two.Operation();
        _three.Operation();
    }

    internal void OperationTwo()
    {
        _two.Operation();
        _three.Operation();
        _four.Operation();
    }
}

internal abstract class SubSystem
{
    internal abstract void Operation();
}

internal class SubSystemFour : SubSystem
{
    internal override void Operation() =>
        Console.WriteLine("{0}.{1}", typeof(SubSystemFour), nameof(Operation));
}

internal class SubSystemThree : SubSystem
{
    internal override void Operation() =>
        Console.WriteLine("{0}.{1}", typeof(SubSystemThree), nameof(Operation));
}

internal class SubSystemTwo : SubSystem
{
    internal override void Operation() =>
        Console.WriteLine("{0}.{1}", typeof(SubSystemTwo), nameof(Operation));
}

internal class SubSystemOne : SubSystem
{
    internal override void Operation() =>
        Console.WriteLine("{0}.{1}", typeof(SubSystemOne), nameof(Operation));
}
