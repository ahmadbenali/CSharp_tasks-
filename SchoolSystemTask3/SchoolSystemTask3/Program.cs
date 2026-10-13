using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the School System!");
            while (true)
            {
                Console.WriteLine("++++++++++++++++++++++++++++++++++\nPlease select an option:");
                Console.WriteLine("1. Display all students");
                Console.WriteLine("2. Search for a student");
                Console.WriteLine("3. Check student grades");
                Console.WriteLine("4. Exit");

                Console.Write("++++++++++++++++++++++++++++++++++\nEnter your choice (1-4): ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                     
                        DisplayStudents();
                        break;
                    case "2":
                        SearchStudent();
                        break;
                    case "3":
                        CheckStudentGrades();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            void DisplayStudents()
            {
                string[] students = { "Alice", "Bob", "Charlie", "David" };
                Console.WriteLine("List of students:");
                foreach (string student in students)
                {
                    Console.WriteLine(student);
                }
                int[] grades = { 85, 90, 78, 92 };
                Console.WriteLine("List of student grades:");
                foreach (int grade in grades)
                {
                    Console.WriteLine(grade);
                }
            }

            void SearchStudent()
            {
                Console.WriteLine("Enter the grade of the student to search for:");
                string name = Console.ReadLine();
                string[] students = { "Alice", "Bob", "Charlie", "David" };
                if (students.Contains(name))
                {
                    Console.WriteLine($"Student {name} found.");
                }
                else
                {
                    Console.WriteLine($"Student {name} not found.");
                }
            }

            void CheckStudentGrades()
            {
                Console.WriteLine("Enter the name of the student to check grades for:");
                int grade = int.Parse(Console.ReadLine());



                if (grade >= 90)
                {
                    Console.WriteLine("Grade: Excellent");
                }
                else if (grade >= 80)
                {
                    Console.WriteLine("Grade:Very Good");
                }
                else if (grade >= 70)
                {
                    Console.WriteLine("Grade: Good");
                }
                else if (grade >= 60)
                {
                    Console.WriteLine("Grade: Pass");
                }
                else
                {
                    Console.WriteLine("Grade: Fail");
                }
            }
        }
    }
}
