using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class DungeonDweller: ICharacter, IEnemy
    {
        public bool IsPlayer
        {
            get
            {
                return false;
            }
        }

        public int Health { get; set; } = 40;
        public AttackType AttackType
        {
            get
            {
                return AttackType.PowerfulPunchAndWereNotTalkingFruit;
            }
        }

        public EnemyType EnemyType
        {
            get
            {
                return EnemyType.DungeonDweller;
            }
        }
        public bool HasSwiftness
        {
            get
            {
                return false;
            }
        }
        public string Name
        {
            get
            {
                return "Dungeon Dweller";
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
