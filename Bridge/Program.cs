// https://www.dofactory.com/net/bridge-design-pattern

class Program
{
    public static void Main()
    {
        Abstraction abstraction = new RefinedAbstraction();

        abstraction.Implementor = new ConcreteImplementorOne();
        abstraction.Operation();

        abstraction.Implementor = new ConcreteImplementorTwo();
        abstraction.Operation();
    }
}

internal class ConcreteImplementorTwo : Implementor
{
    internal override void Operation() =>
        Console.WriteLine("{0} {1}",
            typeof(ConcreteImplementorTwo).Name, nameof(Operation));
}

internal class ConcreteImplementorOne : Implementor
{
    internal override void Operation() =>
        Console.WriteLine("{0} {1}",
            typeof(ConcreteImplementorOne).Name, nameof(Operation));
}

internal class RefinedAbstraction : Abstraction
{
    internal override void Operation() => Implementor.Operation();
}

internal abstract class Abstraction
{
    internal Implementor Implementor { get; set; }

    internal abstract void Operation();
}

internal abstract class Implementor
{
    internal abstract void Operation();
}