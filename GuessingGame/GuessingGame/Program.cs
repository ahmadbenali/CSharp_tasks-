using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int secretNumber = random.Next(50, 76);

            int guess = 0;
            int attempts = 0;
            int points = 0;

            Console.WriteLine("===== Guessing Game =====");

            while (guess != secretNumber)
            {
                Console.Write("\nGuess a number between 50 and 75: ");
                guess = Convert.ToInt32(Console.ReadLine());

                attempts++;

                if (guess < secretNumber)
                {
                    Console.WriteLine("Try a higher number.");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("Try a lower number.");
                }
                else
                {
                    Console.WriteLine("Congratulations!");
                }
            }

            // Calculate points
            if (attempts == 1)
            {
                points = 10;
            }
            else if (attempts == 2)
            {
                points = 7;
            }
            else if (attempts == 3)
            {
                points = 5;
            }
            else
            {
                points = 0;
            }

            Console.WriteLine($"\nAttempts: {attempts}");
            Console.WriteLine($"Points: {points}");





        }
    }
}
