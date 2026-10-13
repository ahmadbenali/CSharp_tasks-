using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask4
{
     class Employee
     {
        public string Name { get; set; }
        public int Id { get; set; }

        private double salary;

        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value >= 0)
                    salary = value;
                else
                    Console.WriteLine("Invalid salary!");
            }
        }


        protected string Department { get; set; }

        public Employee(string name, int id, double salary, string department)
        {
            Name = name;
            Id = id;
            Salary = salary;
            Department = department;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }
}
