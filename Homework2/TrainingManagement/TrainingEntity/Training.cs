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
                
    }
}
