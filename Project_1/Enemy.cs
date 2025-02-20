public class Enemy : Character
{
    public bool IsDefeated { get; private set; } = false;

    // Constructor
    public Enemy(string name, int health, int attackPower) : base(name, health, attackPower) { }

    // Overridden method to handle damage and track if defeated
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (Health <= 0)
        {
            IsDefeated = true;
        }
    }
}