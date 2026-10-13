using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask4
{

    internal class Program
    {
        static void Main(string[] args)
        {
        

            Console.WriteLine("\n===== Manager =====");

            Manager manager = new Manager(
                "Ali", 102, -3, "HR", 8);

            manager.DisplayManagerInfo();

  
        }
    }

}
