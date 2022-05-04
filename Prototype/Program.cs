// https://www.dofactory.com/net/prototype-design-pattern

class Program
{
    public static void Main()
    {
        ConcretePrototypeOne prototypeOne = new ConcretePrototypeOne("PrototypeOne");
        ConcretePrototypeOne cloneOne = (ConcretePrototypeOne)prototypeOne.Clone();
        Console.WriteLine("Cloned {0} into {1}", prototypeOne.Id, cloneOne.Id);

        ConcretePrototypeTwo prototypeTwo = new ConcretePrototypeTwo("PrototypeTwo");
        ConcretePrototypeTwo cloneTwo = (ConcretePrototypeTwo)prototypeTwo.Clone();
        Console.WriteLine("Cloned {0} into {1}", prototypeTwo.Id, cloneTwo.Id);
    }
}

internal abstract class Prototype
{
    internal string Id { get; private set; }

    internal Prototype(string id) => Id = id;

    internal abstract Prototype Clone();
}

internal class ConcretePrototypeOne : Prototype
{

    public ConcretePrototypeOne(string id) : base(id)
    {
    }

    internal override Prototype Clone() => new ConcretePrototypeOne($"PrototypeOne Clone: {Id}");
}

internal class ConcretePrototypeTwo : Prototype
{

    public ConcretePrototypeTwo(string id) : base(id)
    {
    }

    internal override Prototype Clone() => new ConcretePrototypeTwo($"PrototypeTwo Clone: {Id}");
}