using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask5
{
    internal class Student : Person
    {
        public int Grade { get; set; }

        public int StudentId { get; set; }

        public Student(string name, int age, int grade, int studentId, string schoolName)
            : base(name, age, schoolName)
        {
            Grade = grade;
            StudentId = studentId;
        }

        public void DisplaySchoolName()
        {
            DisplayInfo();
            Console.WriteLine($" Grade: {Grade}, School Name: {SchoolName}");
        }
    }
}
