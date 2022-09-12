using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class HauntingSpirit : ICharacter, IEnemy
    {
        public bool IsPlayer
        {
            get
            {
                return false;
            }
        }
        public int Health { get; set; } = 45;
        public AttackType AttackType
        {
            get
            {
                return AttackType.Spooky;
            }
        }

        public EnemyType EnemyType
        {
            get
            {
                return EnemyType.HauntingSpirit;
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
                return "Haunting Spirit";
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
