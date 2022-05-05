// https://www.dofactory.com/net/mediator-design-pattern

using System.Xml.Linq;

class Program
{
    public static void Main()
    {
        var boyOne = new BoyColleague("Boy One");
        var boyTwo = new BoyColleague("Boy Two");
        var girlOne = new GirlColleague("Girl One");
        var girlTwo = new GirlColleague("Girl Two");

        var mediator = new ConcreteMediator();
        mediator.Register(boyOne);
        mediator.Register(boyTwo);
        mediator.Register(girlOne);
        mediator.Register(girlTwo);

        girlOne.Send("Message One", boyOne.Name);
        girlTwo.Send("Message Two", boyTwo.Name);
        boyOne.Send("Message One", girlOne.Name);
        boyTwo.Send("Message Two", girlTwo.Name);
    }
}

interface IMediator
{
    void Register(Colleague colleague);

    void Send(string message, string destination);
}

class ConcreteMediator : IMediator
{
    private readonly IDictionary<string, Colleague> _partipants;

    public ConcreteMediator()
    {
        _partipants = new Dictionary<string, Colleague>();
    }

    public void Register(Colleague colleague)
    {
        _partipants.TryAdd(colleague.Name, colleague);
        colleague.Mediator = this;
    }

    public void Send(string message, string destination) => _partipants[destination].Notify(message);
}

abstract class Colleague
{
    public string Name { get; set; }

    public IMediator Mediator { get; set; }

    public Colleague(string name) => Name = name;

    public void Send(string message, string destination) => Mediator.Send(message, destination);

    public abstract void Notify(string message);
}

class BoyColleague : Colleague
{
    public BoyColleague(string name) : base(name)
    {
    }

    public override void Notify(string message) =>
        Console.WriteLine("{0} {1} {2} => {3}", nameof(BoyColleague), Name, nameof(Notify), message);
}

class GirlColleague : Colleague
{
    public GirlColleague(string name) : base(name)
    {
    }

    public override void Notify(string message) =>
        Console.WriteLine("{0} {1} {2} => {3}", nameof(GirlColleague), Name, nameof(Notify), message);
}