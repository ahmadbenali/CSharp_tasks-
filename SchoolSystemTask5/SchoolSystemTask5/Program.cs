using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTask5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("++++++ Report Info +++++++");
            SchoolReport report = new SchoolReport("Annual School Report");
            report.DisplayReportTitle();

            Student student1 = new Student("Alice", 20, 85 ,1, "Greenwood High");
            Student student2 = new Student("Bob", 21, 90 ,2, "Greenwood High");
            Teacher teacher = new Teacher("Mr. Smith", 40, "Greenwood High", "Mathematics");

            //Student1.SchoolNmae= "Greenwood High"; 
            //student1._internalCode=25;

            Console.WriteLine("\n++++++ Student Info +++++++");
            student1.DisplaySchoolName();
            student2.DisplaySchoolName();
            Console.WriteLine("\n++++++ Teacher Info +++++++");
            teacher.DisplayTeacherInfo();

        }
    }
}
