using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimpleRoguelike.Classes
{
    public class Player : Creature
    {
        public List<Sword> Inventory { get; set; }

        public Player(Point p)
        {
            ImageCharacter = Constants.PlayerImage;
            Color = Constants.PlayerColor;
            Inventory = new List<Sword>();
            X = p.X;
            Y = p.Y;
            Hits = Constants.StartingHitPoints;
        }
    }
}
