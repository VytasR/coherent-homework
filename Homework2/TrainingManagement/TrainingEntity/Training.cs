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
            Training other = (Training) this.MemberwiseClone();
            other.Description = String.Copy(Description);
            for (int index = 0; index < Lessons.Count(); index++)
            {
                if (Lessons[index] is Lecture)
                {
                    string description = String.Copy(Lessons[index].Description);
                    string topic = String.Copy(((Lecture) Lessons[index]).Topic);
                    other.Add(new Lecture(description, topic));
                }
                else if (Lessons[index] is PracticalLesson)
                {
                    string description = String.Copy(Lessons[index].Description);
                    string linkToTaskCondition = String.Copy(((PracticalLesson) Lessons[index]).LinkToTaskCondition);
                    string linkToTaskSolution = String.Copy(((PracticalLesson) Lessons[index]).LinkToTaskCondition);
                    other.Add(new PracticalLesson(description, linkToTaskCondition, linkToTaskSolution));
                }
            }

            return other;
        }

        // Returns a list of lectures and practical lessons in a multi line string
        public override string ToString()
        {
            var lectures = new StringBuilder("Lectures:\n");
            var practicalLessons = new StringBuilder("Practical lessons:\n");

            foreach (var lesson in Lessons)
            {
                if (lesson is Lecture)
                {
                    lectures.Append((lesson as Lecture).Description);
                    lectures.Append("\n");
                }
                
                if (lesson is PracticalLesson)
                {
                    practicalLessons.Append((lesson as PracticalLesson).Description);
                    practicalLessons.Append("\n");
                }
                
            }
            lectures.Remove((lectures.Length - 2), 2);
            practicalLessons.Remove((practicalLessons.Length - 2), 2);

            if (!Lessons.Any())
            {
                return $"Training {Description} contains no lessons";
            }
            else
            {
                var result = new StringBuilder($"Training {Description} contains:\n");
                
                if (lectures.Length == 0)
                {
                    result.Append("No lectures.");                    
                    result.Append(practicalLessons);
                }
                else if (practicalLessons.Length == 0)
                {
                    result.Append("No practical lessons.");                    
                    result.Append(lectures);
                }
                else
                {
                    result.Append(lectures);
                    result.Append(practicalLessons);
                }

                return result.ToString();
            }            
        }
    }
}
