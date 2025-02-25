public class Room
{
    public Dictionary<string, (int, int)> Exits { get; private set; } = new Dictionary<string, (int, int)>();
    public List<Item> Loot { get; private set; }
    public List<Enemy> Monsters { get; private set; }
    public RoomType Type { get; private set; }
    private static Random random = new Random();
    private static LootGenerator lootGen = new LootGenerator();

    public Room(int depth, int x, int y, Dictionary<(int, int), Room> dungeonMap)
    {
        GenerateRoom(depth, x, y, dungeonMap);
    }

    private void GenerateRoom(int depth, int x, int y, Dictionary<(int, int), Room> dungeonMap)
    {
        int roomTypeRoll = random.Next(100);
        if (roomTypeRoll < 30)
        {
            Type = RoomType.Loot;
            Loot = lootGen.GenerateLoot(depth);
            Monsters = new List<Enemy>();
        }
        else if (roomTypeRoll < 70)
        {
            Type = RoomType.Monster;
            Monsters = MonsterGenerator.GenerateMonsters(depth);
            Loot = new List<Item>();
        }
        else
        {
            Type = RoomType.Mixed;
            Monsters = MonsterGenerator.GenerateMonsters(depth);
            Loot = lootGen.GenerateLoot(depth);
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

    public void DisplayRoomDetails()
    {
        Console.WriteLine($"Room Type: {Type}");

        if (Loot.Count > 0)
        {
            Console.WriteLine("You see a chest with loot.");
        }

        if (Monsters.Count > 0)
        {
            Console.WriteLine("You see:");
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