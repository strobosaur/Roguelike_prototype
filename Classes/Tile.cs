using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRoguelike.Classes
{
    public class Tile
    {
        public string Name { get; set; }
        public string ImageCharacter { get; set; }
        public ConsoleColor Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsWall { get; set; }

        public Tile() { }

        public Tile(int x, int y)
            : base()
        {
            this.X = x;
            this.Y = y;
            ImageCharacter = Constants.TileImage;
            Color = Constants.TileColor;
            IsWall = false;
        }
    }

    public class Wall : Tile
    {
        public Wall(int x, int y)
            : base(x, y)
        {
            ImageCharacter = Constants.WallImage;
            this.Color = Constants.WallColor;
            IsWall = true;
        }
    }
}
