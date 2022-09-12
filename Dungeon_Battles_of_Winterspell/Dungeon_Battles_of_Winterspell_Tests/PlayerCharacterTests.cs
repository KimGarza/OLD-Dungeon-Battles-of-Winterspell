using Dungeon_Battles_of_Winterspell;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dungeon_Battles_of_Winterspell_Tests
{
    [TestClass]
    public class PlayerCharacterTests
    {
        [TestMethod]
        public void TestAttributesChangeBasedOnPlayerType()
        {
            // Arrange
            PlayerCharacter dwarfTest = new PlayerCharacter(CharacterType.Dwarf); // Determining factor of attributes is constructor
            int expectedStr = 4; // for dwarf

            // Act
            int result = dwarfTest.Strength;

            // Assert
            Assert.AreEqual(expectedStr, result);
        }

    }
}
