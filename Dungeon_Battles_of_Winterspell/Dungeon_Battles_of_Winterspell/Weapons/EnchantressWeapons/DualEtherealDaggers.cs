using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Weapons.EnchantressWeapons
{
    public class DualEtherealDaggers : IPlayerWeapon
    {
        public WeaponType WeaponType
        {
            get
            {
                return WeaponType.DualEtherealDaggers;
            }
        }

        public string Name
        {
            get
            {
                return "Dual Ethereal Daggers";
            }
        }

        public string Attack1
        {
            get
            {
                return "Wind of Furry";
            }
        }
        public string Attack2
        {
            get
            {
                return "Dual Stab";
            }
        }
        public Attack BuildAttack1(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.WindOfFurry,
                "Wind of Furry",
                "a highly precise and powerful slash to a single enemy target",
                100, 99..100, 100, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
        public Attack BuildAttack2(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.DualStab,
                "Dual Stab",
                "a practice of the lessons, taught by the elders of the homeland.",
                30, 22..30, 60, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
    }
}
