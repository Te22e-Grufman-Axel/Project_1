using System;
using System.Collections.Generic;

public class Game
{
    private Hero player;
    private Room currentRoom;
    private Dictionary<(int, int), Room> dungeonMap = new Dictionary<(int, int), Room>();
    private int playerX = 0;
    private int playerY = 0;
    private int depth = 0; 

    public void StartGame()
    {
        Console.Write("Enter your hero's name: ");
        string name = Console.ReadLine();
        player = new Hero(name, 100, 10);
        Console.WriteLine($"Welcome, {player.Name}! Your adventure begins.");
        EnterRoom();
    }

    private void EnterRoom()
    {
        if (!dungeonMap.ContainsKey((playerX, playerY)))
        {
            dungeonMap[(playerX, playerY)] = new Room(depth, playerX, playerY, dungeonMap);
        }

        currentRoom = dungeonMap[(playerX, playerY)];
        currentRoom.DisplayRoomDetails();

        HandleRoomActions();
    }

    private void HandleRoomActions()
    {
        while (true)
        {
            Console.WriteLine("\nWhat do you want to do? (fight, loot, move, exit)");
            string command = Console.ReadLine().ToLower();

            if (command == "fight" && currentRoom.Monsters.Count > 0)
            {
                Fight();
            }
            else if (command == "loot" && currentRoom.Type == RoomType.Loot && currentRoom.Loot.Count > 0)
            {
                Loot();
            }
            else if (command.StartsWith("move"))
            {
                string[] parts = command.Split(' ');
                if (parts.Length > 1)
                {
                    Move(parts[1]);
                    break; 
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
                Console.WriteLine("Invalid action or nothing to do.");
            }
        }
    }

    private void Fight()
    {
        while (currentRoom.Monsters.Count > 0)
        {
            Console.WriteLine($"You attack the {currentRoom.Monsters[0].Name}!");
            currentRoom.Monsters[0].TakeDamage(player.AttackPower);

            if (currentRoom.Monsters[0].IsDefeated)
            {
                Console.WriteLine($"You defeated the {currentRoom.Monsters[0].Name}!");
                currentRoom.Monsters.RemoveAt(0);
            }
            else
            {
                Console.WriteLine($"The {currentRoom.Monsters[0].Name} attacks you!");
                player.TakeDamage(currentRoom.Monsters[0].AttackPower);
            }

            if (player.IsDefeated)
            {
                Console.WriteLine("You have died... Game Over.");
                Environment.Exit(0);
            }
        }

        Console.WriteLine("All enemies defeated!");
    }

    private void Loot()
    {
        Console.WriteLine("You search the room and find:");
        foreach (var item in currentRoom.Loot)
        {
            Console.WriteLine($"- {item.Name}");
            player.Inventory.Add(item);
        }
        currentRoom.Loot.Clear();
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
}

