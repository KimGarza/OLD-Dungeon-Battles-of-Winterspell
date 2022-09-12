using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonBattles_Of_Winterspell.DisplayText
{
        /// <summary>
        /// This controls the way text is output on screen.
        /// </summary>
        public class TypeEffect
        {
            /// <summary>
            /// Choose text to enter and bool to true if you want a WriteLine or false for Write.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="line"></param>
            public void TypedText(string text, bool line)
            {
                //for each loop will loop through the text and each individual character in the string.
                foreach (char character in text)
                {

                    if (!line)
                    {
                        //write out the characters to the screen.
                        Console.WriteLine(character);
                        //speed of it beging typed out effect.
                        Thread.Sleep(40);
                    }
                    else if (line)
                    {
                        //write out the characters to the screen.
                        Console.Write(character);
                        //speed of it beging typed out effect.
                        Thread.Sleep(40);
                    }
                }
            }
        }
}
