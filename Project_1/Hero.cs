public class Hero : Character
{
    public Weapon EquippedWeapon { get; private set; }
    public List<Item> Inventory { get; private set; } // Inventory list
    public bool IsDefeated => Health <= 0; // ✅ Now it's a property


    // Constructor
    public Hero(string name, int health, int attackPower) : base(name, health, attackPower)
    {
        Inventory = new List<Item>(); // Initialize the inventory
    }

    // Method to equip a weapon and increase attack power
    public void EquipWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
        AttackPower += weapon.Damage;
        Console.WriteLine($"{Name} equipped {weapon.Name}, increasing attack power to {AttackPower}!");
    }

    // Method to add an item to inventory
    public void AddToInventory(Item item)
    {
        Inventory.Add(item);
        Console.WriteLine($"{item.Name} added to inventory.");
    }

    // Method to remove an item from inventory
    public void RemoveFromInventory(Item item)
    {
        if (Inventory.Contains(item))
        {
            Inventory.Remove(item);
            Console.WriteLine($"{item.Name} removed from inventory.");
        }
        else
        {
            Console.WriteLine($"{item.Name} is not in your inventory.");
        }
    }

    // Method to display inventory contents
    public void ShowInventory()
    {
        Console.WriteLine("Inventory:");
        if (Inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }
    }
}
