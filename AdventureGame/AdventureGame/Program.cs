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
                Console.WriteLine($"Character: {character.Name}");

                character.UseSpecialAbility();
                character.TakeDamage(20);
                character.Heal();
                
                character.TakeDamage(15);
                character.Heal(10);
                potion.Collect();

                potion.Use(character, "25");

                Console.WriteLine("+++++++++++++++++++++++++++");

            }
        }
    }
}
