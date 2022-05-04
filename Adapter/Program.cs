// https://www.dofactory.com/net/adapter-design-pattern

class Program
{
    public static void Main()
    {
        Target target = new Adapter();
        target.Request();
    }
}

internal class Adaptee
{
    public void TargetIncompatibleRequest() =>
        Console.WriteLine("Called TargetIncompatibleRequest");
}

internal class Adapter : Target
{
    private readonly Adaptee _adaptee = new Adaptee();

    public void Request() => _adaptee.TargetIncompatibleRequest();
}

internal interface Target
{
    void Request();
}