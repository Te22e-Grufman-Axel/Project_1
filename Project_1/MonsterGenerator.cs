public static class MonsterGenerator
{
    private static Random random = new Random();
public static List<Enemy> GenerateMonsters(int depth)
{
    List<Enemy> monsters = new List<Enemy>();
    int numberOfMonsters = new Random().Next(1, 3 + depth / 3); // Adjust as needed

    for (int i = 0; i < numberOfMonsters; i++)
    {
        monsters.Add(new Enemy($"Monster {i + 1}", depth * 10, depth * 2));
    }

    return monsters;
}
}

