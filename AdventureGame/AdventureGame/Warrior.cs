using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class Warrior : GameCharacter
    {
        public Warrior(string name, int health) : base(name, health)
        {
        }
        public override void UseSpecialAbility()
        {
            Console.WriteLine("The Warrior attacks with a sword!");
        }

        public override void TakeDamage(int damage)
        {
            // Warriors take 10% less damage
            int reducedDamage = damage - 2;
            base.TakeDamage(reducedDamage);
        }

    }
    
}
