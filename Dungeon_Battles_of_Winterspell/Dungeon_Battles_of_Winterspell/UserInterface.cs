using DungeonBattles_Of_Winterspell.DisplayText;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public class UserInterface
    {
        private IPlayerWeapon weapon;
        TypeEffect typeEffect = new TypeEffect();

        public PlayerCharacter Player { get; }

        /// <summary>
        /// Displays the menu of character choices. Once a player has selected a character, there will be remarking text and a character type will be set.
        /// Returns a charType which represents the CharacterType enum of which the player has chosen.
        /// Provides this charType to the character creation method in the game class
        /// </summary>
        /// <returns></returns>
        public CharacterType DisplayCharacterSelect()
        {
            // Establishing the type of character the player chooses. Starts in an uknown state. Changes based upon player selection.
            CharacterType charType = CharacterType.Uknown;

            bool valid = true;
            while (valid)
            {
                int userInput = CLIHelper.GetInteger("    Choose your class\n\n    1 - Dwarf    2 - Enchantress    3 - Woodelf:   ");
                switch (userInput)
                {
                    case 1:
                        charType = CharacterType.Dwarf;
                        typeEffect.TypedText("Aw, what an adoarable gnome!", true);
                        Console.ReadLine();
                        typeEffect.TypedText("Okay, okay calm down, I was only jesting!", true);
                        Console.ReadKey();
                        valid = false;
                        break;
                    case 2:
                        charType = CharacterType.Enchantress;
                        typeEffect.TypedText("You posses the Thaumaturgy of the ancient world within you.", true);
                        Console.ReadKey();
                        valid = false;
                        break;
                    case 3:
                        charType = CharacterType.Woodelf;
                        typeEffect.TypedText("From the Halls of Miritar, you venture, where the ruins of Myth Drannor await your return.", true);
                        Console.ReadKey();
                        valid = false;
                        break;
                    default:
                        Console.Clear();
                        typeEffect.TypedText("Please take this seriously.", true);
                        valid = true;
                        break;
                }
            }
            return charType;
        }

        public IPlayerWeapon DisplayWeaponsAndSelect(IPlayerWeapon[] weapons)
        {
            Console.Clear();
            // A while loop to continue redisplaying weapon options and the request of a choice if the user would make an incorrect int.
            bool valid = true;
            while (valid)
            {
                Console.WriteLine($"    Choose your weapon");
                int i = 1; // Menu numbering purposes
            foreach (IPlayerWeapon weapon in weapons)
            {
                    
                // i represents and int 1 - 3 for the value of player selection.
                Console.WriteLine($"    {i})   {weapon.Name}");
                    i++;
            }
                int userInput = CLIHelper.GetInteger($"    Your weapon sire:  ");
                switch (userInput)
                {
                    // Each weapons[i], i represents the key to correspond with the int input. That equates the local field weapon variable to become the Weapon value associated with that key.
                    case 1:
                        weapon = weapons[0]; // Same as IWeapon weapon = new Weapon(); weapon is now = to the user selected weapon from the dictionary.
                        valid = false;
                        break;
                    case 2:
                        weapon = weapons[1];
                        valid = false;
                        break;
                    case 3:
                        weapon = weapons[2];
                        valid = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("These are the only weapons fit for you from the armoury, please make your choice.");
                        valid = true;
                        break;
                }
            }
            Console.WriteLine($"The {weapon.Name}, an ardent choice!"); // weapon is a public field that has been set to the user's weapon choice.
            Console.ReadKey();
            

            // The player has made their choice.
            return weapon;
        }

        /// <summary>
        /// Here, the player will allocate 10 skill points and choose which attributes to add them to as well as how many.
        /// Takes in a player, so player object stays the same, and player attribute properties can be updated according to user input.
        /// </summary>
        /// <param name="player"></param>
        public bool AllocateAttributes(PlayerCharacter player)
        {
            Console.Clear();
            int remainingPoints = 10; // The remaining points regardless of the user's input. Declared at 10 but updates based on math within the while statement.
            //int currAttributeStatus; // This is the player's attribute (str, int, dex points) property within the PlayerCharacter class, represented as an int.
            // int defaultAttributeStat; // This is the players default standard point amount, this is to enforce that however many points were origonally allocated, cannot be taken away. Doesn't work for now as const is not viable here yet.
            // While the user still has points to spend, continue to prompt which attribute to allocate points to, and how many. CLI Helper will take care of the validity of the points.
            while (remainingPoints != 0) // This screen reapears after each allocation of points, but the variables in the strings will be updated. This is for viewing clarity and lack of clutter on screen.
            {
                Console.WriteLine($"    You have {remainingPoints} points left to allocate into each attribute, please assign your skill points");
                Console.WriteLine();
                Console.WriteLine($"    1) Strength: {player.Strength}        2) Intelligence: {player.Intelligence}         3) Dexterity: {player.Dexterity}"); // Each attribute will reveal the updated PlayerCharacter attribute prop count.

                int userInput = CLIHelper.GetInteger("    Which attribute would you like to assign points to?:   "); // User choses from the attribute list of str, int or dex to where to assign points.

                switch (userInput)
                {
                    case 1: // Strength
                        remainingPoints = AllocateStrength(remainingPoints, player);
                        break;

                    case 2: // Intellegence
                        remainingPoints = AllocateIntellegence(remainingPoints, player);
                        break;

                    case 3: // Dexterity
                        remainingPoints = AllocateDexterity(remainingPoints, player); // Dexterity points allocation
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("    Please choose an attribute to adjust"); // This will cause the message to display above and have the user re-enter their choice.
                        break;
                }
            }

            Console.WriteLine($"    Strength: {player.Strength}     Intellegence: {player.Intelligence}     Dexterity: {player.Dexterity}");
            bool userHappy = CLIHelper.GetBool("    These are your current skill point totals, are you happy with them? Y/N:  ");
            
            if (userHappy)
            {
                return true; // Yes, leave the menu.
            }
            else
            {
                // Erase history of method. Re-write character attributes and corresponding info.
                player.EstablishAllTraits();
                Console.WriteLine("    You may start again.");
                Console.ReadKey();
                return false; // No, do NOT leave menu. When the last method read sees the return, it will  restart the last menu and let the user redo everything.
            }
        }

        public int AllocateStrength(int remainingPoints, PlayerCharacter player)
        {
            int currAttributeStatus = player.Strength; // THE PLAYER'S CURRENT STR ATTRIBUTE AMOUNT. (**  For later purposes - a note - When this is first read, it will be the default of the player's attribute. Passing it into a new constant int.)

            // A dictionary holding KEY: updated remaining points, VALUE: userInput (as an int).                                                            //const int defaultStrength = currAttributeStatus; NOT A WAY TO FIND THE DEFAULT STRENGTH UNLESS AN ACCESSIBLE PROPERTY IS PROVIDED IN CLASS.
            Dictionary<int, int> strPointsBookRS = CLIHelper.GetPoints("    How much would you like to assign to strength?:   ", currAttributeStatus, remainingPoints, "strength"); // remaining points was 10 at the start.
            int strInput = 0; // Declaring purposes to pull the value of the user input from the pointsBook and add it to the strength attribute.
            foreach (KeyValuePair<int, int> allocation in strPointsBookRS) // Looping through dictionary to pull the key/value into their own variables for updaing purposes.
            {
                player.Strength += allocation.Value; // Updating player strength.
                remainingPoints = allocation.Key; // Updating remaining points local variable.
                strInput = allocation.Value; // Updating user's int input into variable.
            }
            Console.WriteLine();
            Console.WriteLine($"    You have chosen to allocte {strInput} points into strength. You have {remainingPoints} points left to spend.");

            Console.ReadKey();
            Console.Clear();
            return remainingPoints;
        }
        public int AllocateIntellegence(int remainingPoints, PlayerCharacter player)
        {
            int currAttributeStatus = player.Intelligence; // THE PLAYER'S CURRENT INT ATTRIBUTE AMOUNT.

            Dictionary<int, int> intPointsBookRS = CLIHelper.GetPoints("    How much would you like to assign to intelligence?:   ", currAttributeStatus, remainingPoints, "intellegence");
            int intInput = 0; // Declaring purposes to pull the value of the user input from the pointsBook and add it to the strength attribute.
            foreach (KeyValuePair<int, int> allocation in intPointsBookRS) // Looping through dictionary to pull the key/value into their own variables for updaing purposes.
            {
                player.Intelligence += allocation.Value; // Updating player strength.
                remainingPoints = allocation.Key; // Updating remaining points local variable.
                intInput = allocation.Value; // Updating user's int input into variable.
            }
            Console.WriteLine();
            Console.WriteLine($"    You have chosen to allocte {intInput} points into intellegence. You have {remainingPoints} points left to spend.");

            Console.ReadKey();
            Console.Clear();
            return remainingPoints;
        }
        public int AllocateDexterity(int remainingPoints, PlayerCharacter player)
        {
            int currAttributeStatus = player.Dexterity; // THE PLAYER'S CURRENT DEX ATTRIBUTE AMOUNT.

            Dictionary<int, int> dexPointsBookRS = CLIHelper.GetPoints("    How much would you like to assign to dexterity?:   ", currAttributeStatus, remainingPoints, "dexterity");
            int dexInput = 0; // Declaring purposes to pull the value of the user input from the pointsBook and add it to the strength attribute.
            foreach (KeyValuePair<int, int> allocation in dexPointsBookRS) // Looping through dictionary to pull the key/value into their own variables for updaing purposes.
            {
                player.Dexterity += allocation.Value; // Updating player strength.
                remainingPoints = allocation.Key; // Updating remaining points local variable.
                dexInput = allocation.Value; // Updating user's int input into variable.
            }
            Console.WriteLine();
            Console.WriteLine($"    You have chosen to allocte {dexInput} points into dexterity. You have {remainingPoints} points left to spend.");

            Console.ReadKey();
            Console.Clear();
            return remainingPoints;
        }

        /// <summary>
        /// Displays the map.
        /// </summary>
        /// <param name="dungeons"></param>
        public void Map(List<Dungeon> dungeons, string worldName)
        {
            int num = 0;
            string currDungeon = ""; // For display purposes
            Console.WriteLine();
            Console.Write($"{worldName}   -->  ");
            foreach (Dungeon dungeon in dungeons)
            {
                if (dungeon.IsCurrent)
                {
                    currDungeon = dungeon.DisplayName;
                }
                if (num == 3)
                {
                    Console.Write("\n");
                }
                Console.Write($"{dungeon}...  ");
                num++;
            }
            Console.ReadLine();
            typeEffect.TypedText("\nYou have made a discovery! Your next dungeon is revealed before you: " + currDungeon, true);
            Console.ReadLine();
        }

        public void DungeonComplete()
        {
            Console.WriteLine("You have completed the dungeon!");
        }

        public void DisplayCombatMenu(Queue<ICharacter> turnQueue, PlayerCharacter player)
        {
            // Info regarding the turn Queue
            Console.Clear();
            string full = "Turn Order\n";
            string chara;
            foreach (ICharacter character in turnQueue)
            {
                if (character.IsPlayer)
                {
                    full += "You";
                }
                else
                {
                    chara = $"{character}\n";
                    full += chara;
                }
            }
            Console.WriteLine(full);
            Console.WriteLine();

            // Display Character Stats on opposite side of the screen
         
            Console.WriteLine($"Hp: {player.Health}\nWeapon:) {player.Weapon.Name}\nAttack 1:) {player.Weapon.Attack1}\nAttack 2:) {player.Weapon.Attack2}");
            Console.WriteLine();
        }
    }

    
}
