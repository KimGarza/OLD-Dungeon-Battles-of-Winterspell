using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{

    /// <summary>
    /// This class identifies the player and contains idle and updating properties to represent the character. The defaults will vary depended upon the player type enum passed into the con
    /// </summary>
    public class PlayerCharacter : ICharacter
    {
        /// <summary>
        /// Upon player having picked a character with user input, the enum of character type will be set. This will be passed into the character when created.
        /// PlayerCharacter knowing the CharacterType will determine every other aspect of calculation for the char.
        /// </summary>
        /// <param name="playerType"></param>
        public PlayerCharacter(CharacterType playerType) // constructor which takes in a player type.
        {
            this.PlayerType = playerType;
        }
        public PlayerCharacter()
        {

        } // empty constructor

        public bool IsPlayer
        {
            get
            {
                return true;
            }
        }
        public string Name 
        {
            get
            {
                switch (PlayerType)
                {
                    case CharacterType.Dwarf:
                        return "Dwarf";
                    case CharacterType.Enchantress:
                        return "Enchantress";
                    case CharacterType.Woodelf:
                        return "Woodelf";
                    default:
                        return null;
                }
            }
        } // Varies per character type enum
          // Current and updating health of character. The defualts vary depending on the character type.

        //public EnemyType EnemyType { get; } = EnemyType.NotEnemy; // Player is not an enemy. THIS IS REQUIRED FOR THE ATTACK IN ENEMY CLASS ICHARACTER CONTRACT
        public IPlayerWeapon Weapon { get; set; }
        
        public int Health { get; set; } = 100;

        /// <summary>
        /// Initial establishment of health upon character creation.
        /// </summary>
        public void  EstablishHealth()
        {
            int currHealth = this.Health;
            switch (PlayerType)
            {
                case CharacterType.Dwarf:
                    currHealth = 125;
                    break;
                case CharacterType.Enchantress:
                    currHealth = 110;
                    break;
                case CharacterType.Woodelf:
                    currHealth = 100;
                    break;
            }
            this.Health = currHealth;
        }

        // If true, player has the ability to be added to a turn queue of turn phase
        public bool HasSwiftness { get; set; } // Swiftness is based on the dexterity attribute. If it is 3 or higher, then the player does have swiftness. Might need to be private.

        /// <summary>
        /// This method checks the current amount of dex to determine if swiftness is true or not. This check should be performed immediately during char creation and after the player assigns attributes to their character.
        /// This is to avoid a readonly derrived property that cannot be changed once set.
        /// </summary>
        /// <returns></returns>
        public void CheckSwiftness()
        {
            if (Dexterity >= 5 || PlayerType == CharacterType.Woodelf)
            {
                HasSwiftness = true;
            }
            else
            {
                HasSwiftness = false;
            }
        }

        // Readonly so it can be passed in when the character is created using user input.
        public CharacterType PlayerType { get; }

        // What is the weapon object of the player?
        public IWeapon WeaponEquipped { get; set; }

        public int PotionCount { get; set; } = 1; // By default a player has 1 potion. A player can have up to 3 potions.

        /// <summary>
        /// All attributes have default values determined by their character type.
        /// </summary>
        public int Strength { get; set; } // Dwarf is most skilled in strength.

        public void EstablishStrength()
        {
            int strength = 0;
            switch (PlayerType)
            {
                case CharacterType.Dwarf:
                    strength = 4;
                    break;
                case CharacterType.Enchantress:
                    strength = 0;
                    break;
                case CharacterType.Woodelf:
                    strength = 0;
                    break;
            }
            Strength = strength;
        }
        public int Intelligence { get; set; } // Enchantress is most skilled in intelligence (magic).
        public void EstablishIntelligence()
        {
            int intelligence = 0;
            switch (PlayerType)
            {
                case CharacterType.Dwarf:
                    intelligence = 0;
                    break;
                case CharacterType.Enchantress:
                    intelligence = 3;
                    break;
                case CharacterType.Woodelf:
                    intelligence = 0;
                    break;
            }
            Intelligence = intelligence;
        }
        
        public int Dexterity { get; set; } // Woofelf is most skilled in Dexterity.

        public void EstablishDexterity()
        {
            int dexterity = 0;
            switch (PlayerType)
            {
                case CharacterType.Dwarf:
                    dexterity = 0;
                    break;
                case CharacterType.Enchantress:
                    dexterity = 1;
                    break;
                case CharacterType.Woodelf:
                    dexterity = 4;
                    break;
            }
            Dexterity = dexterity;
        }

        // Establish all attributes listed above
        public void EstablishAllTraits()
        {
            EstablishDexterity();
            EstablishIntelligence();
            EstablishStrength();
            CheckSwiftness();
        }

        /// <summary>
        /// Checks that the current health of the player when damage is taken, is not at or below 0. If it is not, return false. If yes, return true.
        /// </summary>
        /// <param name="currentHealth"></param>
        public bool IsDeadCheck(int currentHealth)
        {
            if (currentHealth <= 0)
            {
                return true;
            }
            else
            {
                // if the player is still alive, set the health = to the current health.
                this.Health = currentHealth;
                return false;
            }
        }
    }
}

