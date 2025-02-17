class Weapon : Item
{
    public int Damage { get; private set; }

    public Weapon(string name, int damage) : base(name)
    {
        Damage = damage;
    }

    public override string GetStats()
    {
        return $"Damage: {Damage}";
    }
}