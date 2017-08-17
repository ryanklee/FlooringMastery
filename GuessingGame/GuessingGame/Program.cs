using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess;
            int guessTry = 1;
            int mode;
       
            string playerName;
            string playerInput;
            string range;

            
            Console.Write("Enter your name: ");
            playerName = Console.ReadLine();

            while (true)
            {
                while (true)
                {
                    Console.Write("Enter [1] for easy, [2] for normal, [3] for hard: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out mode))
                    {
                        break;
                    }
                }

                if (mode == 1)
                {
                    Random r = new Random();
                    theAnswer = r.Next(1, 5);
                    range = "1-5";
                    break;
                }
                else if (mode == 2)
                {
                    Random r = new Random();
                    theAnswer = r.Next(1, 20);
                    range = "1-20";
                    break;
                }
                else if (mode == 3)
                {
                    Random r = new Random();
                    theAnswer = r.Next(1, 50);
                    range = "1-50";
                    break;
                }
                else
                {
                    Console.WriteLine($"{playerName}, please enter a value between 1 and 3 to choose your difficulty...");
                }
            }

            do
            {
                // get player input
                Console.Write($"{playerName}, Enter your guess {range} (\'q\' to quit): ");
                playerInput = Console.ReadLine();

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    if (playerGuess == theAnswer && guessTry == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{theAnswer} was the number, {playerName}. You Win on yr first try!");
                        Console.ResetColor();
                        break;
                    }
                    else if (playerGuess == theAnswer)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{theAnswer} was the number, {playerName}. You Win!");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        if (playerGuess > theAnswer)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{playerName}, your guess was too High!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{playerName}, your guess was too low!");
                            Console.ResetColor();
                        }
                    }
                }
                else if (playerInput == "q" || playerInput == "Q")
                {
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{playerName}, that wasn't a number!");
                    Console.ResetColor();
                }
                guessTry += 1;
            } while (true);

            Console.WriteLine($"Tries to win: { guessTry }");
            Console.WriteLine($"{playerName}, press any key to quit.");
            Console.ReadKey();
        }
    }
}
