using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Enemies
{
    public class Goblin : ICharacter, IEnemy
    {

        public bool IsPlayer
        {
            get
            {
                return false;
            }
        }
        public int Health { get; set; } = 30;
        public AttackType AttackType
        {
            get
            {
                return AttackType.ClubSmack;
            }
        }

        public EnemyType EnemyType
        {
            get
            {
                return EnemyType.Goblin;
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
                return "Goblin";
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
