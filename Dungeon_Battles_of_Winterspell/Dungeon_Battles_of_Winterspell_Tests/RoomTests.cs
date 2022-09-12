using Dungeon_Battles_of_Winterspell;
using Dungeon_Battles_of_Winterspell.Enemies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell_Tests
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        public void TestingRandomizeEnemyActuallyReturnsAnIEnemy()
        {
            // Arrange
            Room sut = new Room();

            // Act
            IEnemy result = sut.RandomizeEnemy();

            // Assert
            Assert.IsNotNull(result);
        }

        // The purpose of this method is to maintain functionality of the random range.
        // If a new enemy is added, we will want this method to be updated to include it.
        [TestMethod]
        public void RandomizeEnemyFirstGeneratesProperArrayCount()
        {
            // Arrange
            Room sut = new Room();

            // Act
            IEnemy result = sut.RandomizeEnemy();

            // Assert
            Assert.Inconclusive();
        }

        [TestMethod]
        public void SpawnEnemiesReturnsAQueueWhichIncludesEnemyAndPlayer()
        {
            // Arrange
            Room sut = new Room();
            PlayerCharacter player = new PlayerCharacter();

            // Act
            Queue<ICharacter> result = sut.SpawnEnemies(player);

            // Assert
            Assert.IsTrue(result.Count > 1);
            Assert.IsTrue(result.Contains(player)); // The queue includes the player
        }

        [TestMethod]
        public void TurnBasedQueueProperlyOrdersICharactersInQueue()
        {
            // Arrange
            Room sut = new Room();
            // Setting the player to a character known for having swiftness immediately.
            PlayerCharacter player = new PlayerCharacter(CharacterType.Woodelf);
            // Generating a list with enemies and the player b/c no method returns an ICollection which current method being tested needs.
            List<ICharacter> list = new List<ICharacter>() // No enemy here should have swiftness, just player
            {
                new Goblin(), new Troll(), player
            };

            // Act
            player.CheckSwiftness();
            Queue<ICharacter> result = sut.TurnBasedQueue(list);
            // turning the result into an array in order to identify location of certain ICharacters by the index.
            ICharacter[] resultArr = result.ToArray(); 

            // Assert
            Assert.IsTrue(resultArr.Length == 3);
            Assert.IsTrue((resultArr[0] == player)); // I guess enque means add to the bottom of the pile, but pull first. Bottom is front of line.
        }

        [TestMethod]
        public void TestFunctionalityOfDequeingHasExpectedResult()
        {
            // Arrange
            Room sut = new Room();
            // Setting the player to a character known for having swiftness immediately.
            PlayerCharacter player = new PlayerCharacter(CharacterType.Woodelf);
            // Generating a list with enemies and the player b/c no method returns an ICollection which current method being tested needs.
            List<ICharacter> list = new List<ICharacter>() // No enemy here should have swiftness, just player
            {
                new Goblin(), new Troll(), player
            };

            // Act
            player.CheckSwiftness();
            Queue<ICharacter> result = sut.TurnBasedQueue(list);
            result.Dequeue();

            // Assert
            Assert.IsFalse(result.Contains(player));
        }
    }
}
