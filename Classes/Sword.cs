using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimpleRoguelike.Classes
{
    public class Sword : Tile
    {
        public Sword(Point p)
        {
            ImageCharacter = Constants.SwordImage;
            Color = Constants.SwordColor;
            X = p.X;
            Y = p.Y;
        }
    }
}
