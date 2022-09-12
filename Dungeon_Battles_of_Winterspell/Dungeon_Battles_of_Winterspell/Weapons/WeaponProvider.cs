using Dungeon_Battles_of_Winterspell.Weapons.EnchantressWeapons;
using Dungeon_Battles_of_Winterspell.Weapons.WoodelfWeapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell.Weapons
{
    public class WeaponProvider
    {
        /// <summary>
        /// Returns an ICollection<IWeapon> which will be a list of 3 weapons.
        /// The outcome of the list will depend on the character chosen.
        /// It then sends the dictionary built from the list over to display in the UI.
        /// </summary>
        /// <param name="charType"></param>
        /// <returns></returns>
        public IPlayerWeapon[] GetWeaponChoices(CharacterType charType) // must pass in player for next method.
        {
            List<IPlayerWeapon> weaponList = new List<IPlayerWeapon>();
            switch (charType)
            {
                case CharacterType.Dwarf:
                    weaponList.Add(new DoubleBladedAxe());
                    weaponList.Add(new SteelSplitHammer());
                    weaponList.Add(new OrnateShortSword());
                    break;
                case CharacterType.Enchantress:
                    weaponList.Add(new OakCarvedWand());
                    weaponList.Add(new GnarledBranchStaff());
                    weaponList.Add(new DualEtherealDaggers());
                    break;
                case CharacterType.Woodelf:
                    weaponList.Add(new ShortErnestBowAndQuiver());
                    weaponList.Add(new IvoryLongBowAndQuiver());
                    weaponList.Add(new ElvenLongsword());
                    break;
            }
            // Display the weapon choices
            IPlayerWeapon[] weaponArr = weaponList.ToArray();
            return weaponArr;
        }
    }
}
