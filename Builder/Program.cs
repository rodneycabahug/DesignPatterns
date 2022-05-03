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
    private readonly List<string> _parts = new List<string>();

    internal void Show()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("Product Parts List");
        foreach (var part in _parts)
            Console.WriteLine(part);
        Console.WriteLine("------------------");
        Console.WriteLine("------------------");
    }

    internal void AddPart(string part) => _parts.Add(part);
}

internal class ConcreteBuilderTwo : Builder
{
    private readonly Product _product = new Product();

    internal override void BuildPartA() => _product.AddPart("ProductTwo: PartA");

    internal override void BuildPartB() => _product.AddPart("ProductTwo: PartB");

    internal override void BuildPartC() => _product.AddPart("ProductTwo: PartB");

    internal override Product GetResult() => _product;
}

internal class ConcreteBuilderOne : Builder
{
    private readonly Product _product = new Product();

    internal override void BuildPartA() => _product.AddPart("ProductOne: PartA");

    internal override void BuildPartB() => _product.AddPart("ProductOne: PartB");

    internal override void BuildPartC() => _product.AddPart("ProductOne: PartB");

    internal override Product GetResult() => _product;
}

internal abstract class Builder
{
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