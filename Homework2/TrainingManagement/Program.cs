using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagement.LessonEntities;

namespace TrainingManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lecture1 = new Lecture("C# types and variables", String.Empty);
            var lecture2 = new Lecture("C# program structure", String.Empty);

            var practicalLesson1 = new PracticalLesson("Building loops", String.Empty, String.Empty);
            var practicalLesson2 = new PracticalLesson("Conditional statements", String.Empty, String.Empty);

            var training1 = new Training("Introduction to C#");
            training1.Add(lecture1);
            training1.Add(lecture2);
            training1.Add(practicalLesson1);
            training1.Add(practicalLesson2);

            Console.WriteLine(training1);

            Console.ReadKey();

        }
    }
}
