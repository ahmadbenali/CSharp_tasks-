using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask4
{
    internal class Student
    {
        public string name;
        public int age;
        public int grade;

        public Student(string name, int age, int grade)
        {
            this.name = name;
            this.age = age;
            this.grade = grade;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}, Grade: {grade}");
        }
    }
}
