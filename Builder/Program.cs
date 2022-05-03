// https://www.dofactory.com/net/builder-design-pattern

class Program
{
    public static void Main()
    {
        Director director = new Director();

        Builder builderOne = new ConcreteBuilderOne();
        Builder builderTwo = new ConcreteBuilderTwo();

        director.Construct(builderOne);
        Product productOne = builderOne.GetResult();
        productOne.Show();

        director.Construct(builderTwo);
        Product productTwo = builderTwo.GetResult();
        productTwo.Show();
    }
}

internal class Product
{
    private readonly string _name;
    private readonly List<string> _parts;

    internal Product(string name)
    {
        _name = name;
        _parts = new List<string>();
    }

    internal void Show()
    {
        Console.WriteLine("------------------");
        Console.WriteLine($"{_name} Parts:");
        foreach (var part in _parts)
            Console.WriteLine(part);
        Console.WriteLine("------------------");
        Console.WriteLine("------------------");
    }

    internal void AddPart(string part) => _parts.Add(part);
}

internal class ConcreteBuilderTwo : Builder
{
    internal ConcreteBuilderTwo()
    {
        _product = new Product("Product Two");
    }

    internal override void BuildPartA() => _product.AddPart("PartA");

    internal override void BuildPartB() => _product.AddPart("PartB");

    internal override void BuildPartC() => _product.AddPart("PartC");

    internal override Product GetResult() => _product;
}

internal class ConcreteBuilderOne : Builder
{
    internal ConcreteBuilderOne()
    {
        _product = new Product("Product One");
    }

    internal override void BuildPartA() => _product.AddPart("PartX");

    internal override void BuildPartB() => _product.AddPart("PartY");

    internal override void BuildPartC() => _product.AddPart("PartZ");

    internal override Product GetResult() => _product;
}

internal abstract class Builder
{
    internal Product _product;

    internal abstract Product GetResult();

    internal abstract void BuildPartA();

    internal abstract void BuildPartB();

    internal abstract void BuildPartC();
}

internal class Director
{
    internal void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
    }
}