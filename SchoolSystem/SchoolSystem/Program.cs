using System;


namespace SchoolSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentName = "Sami Ali";
            int studentAge = 20;
            int studentGrade = 12;
            double studentAvg = 85.5;
            char studentGender = 'M';
            bool studentActive = true;

            Console.WriteLine("Student Name: " + studentName);
            Console.WriteLine("Student Age: " + studentAge);
            Console.WriteLine("Student Grade: " + studentGrade);
            Console.WriteLine("Student Average: " + studentAvg);
            Console.WriteLine("Student Gender: " + studentGender);
            Console.WriteLine("Student Active: " + studentActive);

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++

            string[] student = { "Sami Ali", "John Doe", "Jane Smith" ,"Ahmad al-Rashid"};

            Console.WriteLine("\nStudent List:");
            Console.WriteLine($"Student 1:  {student[0]}");
            Console.WriteLine($"Student 2:  {student[1]}");
            Console.WriteLine($"Student 3:  {student[2]}");
            Console.WriteLine($"Student 4:  {student[3]}");

            Console.WriteLine($"Number of Students: {student.Length}");


            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.WriteLine("\nStudent Before Update:");
            Console.WriteLine($"Student 1:  {student[0]}");
            Console.WriteLine($"Student 2:  {student[1]}");
            Console.WriteLine($"Student 3:  {student[2]}");
            Console.WriteLine($"Student 4:  {student[3]}");

            student[2] = "Ali Hassan";
            Console.WriteLine("\nStudent After Update:");
            Console.WriteLine($"Student 1:  {student[0]}");
            Console.WriteLine($"Student 2:  {student[1]}");
            Console.WriteLine($"Student 3:  {student[2]}");
            Console.WriteLine($"Student 4:  {student[3]}");


        }
    }
}
