// https://www.dofactory.com/net/flyweight-design-pattern

class Program
{
    public static void Main()
    {
        int extrinsicState = 10;

        var factory = new FlyweightFactory();
        factory.GetFlyweight("1").Operation(--extrinsicState);
        factory.GetFlyweight("2").Operation(--extrinsicState);
        factory.GetFlyweight("3").Operation(--extrinsicState);

        var flyweight = new UnsharedConcreteFlyweight();
        flyweight.Operation(--extrinsicState);
    }
}

internal class FlyweightFactory
{
    internal Dictionary<string, Flyweight> Flyweights { get; set; }
        = new Dictionary<string, Flyweight>();

    internal FlyweightFactory()
    {
        Flyweights.Add("1", new ConcreteFlyweightOne());
        Flyweights.Add("2", new ConcreteFlyweightTwo());
        Flyweights.Add("3", new ConcreteFlyweightThree());
    }

    internal Flyweight GetFlyweight(string key) => Flyweights[key];
}

internal class ConcreteFlyweightThree : Flyweight
{
    internal override void Operation(int extrinsicState) =>
        Console.WriteLine("{0} {1}", typeof(ConcreteFlyweightThree).Name, extrinsicState);
}

internal class ConcreteFlyweightTwo : Flyweight
{
    internal override void Operation(int extrinsicState) =>
        Console.WriteLine("{0} {1}", typeof(ConcreteFlyweightTwo).Name, extrinsicState);
}

internal class ConcreteFlyweightOne : Flyweight
{
    internal override void Operation(int extrinsicState) =>
        Console.WriteLine("{0} {1}", typeof(ConcreteFlyweightOne).Name, extrinsicState);
}

internal class UnsharedConcreteFlyweight : Flyweight
{
    internal override void Operation(int extrinsicState) =>
        Console.WriteLine("{0} {1}", typeof(UnsharedConcreteFlyweight).Name, extrinsicState);
}

internal abstract class Flyweight
{
    internal abstract void Operation(int extrinsicState);
}


