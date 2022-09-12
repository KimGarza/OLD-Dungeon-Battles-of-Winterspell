using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class Firespitter : ICharacter, IEnemy
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
                return AttackType.LavaSpit;
            }
        }

        public EnemyType EnemyType
        {
            get
            {
                return EnemyType.Firespitter;
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
                return "Firespitter";
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
