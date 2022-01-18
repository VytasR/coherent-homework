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
        /*
         * This program demonstrates the use of classes Training, Lecture and PracticalLesson
         */

        static void Main(string[] args)
        {
            var lecture1 = new Lecture("Types and variables");
            var lecture2 = new Lecture("Program structure");

            var practicalLesson1 = new PracticalLesson("Creating loops");
            var practicalLesson2 = new PracticalLesson("Conditional statements");
            var practicalLesson3 = new PracticalLesson("Using Collections");

            var training1 = new Training("Introduction to C#");
                        
            training1.Add(practicalLesson1);
            training1.Add(practicalLesson2);
            training1.Add(practicalLesson3);

            if (training1.IsPractical())
            {
                Console.WriteLine($"Training - {training1.Description} - contains only practical lessons");
            }

            training1.Add(lecture1);
            training1.Add(lecture2);

            if (!training1.IsPractical())
            {
                Console.WriteLine($"Training - {training1.Description} - contains both lectures practical lessons");
            }

            var training2 = training1.Clone();

            training1.Description = "Training 1";
            lecture1.Description = "Lecture 1";
            practicalLesson1.Description = "Practical lesson 1";

            Console.WriteLine("-------------------------------------\n");
            Console.WriteLine(training1);
            Console.WriteLine("-------------------------------------\n");
            Console.WriteLine(training2);

            Console.ReadKey();

        }
    }
}
