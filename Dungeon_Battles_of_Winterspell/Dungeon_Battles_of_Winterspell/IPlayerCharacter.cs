using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    public interface IPlayerCharacter
    {
        public IPlayerWeapon Weapon { get; set; }
    }
}
