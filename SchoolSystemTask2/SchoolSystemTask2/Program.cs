using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // Part 1 – Enter Student Information
            // ==========================================
            Console.WriteLine("===== Enter Student Information =====");

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Grade: ");
            int grade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Average: ");
            double average = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Student Gender (M/F): ");
            char gender = Convert.ToChar(Console.ReadLine());

            Console.WriteLine();

            // ==========================================
            // Part 2 – Student Report
            // ==========================================
            Console.WriteLine("===== Student Report =====");
            Console.WriteLine($"Welcome {name}!");
            Console.WriteLine();
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine();

            // ==========================================
            // Part 3 – Student Name Formats
            // ==========================================
            Console.WriteLine("===== Name Information =====");
            Console.WriteLine($"Original Name: {name}");
            Console.WriteLine($"Uppercase: {name.ToUpper()}");
            Console.WriteLine($"Lowercase: {name.ToLower()}");
            Console.WriteLine($"First Character: {name[0]}");
            Console.WriteLine();

            // ==========================================
            // Part 4 – Simple Student Calculation
            // ==========================================
            int bonusMarks = 5;
            double newAverage = average + bonusMarks;

            Console.WriteLine("===== Student Calculation =====");
            Console.WriteLine($"Original Average: {average}");
            Console.WriteLine($"Bonus Marks: {bonusMarks}");
            Console.WriteLine($"New Average: {newAverage}");
            Console.WriteLine();

            // ==========================================
            // Part 5 – Student Status
            // ==========================================
            bool isPassed = newAverage >= 50.0;
            bool isAdult = age >= 18;

            Console.WriteLine("===== Student Status =====");
            Console.WriteLine($"New Average: {newAverage}");
            Console.WriteLine($"Passed: {isPassed}");
            Console.WriteLine($"Adult: {isAdult}");
            Console.WriteLine();

            // ==========================================
            // Final Output – Student Summary
            // ==========================================
            string resultText = isPassed ? "Passed" : "Failed";

            Console.WriteLine("================================");
            Console.WriteLine("        STUDENT SUMMARY         ");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine($"Welcome {name.ToUpper()}!");
            Console.WriteLine();
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"New Average: {newAverage}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine();
            Console.WriteLine($"Result: {resultText}");
            Console.WriteLine($"Adult: {isAdult}");
            Console.WriteLine();
            Console.WriteLine("================================");
        }
    }
}
