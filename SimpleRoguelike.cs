using SimpleRoguelike.Classes;
using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace SimpleRoguelike
{
    class SimpleRoguelike
    {
        static void Main(string[] args)
        {
            bool runGame = true;
            while (runGame)
            {
                Dungeon dungeon = new Dungeon(Constants.DungeonWidth, Constants.DungeonHeight);
                string displayText = "Welcome to the dungeon";

                while (dungeon.IsGameActive)
                {
                    dungeon.DrawDungeonToConsole();
                    Console.Write(displayText);
                    displayText = dungeon.ExecuteCommand(Console.ReadKey());
                }
            }
        }
    }
}
