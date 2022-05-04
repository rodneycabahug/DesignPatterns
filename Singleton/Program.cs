// https://www.dofactory.com/net/singleton-design-pattern

class Program
{
    public static void Main()
    {
        Singleton instanceOne = Singleton.Instance;
        Singleton instanceTwo = Singleton.Instance;

        if (instanceOne == instanceTwo)
            Console.WriteLine("instanceOne and instanceTwo are the same instances.");
    }
}

internal class Singleton
{
    private static readonly Singleton _instance = new Singleton();

    public static Singleton Instance
    { 
        get => _instance;
    }

    private Singleton()
    {
    }
}