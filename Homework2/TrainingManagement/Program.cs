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
            var lecture1 = new Lecture("C# types and variables");
            var lecture2 = new Lecture("C# program structure");

            var practicalLesson1 = new PracticalLesson("Building loops");
            var practicalLesson2 = new PracticalLesson("Conditional statements");

            var training1 = new Training("Introduction to C#");
            training1.Add(lecture1);
            training1.Add(lecture2);
            training1.Add(practicalLesson1);
            training1.Add(practicalLesson2);

            var training2 = training1.Clone();

            Console.WriteLine(training1);
            Console.WriteLine("\n");
            Console.WriteLine(training2);

            Console.ReadKey();

        }
    }
}
