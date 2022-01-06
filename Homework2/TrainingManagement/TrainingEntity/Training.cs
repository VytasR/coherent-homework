using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagement.LessonEntities;

namespace TrainingManagement
{
    internal class Training
    {
        public string Description { get; set; }        
        private List<Lesson> Lessons;        

        public Training (string description)
        {
            Description = description;
            Lessons = new List<Lesson>();            
        }

        public void Add (Lesson lesson)
        {
            Lessons.Add(lesson);            
        }

        // Returns true if the training contains only practical lessons.
        public bool IsPractical()
        {            
            if (!Lessons.Any())
            {
                return false;
            }

            foreach (var lesson in Lessons)
            {
                if (lesson is Lecture)
                {
                    return false;
                }
            }
            return true;
        }

        // Returns a deep copy of this Training.
        public Training Clone()
        {
            Training other = new Training(Description);
            
            foreach (var lesson in Lessons)
            {
                other.Add(lesson.Clone());
            }

            return other;
        }

        // Returns a list of lectures and practical lessons in a multi line string.
        public override string ToString()
        {
            if (!Lessons.Any())
            {
                return $"Training - {Description} - contains no lessons.";
            }

            var lectures = new StringBuilder();
            var practicalLessons = new StringBuilder();
            int lectureCount = 1;
            int practicalLessonCount = 1;

            foreach (var lesson in Lessons)
            {
                if (lesson is Lecture)
                {
                    lectures.Append(lectureCount);
                    lectures.Append(". ");
                    lectures.Append(lesson.Description);
                    lectures.Append("\n");
                    lectureCount++;
                }
                
                if (lesson is PracticalLesson)
                {
                    practicalLessons.Append(practicalLessonCount);
                    practicalLessons.Append(". ");
                    practicalLessons.Append(lesson.Description);
                    practicalLessons.Append("\n");
                    practicalLessonCount++;
                }                
            }

            var result = new StringBuilder($"Training - {Description} - contains:\n\n");

            if (lectures.Length == 0)
            {
                result.Append("No lectures.\n\n");
                result.Append("Practical lessons:\n");
                result.Append(practicalLessons);
            }
            else if (practicalLessons.Length == 0)
            {
                result.Append("No practical lessons.\n\n");
                result.Append("Lectures:\n");
                result.Append(lectures);
            }
            else
            {
                result.Append("Lectures:\n");
                result.Append(lectures);
                result.Append("\nPractical lessons:\n");
                result.Append(practicalLessons);
            }
            result.Remove((result.Length - 1), 1);

            return result.ToString();                                
        }
    }
}
