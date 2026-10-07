using System;


namespace SchoolSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string result = "Hello, " + "World!";
            Console.WriteLine(result);

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");

            string name = "ALICE";
            Console.WriteLine(name.ToLower());

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");

            string name2 = "alice";
            Console.WriteLine(name2.ToUpper());

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");

            string userName = "alice";
            int age = 96;
            Console.WriteLine(userName + " is " + age + " years old.");

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");

            string userName2 = "alice";
            int beforeBalance = 1000;
            int afterBalance = 500;
            Console.WriteLine(beforeBalance + afterBalance + " " + userName2);

            Console.WriteLine(userName2 + " " + beforeBalance + afterBalance);



        }
    }
}
