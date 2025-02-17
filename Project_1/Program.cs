LootGenerator lootSystem = new LootGenerator();
while (true)
{
    Console.Clear();
    Choosloot();
}

void Choosloot()
{
    string ChosenRarety;
    int ChosenRaretyInt = 1;
    Boolean HasChoosen = false;

    while (HasChoosen == false)
    {
        Console.WriteLine("Chose a rarety to be dropt");
        Console.WriteLine("Writa a number between 1 and 5");
        ChosenRarety = Console.ReadLine();
        ChosenRaretyInt = ParseStringToInt(ChosenRarety);
        if (ChosenRaretyInt <= 5 && ChosenRaretyInt >= 1)
        {
            HasChoosen = true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Wrong, try again");
        }
    }
    List<Item> loot = lootSystem.GenerateLoot(ChosenRaretyInt);

    Console.WriteLine("Generated Loot:");
    PrintLoot(loot);
    Console.ReadKey();
}

static void PrintLoot(List<Item> loot)
{
    foreach (var item in loot)
    {
        Console.WriteLine($"- {item.Name} ({item.GetStats()})");
    }
}
static int ParseStringToInt(string input) // parses a string into a int
{
    int result;
    if (int.TryParse(input, out result))
    {
        return result;
    }
    return 0;
}
