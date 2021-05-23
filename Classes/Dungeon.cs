using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace SimpleRoguelike.Classes
{
    class Dungeon
    {
        Random r;
        CMGenerator cmg;

        public Player player;
        List<Monster> monsters;
        List<Sword> swords;
        List<Wall> walls;
        List<Tile> floors;

        public int[,] Map;
        public Tile[,] Tiles;
        private int xMax;
        private int yMax;
        public enum Direction
        {
            East,
            North,
            West,
            South
        }

        public Dungeon(int xMax, int yMax)
        {
            r = new Random();
            CMGenerator cmg = new CMGenerator();
            monsters = new List<Monster>();
            swords = new List<Sword>();
            walls = new List<Wall>();
            floors = new List<Tile>();

            this.xMax = xMax;
            this.yMax = yMax;
            //Tiles = new Tile[xMax, yMax];
            Map = cmg.GenerateMap(xMax, yMax, 47, 10);
            Tiles = FillTileGrid(Map);
            player = new Player(GetRandomEmptyTile());
            SetDungeonTiles();
        }

        public void DrawDungeonToConsole()
        {
            Console.Clear();

            for(int y = 0; y < Tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tiles.GetLength(0); x++)
                {
                    Console.ForegroundColor = Tiles[x, y].Color;
                    Console.Write(Tiles[x, y].ImageCharacter);
                }

                Console.WriteLine();
            }
        }

        public Tile[,] FillTileGrid(int[,] map)
        {
            Tile[,] tileMap = new Tile[map.GetLength(0), map.GetLength(1)];

            for (int y = 0; y < tileMap.GetLength(1); y++)
            {
                for (int x = 0; x < tileMap.GetLength(0); x++)
                {
                    if (map[x, y] == 1)
                    {
                        Wall w = new Wall(x, y);
                        tileMap[x, y] = w;
                        walls.Add(w);
                    }
                    else
                    {
                        Tile t = new Tile(x, y);
                        tileMap[x, y] = t;
                        floors.Add(t);
                    }
                }
            }

            // RETURN TILEMAP
            return tileMap;
        }

        public void SetDungeonTiles()
        {
            walls.ForEach(w => Tiles[w.X, w.Y] = w);
            floors.ForEach(f => Tiles[f.X, f.Y] = f);
            Tiles[player.X, player.Y] = player;
        }

        public bool IsGameActive = true;

        public Point GetRandomEmptyTile()
        {
            int rand1 = r.Next(0, floors.Count);
            Point p = new Point();
            p.X = floors[rand1].X;
            p.Y = floors[rand1].Y;

            return p;
        }

        public string ExecuteCommand(ConsoleKeyInfo command)
        {
            string commandResult = ProcessCommand(command);
            ProcessMonsters();
            SetDungeonTiles();

            return commandResult;
        }

        private void ProcessMonsters()
        {
            if((monsters != null) && (monsters.Count > 0))
            {

            }
        }

        public string ProcessCommand(ConsoleKeyInfo command)
        {
            string output = string.Empty;
            switch (command.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    output = GetNewLocation(command, new Point(player.X, player.Y));
                    break;

                case ConsoleKey.F1:
                    output = Constants.NoHelpText;
                    break;
                case ConsoleKey.R:
                    IsGameActive = false;
                    break;
            }

            return output;
        }

        private string GetNewLocation(ConsoleKeyInfo command, Point move)
        {
            switch (command.Key)
            {
                case ConsoleKey.UpArrow:
                    move.Y -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    move.Y += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    move.X -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    move.X += 1;
                    break;
            }

            if (!IsInvalidMove(move.X, move.Y))
            {
                player.X = move.X;
                player.Y = move.Y;

                return Constants.OKCommandText;
            }
            else
                return Constants.InvalidMoveText;
        }

        public bool IsInvalidMove(int x, int y)
        {
            return (Tiles[x, y].IsWall);
        }
    }
}
