using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    abstract internal class GameCharacter
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        protected int health { get; set; }

        public GameCharacter(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public abstract void UseSpecialAbility();

        public virtual void TakeDamage(int damage)
        {

            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
            if(health>100)
            {
                health = 100;
            }

            Console.WriteLine($"{name} took {damage} damage. Current health: {health}");
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"{name} has {health} health points.");
        }

        public void Heal()
        {
            health += 10;
            if (health > 100)
            {
                health = 100;
            }

            Console.WriteLine($"{name} healed for 10 points. Current health: {health}");

        }
        public void Heal(int amount)
        {
            health += amount;
            if (health > 100)
            {
                health = 100;
            }

            Console.WriteLine($"{name} healed for {amount} points. Current health: {health}");
        }
        

    }
}
