using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingManagement.LessonEntities
{
    internal class PracticalLesson : Lesson
    {
        public string LinkToTaskCondition { get; set; }
        public string LinkToSolution { get; set; }

        public PracticalLesson(string description, string linkToTaskCondition, string linkToSolution) : base(description)
        {
            LinkToTaskCondition = linkToTaskCondition;
            LinkToSolution = linkToSolution;
        }

        public PracticalLesson(string description) : base(description)
        {
            LinkToTaskCondition = String.Empty;
            LinkToSolution = String.Empty;
        }

        public override Lesson Clone()
        {
            return new PracticalLesson(Description, LinkToTaskCondition, LinkToSolution);
        }
    }
}
