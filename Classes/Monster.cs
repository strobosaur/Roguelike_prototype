using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimpleRoguelike.Classes
{
    class Monster : Creature
    {
        public Monster(Point p)
        {
            ImageCharacter = Constants.MonsterImage;
            Color = Constants.MonsterColor;
        }
    }
}
