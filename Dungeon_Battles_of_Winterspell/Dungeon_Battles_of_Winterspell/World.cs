using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public class World
    {
        private Dungeon dungeon = new Dungeon();
        
        public string Name
        {
            get
            {
                return "Town of Winterspell";
            }
        }

        public void RevealDungeon()
        {
            
        }

        public  override string ToString()
        {
            return $"{Name}";
        }
    }
}
