using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class UndeadWolf : ICharacter, IEnemy
    {
        public bool IsPlayer
        {
            get
            {
                return false;
            }
        }
        public int Health { get; set; } = 100;
        public AttackType AttackType
        {
            get
            {
                return AttackType.UnearthlyHowl;
            }
        }

        public EnemyType EnemyType
        {
            get
            {
                return EnemyType.UndeadWolf;
            }
        }
        public bool HasSwiftness
        {
            get
            {
                return true;
            }
        }
        public string Name
        {
            get
            {
                return "Undead Wolf";
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
