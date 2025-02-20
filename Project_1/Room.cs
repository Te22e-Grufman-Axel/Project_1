public class Room
{
    // public string Description { get; private set; }
    public Dictionary<string, (int, int)> Exits { get; private set; } = new Dictionary<string, (int, int)>();
    public List<Item> Loot { get; private set; }
    public List<Enemy> Monsters { get; private set; }
    public RoomType Type { get; private set; }
    private static Random random = new Random();
    LootGenerator lootGen = new LootGenerator();

    public Room(int depth, int x, int y, Dictionary<(int, int), Room> dungeonMap)
    {
        GenerateRoom(depth, x, y, dungeonMap);
    }

    private void GenerateRoom(int depth, int x, int y, Dictionary<(int, int), Room> dungeonMap)
    {
        // string[] descriptions = { "A dark cave", "A ruined temple", "A damp dungeon", "An abandoned library" };
        // Description = descriptions[random.Next(descriptions.Length)];
        int roomTypeRoll = random.Next(100);
        if (roomTypeRoll < 30)
        {
            Type = RoomType.Loot;
            Loot = lootGen.GenerateLoot(GetLootRarity(depth));
            Monsters = new List<Enemy>();
        }
        else if (roomTypeRoll < 70)
        {
            Type = RoomType.Monster;
            Monsters = GenerateRandomMonsters(depth);
            Loot = new List<Item>();
        }
        else
        {
            Type = RoomType.Mixed;
            Monsters = GenerateRandomMonsters(depth);
            Loot = lootGen.GenerateLoot(GetLootRarity(depth));
        }

        GenerateExits(x, y, dungeonMap);
    }

    private void GenerateExits(int x, int y, Dictionary<(int, int), Room> dungeonMap)
    {
        string[] directions = { "north", "south", "east", "west" };
        (int dx, int dy)[] deltas = { (0, -1), (0, 1), (1, 0), (-1, 0) };

        for (int i = 0; i < directions.Length; i++)
        {
            if (!dungeonMap.ContainsKey((x + deltas[i].dx, y + deltas[i].dy)))
            {
                Exits[directions[i]] = (x + deltas[i].dx, y + deltas[i].dy);
            }
        }
    }

    private List<Enemy> GenerateRandomMonsters(int depth)
    {
        List<Enemy> monsters = new List<Enemy>();
        int numberOfMonsters = random.Next(1, 2 + (depth / 3));

        for (int i = 0; i < numberOfMonsters; i++)
        {
            monsters.Add(MonsterGenerator.GenerateRandomMonster(depth));
        }

        return monsters;
    }

    private int GetLootRarity(int depth)
    {
        int baseRarity = 1 + (depth / 5);
        return Math.Min(baseRarity + random.Next(2), 5);
    }

    public void DisplayRoomDetails()
    {
        Console.WriteLine($"Room Type: {Type}");

        if (Loot.Count > 0)
        {
            Console.WriteLine("You found loot:");
            foreach (var item in Loot)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }

        if (Monsters.Count > 0)
        {
            Console.WriteLine("Monsters appear!");
            foreach (var monster in Monsters)
            {
                Console.WriteLine($"- {monster.Name} (HP: {monster.Health})");
            }
        }

        Console.WriteLine("Exits:");
        foreach (var exit in Exits)
        {
            Console.WriteLine($"- {exit.Key}");
        }
    }
}

public enum RoomType
{
    Loot,
    Monster,
    Mixed
}
