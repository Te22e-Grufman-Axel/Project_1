using System.Diagnostics.Contracts;

class room
{
    private string roomType;
    private int LootRarety;
    private List<Enemy> EnemiesInRoom = [];

    public void EnterRoom(Hero hero)
    {

    }
    public int SearchRoom()
    {

        return LootRarety;
    }
    public Boolean SolvePuzzel()
    {

        return true;
    }

}