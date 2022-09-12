using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Weapons.WoodelfWeapons
{
    public class ElvenLongsword : IPlayerWeapon
    {
        public WeaponType WeaponType
        {
            get
            {
                return WeaponType.ElvenLongsword;
            }
        }

        public string Name
        {
            get
            {
                return "Elven Long Sword";
            }
        }

        public string Attack1
        {
            get
            {
                return "Elegant Divide";
            }
        }
        public string Attack2
        {
            get
            {
                return "Teachings of The Elders";
            }
        }
        public Attack BuildAttack1(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.ElegantDivide,
                "Elegant Divide",
                "a highly precise and powerful slash to a single enemy target",
                100, 99..100, 100, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
        public Attack BuildAttack2(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.TeachingsOfTheElders,
                "Teachings of The Elders",
                "a practice of the lessons, taught by the elders of the homeland.",
                30, 22..30, 60, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
    }
}
