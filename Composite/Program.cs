// https://www.dofactory.com/net/composite-design-pattern

class Program
{
    public static void Main()
    {
        Composite root = new Composite("R");

        root.Add(new Leaf("L1"));
        root.Add(new Leaf("L2"));

        Composite compositeChildOne = new Composite("C1");
        compositeChildOne.Add(new Leaf("L3"));
        compositeChildOne.Add(new Leaf("L4"));
        root.Add(compositeChildOne);

        root.Add(new Leaf("L5"));

        Leaf leaf = new Leaf("L6");
        root.Add(leaf);

        root.Display(1);

        Console.WriteLine();
        Console.WriteLine();

        root.Remove(leaf);

        root.Display(1);
    }
}

internal abstract class Component
{
    internal readonly string _name;

    internal Component(string name) => _name = name;

    internal abstract void Add(Component component);
    internal abstract void Remove(Component component);
    internal abstract void Display(int depth);
}

internal class Composite : Component
{
    private readonly List<Component> _children = new List<Component>();

    public Composite(string name) : base(name)
    {
    }

    internal override void Add(Component component) => _children.Add(component);

    internal override void Display(int depth)
    {
        Console.WriteLine("{0}{1}", new String('-', depth), _name);

        foreach (Component child in _children)
            child.Display(depth + 2);
    }

    internal override void Remove(Component component) => _children.Remove(component);
}

internal class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
    }

    internal override void Add(Component component) => throw new InvalidOperationException("Cannot add to Leaf");

    internal override void Display(int depth) => Console.WriteLine("{0}{1}", new String('-', depth), _name);

    internal override void Remove(Component component) => throw new InvalidOperationException("Cannot remove from Leaf");
}

