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
        private Lesson[] lessons;

    }
}
