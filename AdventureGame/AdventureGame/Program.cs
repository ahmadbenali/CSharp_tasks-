using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior("Conan", 100);
            Wizard wizard = new Wizard("Gandalf", 100);

            List<GameCharacter> characters = new List<GameCharacter> { warrior, wizard };

            foreach(GameCharacter character in characters)
            {
                HealthPotion potion = new HealthPotion { potionName = "Health Potion" };
                if(character is Wizard)
                {
                    Console.WriteLine($"Wizard {character.Name} enters the game!");
                }
                else if (character is Warrior)
                {
                    Console.WriteLine($"Warrior {character.Name} enters the game!");
                }

                character.UseSpecialAbility();
                character.TakeDamage(20);
                character.Heal();
                
                character.TakeDamage(15);
                character.Heal(10);
                potion.Collect();

                potion.Use(character, "5");

                Console.WriteLine("+++++++++++++++++++++++++++");

            }
        }
    }
}
