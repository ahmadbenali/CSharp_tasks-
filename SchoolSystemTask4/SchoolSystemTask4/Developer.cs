using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask4
{
     class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }


        public Developer(
            string name,
            int id,
            double salary,
            string department,
            string language)
            : base(name, id, salary, department)

        {
            
            ProgrammingLanguage = language;
        }

        public void DisplayDeveloperInfo()
        {
            DisplayInfo();
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Language: {ProgrammingLanguage}");
        }
    }
}
