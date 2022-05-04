// https://www.dofactory.com/net/chain-of-responsibility-design-pattern

class Program
{
    public static void Main()
    {

        Handler odd = new OddHandler();

        Handler even = new EvenHandler();
        odd.Next = even;

        Handler less50 = new LessThan50Handler();
        even.Next = less50;

        Handler greater50 = new GreaterThan50Handler();
        less50.Next = greater50;

        var random = new Random();
        var requests = Enumerable.Range(1, 20).Select(i => random.Next(0, 100)).ToList();
        foreach (int request in requests)
            odd.HandleRequest(request);
    }
}

internal abstract class Handler
{
    internal Handler Next { get; set; }

    internal abstract void HandleRequest(int request);
}

internal class OddHandler : Handler
{
    internal override void HandleRequest(int request)
    {
        if (request % 2 == 1)
            Console.WriteLine("{0}.{1} {2}", nameof(OddHandler), nameof(HandleRequest), request);
        
        if (Next is not null)
            Next.HandleRequest(request);

    }
}

internal class EvenHandler : Handler
{
    internal override void HandleRequest(int request)
    {
        if (request % 2 == 0)
            Console.WriteLine("{0}.{1} {2}", nameof(EvenHandler), nameof(HandleRequest), request);
        
        if (Next is not null)
            Next.HandleRequest(request);

    }
}

internal class LessThan50Handler : Handler
{
    internal override void HandleRequest(int request)
    {
        if (request < 50)
            Console.WriteLine("{0}.{1} {2}", nameof(LessThan50Handler), nameof(HandleRequest), request);
        
        if (Next is not null)
            Next.HandleRequest(request);

    }
}

internal class GreaterThan50Handler : Handler
{
    internal override void HandleRequest(int request)
    {
        if (request > 50)
            Console.WriteLine("{0}.{1} {2}", nameof(GreaterThan50Handler), nameof(HandleRequest), request);
        
        if (Next is not null)
            Next.HandleRequest(request);

    }
}