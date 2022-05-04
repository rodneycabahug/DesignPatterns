// https://www.dofactory.com/net/decorator-design-pattern

class Program
{
    public static void Main()
    {
        Component component = new ConcreteComponent();
        Decorator decoratorOne = new ConcreteDecoratorOne(component);
        Decorator decoratorTwo = new ConcreteDecoratorTwo(decoratorOne);

        decoratorTwo.Operation();
    }
}

internal abstract class Component
{
    internal abstract void Operation();
}

internal class ConcreteComponent : Component
{
    internal override void Operation() =>
        Console.WriteLine("{0}.{1}", typeof(ConcreteComponent).Name, nameof(Operation));
}

internal abstract class Decorator : Component
{
    protected internal Component _component;

    internal Decorator(Component component) => _component = component;

    internal override void Operation()
    {
        if (_component is not null)
            _component.Operation();
    }
}

internal class ConcreteDecoratorOne : Decorator
{
    internal ConcreteDecoratorOne(Component component) : base(component)
    {
    }

    internal override void Operation()
    {
        base.Operation();
        Console.WriteLine("{0}.{1}", typeof(ConcreteDecoratorOne).Name, nameof(Operation));
    }
}

internal class ConcreteDecoratorTwo : Decorator
{
    private const string AddedState = "AddedState";

    internal ConcreteDecoratorTwo(Component component) : base(component)
    {
    }

    internal override void Operation()
    {
        base.Operation();
        AddedBehavior();
        Console.WriteLine("{0}.{1}", typeof(ConcreteDecoratorTwo).Name, nameof(Operation));
    }

    private void AddedBehavior() =>
        Console.WriteLine("{0}.{1}", typeof(ConcreteDecoratorTwo).Name, AddedState);
}