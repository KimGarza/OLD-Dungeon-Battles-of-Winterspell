using Dungeon_Battles_of_Winterspell.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public class Room
    {
        public Room (DungeonType dungeonType)
        {
            this.DungeonType = dungeonType;
        }
        public Room ()
        {

        }
        public bool IsCleared { get; private set; }

        public DungeonType DungeonType { get; set; }
        public string Names
        {
            get
            {
                // Creates a list of room names and descriptions based upon which is the dungeon type.
                string[] roomNames = new string[7]; // There will always be the same amount of room names per dungeon type.

                if (DungeonType == DungeonType.StilagmiteRuins)
                {
                    // Adding a set of room names to the array
                    roomNames = new string[]
                    {
                        "a freezing cave",
                        "a cavern with intense anger",
                        "a room that catches the moon's light",
                        "a dampened forgotten stalactite cave",
                        "an abhorrent depth",
                        "a claustrophobic tight space",
                        "a haunting passage"
                    };
                }
                // More dependent options listed here.

                Random rnd = new Random();
                int rngNum = rnd.Next(0, 8); // Creates a number between 0 and 7 inclusive representing indexes of the arrays.
                string name = roomNames[rngNum]; // Equates the property roomName to what a random index is the array (which is dependent on the dungeon type).
                return name;
            }
        }

        // Method within the class sets this list of a few enemies + player to be in an accurate turn based queue.
        public Queue<ICharacter> TurnQueue { get; private set; }

        /// <summary>
        /// Returns an IEnemy. IEnemy is implemented on each specific enemy class. First a list is made to hold all IEnemies.
        /// The list is randomized, the converted into an array. For extra RNG POWER, a number to represent the index is randomized and then used to pick an enemy at random.
        /// That random new enemy is returned. This is for the purpose of spawning random enemies in rooms.
        /// </summary>
        /// <returns></returns>
        public IEnemy RandomizeEnemy()
        {
            // creating a list of all members of IEnmies. Must be a list b/c need to add individ enemy classes
            List<IEnemy> enemies = new List<IEnemy>();
            enemies.Add(new Firespitter());
            enemies.Add(new Troll());
            enemies.Add(new Goblin());

            // Randomize the list, so an enemy pulled will be random
            Random random = new Random();
            enemies.OrderBy(i => random.Next());
            IEnemy[] enemiesArr = enemies.ToArray();

            Random rnd = new Random();
            int rngNum = rnd.Next(0, 3); // Creates a number between 0 and 7 inclusive representing indexes of the arrays.
            IEnemy enemy = enemies[rngNum]; // Equates the enemy to whattype to a random index is the array of options for enemy types.
            return enemy;
        }

    
        /// <summary>
        /// Returns a queue of new ICharacters. First creates a list of enemies which are randomized, and the amount of enemies in the list is rng between 1 and 4 inclusive for however many will be added to the list.
        /// A loop will pick the random num of enemies to spawn. For each loop, a new random enemy will be generated. That enemy is cast as an ICharacter and added to a list of ICharacters.
        /// This should be called once the game state is new room, as enemies must be spawned in it. characters represents enemies spawned and the addition of the player character.
        /// See method TurnBasedQueue for how the turn queue is returned within this method.
        /// </summary>
        /// <returns></returns>
        public Queue<ICharacter> SpawnEnemies(PlayerCharacter player) // This will only occur when a new room is entered. Taking in player purely for the purpose of passing into next method.
        {
            List<ICharacter> characters = new List<ICharacter>(); // Empty list to add spawened enemies to.
            Random rnd = new Random();
            int rngNum = rnd.Next(1, 6);  // Creates a number between 1 and 5 inclusive. Only want 4 enemies to appear MAX.
            for (int i = 0; i < rngNum + 1; i++)
            {
                IEnemy enemy = RandomizeEnemy(); // This enemy should be randomly generated
                ICharacter enemyCharacter = (ICharacter)enemy; // Casting the enemy as an ICharacter. Should wrok since al of the enemies are ICharaters.
                characters.Add(enemyCharacter);
            }
            characters.Add(player); // Throw the player into the list.
            Queue<ICharacter> turnQueue = TurnBasedQueue(characters); // storing the returned turn based queue into the queue here for easier use of single method.
            return turnQueue;
        }

        /// <summary>
        /// The turnQueue returns a queue, which represents the order in which characters can have their turn in turn-based combat.
        /// Takes a list of enemies that spawened in a room (randomly generated type and quantity - 1-4), and the player, it generates first a list which is randomized. Then a queue is created adding first characters it sees which have swiftness.
        /// characters is not a list of enenmies or player specifically, it is the combination of both where their similarities are that they are both characters and can have swiftness.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemiesToFight"></param>
        /// <returns></returns>
        public Queue<ICharacter> TurnBasedQueue(ICollection<ICharacter> characters) // Expect to take a rng load of enemies, return them. Equate them to a list and then add them into a queue along with the character.
        {
            Queue<ICharacter> turnQueue = new Queue<ICharacter>(); // to return
            List<ICharacter> charactersToAdd = new List<ICharacter>(); // empty list of characters without swiftness, to be added into the queue after the swift characters are added.

            // First randomize the list, so radomizing does not need done after the queuing process.
            Random random = new Random();
            characters.OrderBy(i => random.Next()); // Like mixing in the player to the deck of enemies

            // Second, add to the queue, first players which have swiftness.
            foreach (ICharacter character in characters)
            {
                // Check for which characters have swiftness. Add to the queue first randomly.
                if (character.HasSwiftness)
                {
                    turnQueue.Enqueue(character); // add current character to the queue.
                }
                else
                {
                    charactersToAdd.Add(character);
                }
            }

            // Add the remaining
            foreach (ICharacter character in charactersToAdd)
            {
                turnQueue.Enqueue(character);
            }

            this.TurnQueue = turnQueue;
            return turnQueue;
        }
    }
}
