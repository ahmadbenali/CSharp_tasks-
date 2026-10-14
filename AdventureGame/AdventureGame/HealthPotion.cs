using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class HealthPotion : ICollectible
    {
        public string potionName { get; set; }

        public void Collect()
        {
            Console.WriteLine($"You have collected a {potionName}!");
        }

        public void Use(GameCharacter character, String amountText)
        {
            try
            {
                int amount = int.Parse(amountText);
                character.Heal(amount);

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }


        }
    }
}
