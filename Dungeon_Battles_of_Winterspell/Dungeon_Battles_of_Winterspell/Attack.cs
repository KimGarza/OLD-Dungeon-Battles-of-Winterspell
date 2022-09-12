using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public enum AttackType // There are so many b/c this enum will be shared by the ICharacter interface
    {
        // Dwarf
        StrikeOfThunderAndSteele, // hammer
        WoundingSkullCruncher, // hammer
        MightyCleave, // axe
        AgedSlicedServed, // axe
        DoubleSwing, // short sword
        GutWrencher,

        // Enchantress
        DarkCharm, // want
        AncientIncantation, // want
        BrewedStorm, // staff
        FireBeacon, // staff
        WindOfFurry, // daggars
        DualStab, // daggars

        // Woodelf
        PiercingArrow,
        FletchersFolley,
        SnipersMark,
        MajesticVolley,
        ElegantDivide,
        TeachingsOfTheElders,

        // Enemy
        ClubSmack,
        MightyChomp,
        LavaSpit,
        FrailSwordStrike,
        Spooky,
        UnearthlyHowl,
        PowerfulPunchAndWereNotTalkingFruit,
        Unknown
    }
    public class Attack
    {
        /// <summary>
        /// This constructor's purpose is to be able to create a new attack in full minus the derived functionality dependent on these properties. In each Weapon inherited class which is a specific weapon name/type.
        /// When the methods of Attack1 and Attack2 are used, they create a brand new attack each time, and create it based on the expected attack which is always going to be the same two per each weapon.
        /// </summary>
        /// <param name="attackType"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="maxDamage"></param>
        /// <param name="damageRange"></param>
        public Attack (AttackType attackType, string name, string description, int maxDamage, Range damageRange, int chanceToHit, bool isAOE)
        {
            this.AttackType = attackType;
            this.Name = name;
            this.Description = description;
            this.MaxDamage = maxDamage;
            this.DamageRange = damageRange;
            this.ChanceToHit = chanceToHit / 100; // Will be used as a percentage
        }

        public int ChanceToHit { get; }
        public AttackType AttackType { get; }

        public string Name { get; }
        public string Description { get; }

        public int MaxDamage { get; } // For purposes of crit

        public float CritChance { get; } // This will be if the attack lands on max damage
       
        public int DamageInflicted { get; private set; }

        public Range DamageRange { get; }

    }
}
