using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask4
{
    sealed class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(
            string name,
            int id,
            double salary,
            string department,
            int teamSize)
            : base(name, id, salary, department)
        {
            TeamSize = teamSize;
        }

        public void DisplayManagerInfo()
        {
            DisplayInfo();
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Team Size: {TeamSize}");
        }
    }
}
