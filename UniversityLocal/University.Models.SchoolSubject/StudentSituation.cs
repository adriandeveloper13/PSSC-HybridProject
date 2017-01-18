using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Generic;

namespace University.Models.StudyYear
{
    public class StudentSituation : IQueryResult
    {
        public List<Grade> ActivityGrades { get; internal set; }
        public Grade ExamGrade { get; internal set; }
        public Grade FinalGrade { get; internal set; }

        public StudentSituation(List<Grade> activitygrades, Grade examGrade, Grade finalGrade )
        {
            this.ActivityGrades = activitygrades;
            this.ExamGrade = examGrade;
            this.FinalGrade = finalGrade;
        }
    }
}
