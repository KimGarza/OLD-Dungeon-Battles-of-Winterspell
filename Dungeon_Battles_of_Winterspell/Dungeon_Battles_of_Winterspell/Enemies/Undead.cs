using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class Undead : ICharacter, IEnemy
    {
        public bool IsPlayer
        {
            get
            {
                return false;
            }
        }
        public int Health { get; set; } = 25;
        public AttackType AttackType
        {
            get
            {
                return AttackType.FrailSwordStrike;
            }
        }

        public EnemyType EnemyType
        {
            get
            {
                return EnemyType.Undead;
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
                return "Undead";
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
