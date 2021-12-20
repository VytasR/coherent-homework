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
        private const int MAX_NUMBER_OF_LESSONS = 10;
        private Lesson[] Lessons;
        private int _numberOfLessons;

        public Training (string description)
        {
            Description = description;
            Lessons = new Lesson[MAX_NUMBER_OF_LESSONS];
            _numberOfLessons = 0;
        }

        public int NumberOfLessons => _numberOfLessons;

        public Lesson this[int index]
        {
            get
            {
                if (index < MAX_NUMBER_OF_LESSONS && index >= 0)
                {
                    return Lessons[index];
                } 
                else
                {
                    return null;
                }
            }
        }

        public void Add (Lesson lesson)
        {
            if (_numberOfLessons < MAX_NUMBER_OF_LESSONS)
            {
                Lessons[_numberOfLessons] = lesson;
                _numberOfLessons++;
            } 
            else
            {
                throw new Exception("Max number of lessons exceeded.");
            }            
        }

        // Returns true if the training contains only practical lessons.
        public bool IsPractical()
        {            
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
            for (int index = 0; index < _numberOfLessons; index++)
            {
                if (this[index] is Lecture)
                {
                    string description = String.Copy(this[index].Description);
                    string topic = String.Copy(((Lecture) this[index]).Topic);
                    other.Add(new Lecture(description, topic));
                }
                else if (this[index] is PracticalLesson)
                {
                    string description = String.Copy(this[index].Description);
                    string linkToTaskCondition = String.Copy(((PracticalLesson)this[index]).LinkToTaskCondition);
                    string linkToTaskSolution = String.Copy(((PracticalLesson)this[index]).LinkToTaskCondition);
                    other.Add(new PracticalLesson(description, linkToTaskCondition, linkToTaskSolution));
                }
            }
            return other;
        }
    }
}
