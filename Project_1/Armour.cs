class Armor : Item
{
    public int Defense { get; private set; }

    public Armor(string name, int defense) : base(name)
    {
        Defense = defense;
    }

    public override string GetStats()
    {
        return $"Defense: {Defense}";
    }
}