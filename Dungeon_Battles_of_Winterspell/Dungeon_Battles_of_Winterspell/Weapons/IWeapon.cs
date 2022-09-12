using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public enum WeaponType
    {
        SteelSplitHammer,
        DoubleBladedAxe,
        OrnateShortSword,
        OakCarvedWand,
        GnarledBranchStaff,
        DualEtherealDaggers,
        ShortErnestBowAndQuiver,
        IvoryLongBowAndQuiver,
        ElvenLongsword,
    }
    public interface IWeapon
    {
        public WeaponType WeaponType { get; }
        public string Name { get; }
    }
}
