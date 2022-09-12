using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Dungeon_Battles_of_Winterspell
{
    /// <summary>
    /// This class contains helper methods that should help get valid input from users.
    /// </summary>
    public static class CLIHelper
    {
        public static string GetString(string message)
        {
            string userInput;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message);
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (string.IsNullOrEmpty(userInput));

            Console.WriteLine();
            return userInput.ToLower();
        }

        public static int GetInteger(string message)
        {
            string userInput;
            int intValue;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Don't be a fool, these are serious times!");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!int.TryParse(userInput, out intValue));
            Console.WriteLine();
            return intValue;
        }

        /// <summary>
        /// Takes in the current amount of points remaining, the current desired attribute point allocation amount, player's current attribute count, and the string of which attribute is being adjusted. This allows for the checking of the validity of the user's request.
        /// It uses the player's attribute int to check they will not have a negative attribute property, it also does the math differently based upon a negative or a positive value. Verifies number is not out bounds.
        /// Returns a bool of true or false for GetPoints to force user to retry.
        /// </summary>
        /// <param name="pointsRemaining"></param>
        /// <param name="attInput"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static bool CheckPointValidity(int currAttributeStatus, int pointsRemaining, string attribute, int attInput)
        {
            bool valid = true;
            do
            {
                if (attInput < 0)
                {
                    // If statement is checking that the current attribute of the player for whichever att it is checking is not going to become negative. Otherwise it can accomplish the math.
                    if (currAttributeStatus + attInput < 0)
                    {
                        Console.WriteLine($"You have chosen to subtract too many points from your current {attribute} pool, this will not do.");
                        return false;
                    }
                    // If the remaining points - the negative number (which adds instead), would become more than 10, report that you do not have that many points to take away.
                    else if (pointsRemaining - attInput > 10) // The player may not add more points back to their hand then they have spent.
                    {
                        Console.WriteLine($"You have chosen to subtract more points than you have allocated, this will not do.");
                        return false;
                    }
                    else // They are within the bounds of points allocated.
                    {
                        Console.WriteLine($"You have chosen to subtract points from your current {attribute} pool. These points have returned to your hand.");
                        //pointsRemaining -= attInput; // += will add the points back to the hand. This won't do any good b/c we are not returning it or passing it anywhere. Math will be done for GetPoints
                        return true; // We know the input is valid, return true to leave the loop and return the dictionary.
                    }
                }
                else if (attInput > pointsRemaining)
                {
                    Console.WriteLine($"You don't have enough points to do that.");
                    return false;
                }
                else
                {
                    //pointsRemaining -= attInput; // Normal subtraction of a positive number within the bounds. This won't do any good b/c we are not returning it or passing it anywhere. Math will be done for GetPoints
                    return true;
                }
            } while (valid);
        }

        /// <summary>
        /// Get's the user's input as a number, otherwise keeps having them retry. Checks the value using antoher method called CheckPointValidity. Stores the key as the remaining points and the value as points spent (which are valid.)
        /// This dictionary will only ever have 1 row and it will be returned.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="pointsRemaining"></param>
        /// <returns></returns>
        public static Dictionary<int, int> GetPoints(string message, int currAttributeStatus, int pointsRemaining, string attribute)
        {
            string userInput;
            int attInt = 1;
            bool validInput = false;
            int numberOfAttempts = 0;
            Dictionary<int, int> pointsBookRS = new Dictionary<int, int>();

            // A small while loop to check that the int is parsed, a larger while loop to check that the int is valid.
            while (!validInput)
            {
                do
            {
                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!int.TryParse(userInput, out attInt));

            Console.WriteLine();


                // calling method to check the integer is valid. If not, returns false and goes through the entire loop again.
                validInput = CheckPointValidity(currAttributeStatus, pointsRemaining, attribute, attInt);
            }
            // If input is valid, we leave the larger loop and come down to where math on remaining points is done. Could not identify if user input - or + here so a simple if/else will have to do.
            if (attInt < 0)
            {
                pointsRemaining -= attInt;
            }
            else
            {
                pointsRemaining -= attInt;
            }
            pointsBookRS[pointsRemaining] = attInt; // Setting the key = to points remaining and the value to the amount spent.
            return pointsBookRS;
        }


        public static bool GetBool(string message)
        {
            string userInput;
            bool boolValue;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
                if (userInput.ToLower() == "y" || userInput.ToLower() == "yes")
                {
                    userInput = "true";
                }
                else if (userInput.ToLower() == "n" || userInput.ToLower() == "no")
                {
                    userInput = "false";
                }
                else
                {
                    Console.WriteLine("Please choose y for YES or n for NO");
                }
            }
            while (!bool.TryParse(userInput, out boolValue));

            Console.WriteLine();
            return boolValue;
        }

        

        public static DateTime GetDate()
        {
            bool valid = false;
            Console.Clear();
            // Search for reservations available based on the needs of the customer
            DateTime startDate = new DateTime();
            while (!valid)
            {
                string startDateInput = CLIHelper.GetString("When do you need the space? (MM/DD/YYYY) : ");
                // Datetime parse
                CultureInfo enUs = new CultureInfo("en-US");
                if (DateTime.TryParseExact(startDateInput, "MM/dd/yyyy", enUs , DateTimeStyles.None, out startDate) && startDate > DateTime.Now)
                {
                    valid = true;

                    break;
                }
                Console.WriteLine("Invalid input, check format and that date has not passed and is not today.");
            }
            return startDate;
        }
    }
}
