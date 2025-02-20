public class Item
{
    public string Name { get; private set; }

    public Item(string name) // Constructor with only name
    {
        Name = name;
    }

    // Make the method virtual so it can be overridden
    public virtual string GetStats()
    {
        return $"Item: {Name}";
    }
}
