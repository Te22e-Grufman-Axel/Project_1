abstract class Item
{
    public string Name { get; protected set; }

    public Item(string name)
    {
        Name = name;
    }

    public abstract string GetStats();
}
