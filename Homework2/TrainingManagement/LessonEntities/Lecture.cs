using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagement.LessonEntities;

namespace TrainingManagement
{
    internal class Lecture:Lesson
    {
        public string Topic { get; set; }

        public Lecture(string description, string topic):base(description)
        {
            Topic = topic;
        }
    }
}
