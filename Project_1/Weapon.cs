public class Weapon : Item
{
    public int Damage { get; set; }

    // Constructor
    public Weapon(string name, int damage) : base(name) 
    {
        Damage = damage;
    }
}
