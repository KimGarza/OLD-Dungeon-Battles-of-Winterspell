using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public enum DungeonType
    {
        StilagmiteRuins,
        TenebrificDepths,
        HiddenRoomOfTheRestingDead,
        HozwardianKeep,
        RoomOfMoonlight,
        Undiscovered,
        Unknown
    }
    public class Dungeon
    {
        public Dungeon()
        {

        }
        public Dungeon(DungeonType dungeonType, string dungeonName)
        {
            this.Name = dungeonName;
            this.DungeonType = dungeonType;
        }

        // Name is set in the contstructor, it should always match the type enum (but with spaces)
        public string Name { get; }

        // Display name will reveal "Undiscovered" unless it is the current dungeon or completed
        public string DisplayName
        {
            get
            {
                if (IsCurrent || Completed)
                {
                    return this.Name;
                }
                else
                {
                    return "Undiscovered";
                }
            }
        }

        public bool IsCurrent { get; set; }

        public DungeonType DungeonType { get; set; } = DungeonType.Unknown; // Always will point to the correct dungeon name.

        public int RoomsRemaining { get; set; } = 5;

        // Whether or not the player has completed that dungeon
        public bool Completed { get; set; } = false;

        public List<Dungeon> GenerateDungeonsManually()
        {
            List<Dungeon> dungeons = new List<Dungeon>
            {
                new Dungeon(DungeonType.StilagmiteRuins, "Stilagmite Ruins"),
                new Dungeon(DungeonType.TenebrificDepths, "Tenebrific Depths"),
                new Dungeon(DungeonType.HiddenRoomOfTheRestingDead, "Hidden Room of The Resting Dead"),
                new Dungeon(DungeonType.HozwardianKeep, "Hozwardian Keep"),
                new Dungeon(DungeonType.RoomOfMoonlight, "Room of Moonlight")
            };
            return dungeons;
        }

        /// <summary>
        /// Takes in a list of dungeons and returns a dungeon. The list is a manually set list of dungeons from the Game class which are looped through here.
        /// It checks to see if the first dungeon is not complete and it sets it to current. Otherwise it will loop until it finds a dungeon that is marked as 
        /// IsCurrent, and will set IsCurrent to false, Completed to true, and the next loop should find that the very next dungeon in the list is marked as IsCurrent.
        /// RETURNS THE CURRENT DUNGEON.
        /// </summary>
        /// <param name="dungeons"></param>
        /// <returns></returns>
        public Dungeon CheckCurrentDungeon(List<Dungeon> dungeons)
        {
            bool movingToNextLevel = false;
            foreach (Dungeon dungeon in dungeons)
            {
                if (dungeon.DungeonType == DungeonType.StilagmiteRuins && !dungeon.Completed)
                {
                    dungeon.IsCurrent = true;
                    return dungeon;
                }
                if (movingToNextLevel)
                {
                    dungeon.IsCurrent = true;
                    return dungeon;
                }
                // The loop will check which dungeon is current. It would then set the bool to true.
                // Upon the next loop it will set the following dungeon to the current dungeon.
                if (dungeon.IsCurrent)
                {
                    movingToNextLevel = true;
                    dungeon.IsCurrent = false; // Setting the previous current dungeon to no longer be the current but to be completed.
                    dungeon.Completed = true;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"{this.DisplayName}";
        }
    }
}
