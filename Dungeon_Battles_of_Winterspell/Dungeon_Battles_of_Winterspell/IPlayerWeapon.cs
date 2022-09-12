using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public interface IPlayerWeapon
    {
        public WeaponType WeaponType { get; }
        public string Attack1 { get; }
        public string Attack2 { get; }
        public string Name { get; }
        public Attack BuildAttack1(IEnmey targetEnemy);
        public Attack BuildAttack2(IEnmey targetEnemy);

    }
}
