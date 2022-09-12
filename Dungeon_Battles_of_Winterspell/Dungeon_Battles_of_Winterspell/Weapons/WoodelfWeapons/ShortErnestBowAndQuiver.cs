using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Weapons.WoodelfWeapons
{
    public class ShortErnestBowAndQuiver : IPlayerWeapon
    {
        /// <summary>
        /// Each time the player chooses to make an attack, it will take in an int, which was
        /// the player's input of attack 1 or 2. If int 1, perform a new attack of attack 1.
        /// If option 2, perform a new attack with attack 2. Each time that the player
        /// </summary>
        /// <param name="attackChoice"></param>

        public WeaponType WeaponType
        {
            get
            {
                return WeaponType.ShortErnestBowAndQuiver;
            }
        }

        public string Name
        {
            get
            {
                return "Short Ernest Bow and Quiver";
            }
        }

        public string Attack1
        {
            get
            {
                return "Piercing Arrow";
            }
        }
        public string Attack2
        {
            get
            {
                return "Fletchers Folley";
            }
        }
        public Attack BuildAttack1(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.PiercingArrow,
                "Piercing Arrow",
                "an arrow to peirce through the heart of the enemy.",
                11, 7..11, 68, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
        public Attack BuildAttack2(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.FletchersFolley,
                "Fletchers Folley",
                "a powerful attack by the hand of the elf which effects surrounding enemies to the target.",
                8, 6..8, 60, true);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
    }
}
