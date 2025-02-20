public class LootGenerator
{
    private Random rand = new Random();
    private List<string> axeNames = new List<string>();
    private List<string> swordNames = new List<string>();
    private List<string> armorNames = new List<string>();
    private List<string> potionNames = new List<string>() 
    {
        "Health Potion", "Elixir of Life"
    };

    public LootGenerator()
    {
        LoadNamesFromFile("axe_names.txt", axeNames);
        LoadNamesFromFile("sword_names.txt", swordNames);
        LoadNamesFromFile("armor_names.txt", armorNames);
    }

    private void LoadNamesFromFile(string fileName, List<string> list)
    {
        if (File.Exists(fileName))
        {
            list.AddRange(File.ReadAllLines(fileName));
        }
        else
        {
            Console.WriteLine("Warning: {fileName} not found. Using default names.");
            list.Add("Unknown Item");
        }
    }

    public List<Item> GenerateLoot(int rarity)
    {
        List<Item> loot = new List<Item>();
        int itemCount = rand.Next(1, rarity + 1); 

        for (int i = 0; i < itemCount; i++)
        {
            int itemType = rand.Next(3); // 0 = Weapon, 1 = Armor, 2 = Potion

            if (itemType == 0)
            {
                loot.Add(GenerateWeapon(rarity));
            }
            else if (itemType == 1)
            {
                loot.Add(GenerateArmor(rarity));
            }
            else
            {
                loot.Add(GeneratePotion(rarity));
            }
        }

        return loot;
    }

    private Weapon GenerateWeapon(int rarity)
    {
        string name = GetRandomName(rand.Next(2) == 0 ? axeNames : swordNames);
        int damage = rand.Next(5 * rarity, 10 * rarity); // Rarity scales damage
        return new Weapon(name, damage);
    }

    private Armor GenerateArmor(int rarity)
    {
        string name = GetRandomName(armorNames);
        int defense = rand.Next(3 * rarity, 8 * rarity); // Rarity scales defense
        return new Armor(name, defense);
    }

    private Potion GeneratePotion(int rarity)
    {
        string name = GetRandomName(potionNames);
        int healAmount = rand.Next(10 * rarity, 20 * rarity); // Rarity scales healing
        return new Potion(name, healAmount);
    }

    private string GetRandomName(List<string> nameList)
    {
        if (nameList.Count > 0)
        {
            return nameList[rand.Next(nameList.Count)];
        }
        return "Unnamed Item";
    }
}