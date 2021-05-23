using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRoguelike.Classes
{
    public class Creature : Tile
    {
        public int Hits;
        public void Die()
        {
            Hits = 0;
        }
    }
}
