using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Weapons
{
    public class DoubleBladedAxe : IPlayerWeapon
    {
        public WeaponType WeaponType
        {
            get
            {
                return WeaponType.DoubleBladedAxe;
            }
        }

        public string Name
        {
            get
            {
                return "Double Bladed Axe";
            }
        }

        public string Attack1
        {
            get
            {
                return "Mighty Cleave";
            }
        }
        public string Attack2
        {
            get
            {
                return "Aged, Sliced and Served";
            }
        }

        public Attack BuildAttack1(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.MightyCleave,
                "Mighty Cleave",
                "a swipe of the axe horizontally to the surrounding enemies",
                12, 8..12, 80, true);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
        public Attack BuildAttack2(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.AgedSlicedServed,
                "Aged, Sliced and Served",
                "fine wedge cuts to the targeted enemy, if the hit is critical, he may be served on a wooden board with Dom Pérignon.",
                30, 22..30, 60, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
    }
}

