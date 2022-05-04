// https://www.dofactory.com/net/command-design-pattern

class Program
{
    public static void Main()
    {
        var invoker = new Invoker(new ConcreteCommand(new Receiver()));
        invoker.ExecuteCommand();
    }
}

internal class Invoker
{
    private readonly Command _command;

    internal Invoker(Command command)
    {
        _command = command;
    }

    internal void ExecuteCommand() => _command.Execute();
}

internal class ConcreteCommand : Command
{
    internal ConcreteCommand(Receiver reciever) : base(reciever)
    {
    }

    internal override void Execute()
    {
        Console.WriteLine("{0} {1}", nameof(ConcreteCommand), nameof(Execute));
        base.Execute();
        Console.WriteLine("{0} {1}", nameof(ConcreteCommand), nameof(Execute));
    }
}

internal abstract class Command
{
    private readonly Receiver _reciever;

    protected Command(Receiver reciever)
    {
        _reciever = reciever;
    }

    internal virtual void Execute() => _reciever.Operation();
}

internal class Receiver
{
    internal void Operation() => Console.WriteLine("{0} {1}", nameof(Receiver), nameof(Operation));
}