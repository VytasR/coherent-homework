using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingManagement.LessonEntities
{
    internal abstract class Lesson
    {
        public string Description { get; set; }

        public Lesson (string description)
        {
            Description = description;
        }
    }
}
