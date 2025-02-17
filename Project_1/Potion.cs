class Potion : Item
{
    public int HealAmount { get; private set; }

    public Potion(string name, int healAmount) : base(name)
    {
        HealAmount = healAmount;
    }

    public override string GetStats()
    {
        return $"Heals: {HealAmount} HP";
    }
}