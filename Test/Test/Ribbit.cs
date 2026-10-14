using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Ribbit : Animal, Prey
    {
        public override void Run()
        {
            Console.WriteLine("Run Ribbit");
        }

        public override void sleep()
        {
            Console.WriteLine("Sleep Ribbit");
        }
    }
}
