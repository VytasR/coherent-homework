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
        private Lesson[] _lessons;
        private int _lessonsIncluded = 0;

        public Training (string description)
        {
            Description = description;
        }

        public Lesson this[int index]
        {
            get
            {
                if (index < MAX_NUMBER_OF_LESSONS && index >= 0)
                {
                    return _lessons[index];
                } 
                else
                {
                    return null;
                }
            }
        }

        public void Add (Lesson lesson)
        {
            if (_lessonsIncluded < MAX_NUMBER_OF_LESSONS)
            {
                _lessons[_lessonsIncluded] = lesson;
            } 
            else
            {
                throw new Exception("Max number of lessons exceeded.");
            }            
        }

        // Returns true if the training contains only practical lessons.
        public bool IsPractical()
        {            
            foreach (var lesson in _lessons)
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

            return other;
        }
    }
}
