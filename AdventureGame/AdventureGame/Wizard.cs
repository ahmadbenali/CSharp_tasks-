using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class Wizard : GameCharacter
    {
        public Wizard(string name, int health) : base(name, health)
        {
        }
        public override void UseSpecialAbility()
        {
            Console.WriteLine("The Wizard uses magic!");
        }
        public override void TakeDamage(int damage)
        {
            
            int increasedDamage = damage;
            base.TakeDamage(increasedDamage);
        }
    }
}
