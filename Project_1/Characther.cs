using System.Runtime;

class Characther
{
    protected string name;
    protected int health = 100;
    protected int attack;
    protected int defense;
    private List<Item> inventory = [];



    public void Attac(Characther target)
    {
        target.TakeDamage(attack);
    }
    public void TakeDamage(int amount)
    {
        int damage = amount - defense;
        health = health - damage;
    }
    public Boolean isAlive()
    {
        if (health < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}