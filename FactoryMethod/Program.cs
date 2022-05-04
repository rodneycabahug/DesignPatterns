// https://www.dofactory.com/net/factory-method-design-pattern

class Program
{
    public static void Main()
    {
        Creator[] creators = new Creator[2];
        creators[0] = new ConcreteCreatorOne();
        creators[1] = new ConcreteCreatorTwo();

        foreach (var creator in creators)
        {
            Product product = creator.FactoryMethod();
            Console.WriteLine("Created {0}", product.GetType().Name);
        }
    }
}

abstract class Product
{
}

internal class ProductOne : Product
{
}

internal class ProductTwo : Product
{
}

internal class ConcreteCreatorTwo : Creator
{
    internal override Product FactoryMethod() => new ProductTwo();
}

internal class ConcreteCreatorOne : Creator
{
    internal override Product FactoryMethod() => new ProductOne();
}

internal abstract class Creator
{
    internal abstract Product FactoryMethod();
}