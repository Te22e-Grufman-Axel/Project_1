public class Game
{
    private Hero player;
    private Room currentRoom;
    private Dictionary<(int, int), Room> dungeonMap = new Dictionary<(int, int), Room>();
    private int playerX = 0;
    private int playerY = 0;
    private int depth = 0; // Tracks depth for difficulty scaling

    public void StartGame()
    {
        Console.Write("Enter your hero's name: ");
        string name = Console.ReadLine();
        player = new Hero(name, 100, 10);
        Console.WriteLine($"Welcome, {player.Name}! Your adventure begins.");
        EnterRoom(); // Start in the first room
        GameLoop();
    }

    private void EnterRoom()
    {
        if (!dungeonMap.ContainsKey((playerX, playerY)))
        {
            dungeonMap[(playerX, playerY)] = new Room(depth, playerX, playerY, dungeonMap);
        }

        currentRoom = dungeonMap[(playerX, playerY)];
        // Console.WriteLine($"You entered: {currentRoom.Description}");
        currentRoom.DisplayRoomDetails();
    }

    private void Move(string direction)
    {
        if (currentRoom.Exits.ContainsKey(direction))
        {
            (playerX, playerY) = currentRoom.Exits[direction];
            depth++;
            EnterRoom();
        }
        else
        {
            Console.WriteLine("You can't go that way.");
        }
    }

    private void GameLoop()
    {
        while (true)
        {
            Console.WriteLine("What do you want to do? (move north/south/east/west, exit)");
            string command = Console.ReadLine().ToLower();

            if (command.StartsWith("move"))
            {
                string[] parts = command.Split(' ');
                if (parts.Length > 1)
                {
                    Move(parts[1]);
                }
                else
                {
                    Console.WriteLine("Specify a direction (north, south, east, west).");
                }
            }
            else if (command == "exit")
            {
                Console.WriteLine("Exiting game...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}