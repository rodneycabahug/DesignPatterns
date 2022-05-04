// https://www.dofactory.com/net/proxy-design-pattern

class Program
{
    public static void Main()
    {
        var subject = new Proxy();
        subject.Operation();
    }
}

internal abstract class Subject
{
    internal abstract void Operation();
}

internal class RealSubject : Subject
{
    internal override void Operation() =>
        Console.WriteLine("{0} {1}", nameof(RealSubject), nameof(Operation));
}

internal class Proxy : Subject
{
    private Lazy<RealSubject> _realSubject = new(() => new RealSubject());

    internal override void Operation() => _realSubject.Value.Operation();
}