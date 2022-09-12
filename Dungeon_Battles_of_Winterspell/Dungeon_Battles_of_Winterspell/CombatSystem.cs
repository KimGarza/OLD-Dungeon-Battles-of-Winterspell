using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public enum AttackTypes
    {
        SwordSwing
    }

    /// <summary>
    /// Manages the details of the attack damage output and types of chosen attacks.
    /// </summary>
    public class CombatSystem
    {
        /// <summary>
        /// Constructor takes in the type of attack being made, and based on it, the damage will be adjusted.
        /// </summary>
        /// <param name="attackType"></param>
        public CombatSystem()
        {

        }

        //public int EnemyInflictDamage(PlayerCharacter player, ICharacter enemy)
        //{
        //    enemy.Attac
        //}


        /// <summary>
        /// Takes in no arguments, returns an array with integers 1 through 25. Range represents possible damage.
        /// </summary>
        /// <returns></returns>
        public int[] DamageRange()
        {
            int[] range = new int[25];
            int num = 1;
            for (int i = 0; i < 25; i++)
            {
                range[i] = num;
                num++;
            }
            return range;
        }

        /// <summary>
        ///  Each Character Player gets two different attack types, they will get to choose between attack1 or attack2 during their turn. 
        ///  The returned Dictionary stores the attack type and the amount of damage (as a range). 
        /// </summary>
        /// <param name="attackType"></param>
        /// <param name="damageRange"></param>
        /// <returns></returns>
        public Dictionary<AttackType, IEquatable<Range>> Attack1 (AttackType attackType, IEquatable<Range> damageRange)
        {
            Dictionary<AttackType, IEquatable<Range>> attack = new Dictionary<AttackType, IEquatable<Range>>();
            int[] range = DamageRange(); // Array ints 1 through 25.

            // Have a dictionary which contains the attack name/type which will determine damage range. Take in that range and output it into the dictionary.
            // If the attack is this, make it have this range.
            if (attack.ContainsKey(AttackType.SnipersMark))
            {
                //damageRange = Range.EndAt(5);
                int[] currRange = range[0..2];

            }
            return attack;
        }
        public Dictionary<AttackType, int> Attack2 { get; set; }

        /// <summary>
        /// This method manages the 'attack', it adjusts damage based on the attack type.
        /// </summary>
        /// <returns></returns>
        //public int InflictDamage()
        //{
        //    if (Attack)
        //}

    }
}
