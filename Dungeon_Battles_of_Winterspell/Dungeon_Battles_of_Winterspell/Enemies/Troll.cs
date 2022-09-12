using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class Troll : ICharacter, IEnemy
    {
        public bool IsPlayer
        {
            get
            {
                return false;
            }
        }
        public int Health { get; set; } = 65;
        public AttackType AttackType
        {
            get
            {
                return AttackType.MightyChomp;
            }
        }

        public EnemyType EnemyType
        {
            get
            {
                return EnemyType.Troll;
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
                return "Troll";
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
