using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class UserInput
    {
        
        public string GetNameFromUser()
        {
            Console.Write("Enter player name: ");
            string nameInput = Console.ReadLine();
            Console.Clear();
            return nameInput;
        }

        public Validator GetValidCoords()
        {
            Validator validation = new Validator();

            string validStringCoords = GetCoordsFromUser();

            validation.ConvertValidCoords(validStringCoords);

            return validation;
        }

        private string GetCoordsFromUser()
        {
            Validator validation = new Validator();

            string inputCoords;

            while (true)
            {
                inputCoords = Console.ReadLine();
                
                if (validation.CheckForm(inputCoords) && 
                    validation.CheckType(inputCoords.Substring(1)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter valid coordinate...");
                    continue;
                }
            }
            return inputCoords;
        }

        private string GetCoordsFromUser(Player player, ShipType ship)
        {
            Validator validation = new Validator();

            string inputCoords;

            while (true)
            {
                inputCoords = Console.ReadLine();

                if (validation.CheckForm(inputCoords) &&
                    validation.CheckType(inputCoords.Substring(1)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter valid coordinate...");
                    Console.WriteLine("Enter to continue...");
                    continue;
                }
            }
            return inputCoords;
        }

        public ShipDirection GetDirectionFromUser()
        {
            while (true)
            {
                ConsoleKey keyPress = Console.ReadKey(true).Key;
                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        return ShipDirection.Up;
                    case ConsoleKey.DownArrow:
                        return ShipDirection.Down;
                    case ConsoleKey.RightArrow:
                        return ShipDirection.Right;
                    case ConsoleKey.LeftArrow:
                        return ShipDirection.Left;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter valid direction...");
                        Console.WriteLine("Enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
