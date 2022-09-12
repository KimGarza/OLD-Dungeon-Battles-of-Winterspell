using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Dungeon_Battles_of_Winterspell;
using DungeonBattles_Of_Winterspell;

namespace DungeonBattles_Of_Winterspell.DisplayText
{
    public class StoryText
    {
        //private UserInterface UI = new UserInterface();

        public void LoadingScreen()
        {
            bool repeat = true;
            int times = 0;
            while (repeat)
            {
                if (times == 2)
                {
                    repeat = false;
                }
                string text = "Loading.......";
                foreach (char character in text)
                {
                    //write out the characters to the screen.
                    Console.Write(character);
                    //speed of it beging typed out effect.
                    Thread.Sleep(200);
                }
                times++;
                Console.Clear();
            }
           
        }

        /// <summary>
        /// Begins the story and game. Asks a user if they wish to fight, returns a bool true for yes or false for no.
        /// </summary>
        public bool OpeningStoryText()
        {
            TypeEffect typingOutText = new TypeEffect();
            // Begin the story if game is commenced
            typingOutText.TypedText("Hello traveler! The Town of Winterspell has been overtaken by the dark creatures of the North, Goblins, the Undying and Trolls... Among other foul creatures of the deep.", true);
            //Wait for user to click enter to continue to next line. (This works but if user clicks enter while first line is being typed, it does not wait.
            Console.ReadLine();
            typingOutText.TypedText("They mean to destroy our resources, harbinge our foes and swallow our townsfolk.", true);
            Console.ReadLine();
            typingOutText.TypedText("Winter is come. We yet have been able to scurge the unholy creatures.....", true);
            Console.ReadLine();

            bool userInput;
            return userInput = CLIHelper.GetBool("Will you help fight? And save the town of Winterspell?(y/n): ");
        }

        public void WhoAreYou()
        {
            TypeEffect typingOutText = new TypeEffect();

            typingOutText.TypedText("Pray tell... Who are you?", true);
            Console.ReadLine();
            //UI.DisplayCharacterChoices();
        }

        public void ChooseWeapon()
        {
            TypeEffect typingOutText = new TypeEffect();
            Console.Clear();
            typingOutText.TypedText("Now, you can't go around fight gobgobs and the undead with just your bare hands...", true);
            Console.ReadLine();
        }

        public void PrepareForBattle()
        {
            TypeEffect typingOutText = new TypeEffect();
            Console.Clear();
            typingOutText.TypedText("Time for battle, off to the dugneons, here is your map: ", true);
            
        }

        /// <summary>
        /// Uses the current turn queue for the current room and establishes text based on what is available from list. It takes in the turn queue 
        /// provided from the game class. It explains what the player sees in the room.
        /// </summary>
        /// <param name="turnQueue"></param>
        public void NewRoomDepiction(Queue<ICharacter> turnQueue)
        {
            TypeEffect typingOutText = new TypeEffect();
            Console.Clear();
            // make how you entered a new room rng between different options.
            int enemiesInQueue = turnQueue.Count - 1; // How many total enemies in the queue
            int num = 1; // A counter to keep track of last enemy for purposes of displaying better
            // Perhaps add here later an rng statement about the foes.
            typingOutText.TypedText($"You have stumbled into a new room where you now faces the foes stood before you. Here in this room there is a ", true);
            foreach(ICharacter character in turnQueue)
            {
                if (character.IsPlayer) // If the current iteration is on the player (don't need to depict them)
                {
                    // Do nothing
                }
                else if (num == enemiesInQueue && enemiesInQueue > 1) // If this is the last enemy needing described but not if this is the only enemy described
                {
                    typingOutText.TypedText($"and {character/*.NameDepiction*/}...", true);
                }
                else if (enemiesInQueue == 1)
                {
                    typingOutText.TypedText($"{character/*.NameDepiction*/}...", true);
                }
                else
                {
                    // check that there is still a next character otherwise must not have an a at the end.
                    typingOutText.TypedText($"{character/*.NameDepiction*/}, ", true);
                    num++;
                }
                }
                typingOutText.TypedText("You breath the breath of courage, weapon tightly gripped....", true);
                Console.ReadLine();
                typingOutText.TypedText("Combat begins.", true);
                Console.ReadKey();
        }
            
        

    }
}
