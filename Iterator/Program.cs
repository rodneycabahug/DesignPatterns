// https://www.dofactory.com/net/iterator-design-pattern

class Program
{
    public static void Main()
    {
        var aggregate = new Aggregate<int>();
        foreach (int number in Enumerable.Range(1, 20))
            aggregate.Add(number);

        var iterator = aggregate.CreateIterator();
        while (!iterator.IsDone)
        {
            Console.WriteLine("{0} => {1}", nameof(IIterator<int>.CurrentItem), iterator.CurrentItem);
            iterator.MoveNext();
        }
    }
}

interface IIterator<T>
{
    T First();
    void MoveNext();
    bool IsDone { get; }
    T CurrentItem { get; }
}

class Iterator<T> : IIterator<T>
{
    private readonly Aggregate<T> _aggregate;
    private int _pointer;

    public Iterator(Aggregate<T> aggregate)
    {
        _aggregate = aggregate;
        _pointer = 0;
    }

    public bool IsDone => _pointer >= _aggregate.Count;

    public T CurrentItem => _aggregate[_pointer];

    public T First()
    {
        _pointer = 0;
        return _aggregate[_pointer];
    }

    public void MoveNext()
    {
        if (IsDone)
            throw new IndexOutOfRangeException();

        _pointer++;
    } 
}

interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

class Aggregate<T> : IAggregate<T>
{
    private readonly IList<T> _list = new List<T>();

    public IIterator<T> CreateIterator() => new Iterator<T>(this);

    public int Count => _list.Count;

    public void Add(T item) => _list.Add(item);

    public T this[int index] => _list[index];
}