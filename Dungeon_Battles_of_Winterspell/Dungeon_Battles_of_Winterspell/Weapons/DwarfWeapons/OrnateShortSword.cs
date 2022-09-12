using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    class OrnateShortSword : IPlayerWeapon
    {
        public WeaponType WeaponType
        {
            get
            {
                return WeaponType.OrnateShortSword;
            }
        }

        public string Name
        {
            get
            {
                return "Ornate Short Sword";
            }
        }

        public string Attack1
        {
            get
            {
                return "Double Swing";
            }
        }
        public string Attack2
        {
            get
            {
                return "Gut Wrencher";
            }
        }
        public Attack BuildAttack1(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.DoubleSwing,
                "Double Swing",
                "a swing of the sword twice, with the ability to attack twice in one attack.",
                12, 7..12, 68, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
        public Attack BuildAttack2(IEnmey targetEnemy)
        {
            // attack type is strike of thunder and steel
            Attack attack = new Attack(AttackType.DoubleSwing,
                "Gut Wrencher",
                "a stab through the enemies ribs",
                30, 22..30, 60, false);
            return attack; // Based on info passed in, the attack class should calculate the damage total and such. Crit will occur if the attack hits and the dmg is relavant.
        }
    }
}
