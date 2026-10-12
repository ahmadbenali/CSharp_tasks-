using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Ahmad", 20, 85);
            student.DisplayInfo();
            student = new Student("Ali", 22, 90);
            student.DisplayInfo();
            student = new Student("Sara", 19, 95);
            student.DisplayInfo();
        }
    }
}
