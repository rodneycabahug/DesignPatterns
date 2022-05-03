// https://www.dofactory.com/net/abstract-factory-design-pattern
class Program
{
    public static void Main()
    {
        AbstractFactory factoryOne = new ConcreteFactoryOne();
        Client clientOne = new Client(factoryOne);
        clientOne.Run();

        AbstractFactory factoryTwo = new ConcreteFactoryTwo();
        Client clientTwo = new Client(factoryTwo);
        clientTwo.Run();
    }
}

internal abstract class AbstractFactory
{
    internal abstract AbstractProductA? CreateProductA();

    internal abstract AbstractProductB? CreateProductB();
}

internal class ConcreteFactoryOne : AbstractFactory
{
    internal override AbstractProductA? CreateProductA() => new ProductAOne();

    internal override AbstractProductB? CreateProductB() => new ProductBOne();
}

internal class ConcreteFactoryTwo : AbstractFactory
{
    internal override AbstractProductA? CreateProductA() => new ProductATwo();

    internal override AbstractProductB? CreateProductB() => new ProductBTwo();
}

internal class AbstractProductB
{
}

internal class ProductBOne : AbstractProductB
{
}

internal class ProductBTwo : AbstractProductB
{
}

internal abstract class AbstractProductA
{
    internal abstract void Interact(AbstractProductB productB);
}

internal class ProductAOne : AbstractProductA
{
    internal override void Interact(AbstractProductB productB) =>
        Console.WriteLine($"{GetType().Name} => {productB.GetType().Name}");
}

internal class ProductATwo : AbstractProductA
{
    internal override void Interact(AbstractProductB productB) =>
        Console.WriteLine($"{GetType().Name} => {productB.GetType().Name}");
}

internal class Client
{
    private AbstractProductA _productA;
    private AbstractProductB _productB;

    public Client(AbstractFactory factory)
    {
        _productA = factory.CreateProductA();
        _productB = factory.CreateProductB();
    }

    internal void Run() => _productA.Interact(_productB);
}