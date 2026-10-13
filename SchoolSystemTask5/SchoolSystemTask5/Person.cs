using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask5
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        //can't access this field from outside the class and derived classes
        private string _internalCode;
        protected string SchoolName { get; set; }

        public Person(string name, int age, string schoolName)
        {
            Name = name;
            Age = age;
            SchoolName = schoolName;
        }

        public void DisplayInfo()
        {
            Console.Write($"Name: {Name}, Age: {Age}");
        }

    }
}
