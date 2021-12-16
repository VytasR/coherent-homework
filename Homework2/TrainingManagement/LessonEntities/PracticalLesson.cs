using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingManagement.LessonEntities
{
    internal class PracticalLesson
    {
        public string LinkToTaskCondition { get; }
        public string LinkToSolution { get; }

        public PracticalLesson(string linkToTaskCondition, string linkToSolution)
        {
            LinkToTaskCondition = linkToTaskCondition;
            LinkToSolution = linkToSolution;
        }
    }
}
