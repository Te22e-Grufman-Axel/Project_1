public class Hero : Character
{
    public Weapon EquippedWeapon { get; private set; }

    // Constructor
    public Hero(string name, int health, int attackPower) : base(name, health, attackPower) { }

    // Method to equip a weapon and increase attack power
    public void EquipWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
        AttackPower += weapon.Damage;
        Console.WriteLine($"{Name} equipped {weapon.Name}, increasing attack power to {AttackPower}!");
    }
}