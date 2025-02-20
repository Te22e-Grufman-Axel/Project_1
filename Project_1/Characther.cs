public class Character
{
    public string Name { get; set; }
    public int Health { get; protected set; }
    public int AttackPower { get; protected set; }

    // Constructor to initialize character properties
    public Character(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    // Method to attack another character
    public virtual void Attack(Character target)
    {
        Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage!");
        target.TakeDamage(AttackPower);
    }

    // Method to handle damage taken
    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} has been defeated!");
        }
    }
}