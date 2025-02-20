public static class MonsterGenerator
{
    private static Random random = new Random();

    public static Enemy GenerateRandomMonster(int depth) //generats a randome monster
    {
        string[] names = { "Goblin", "Skeleton", "Orc", "Demon", "Zombie", "Lich", "Dragon" };
        int baseHealth = 10 + (depth * 3);
        int attackPower = 5 + (depth * 3);

        string name = names[random.Next(names.Length)];
        int health = baseHealth + random.Next(5, 15); 
        int attackPower2 = attackPower + random.Next(5, 15); 

        return new Enemy(name, health, attackPower2);
    }
}
