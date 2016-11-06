using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Generic;
using University.Generic.Enums;

namespace University.Models
{
    public class SchoolSubject
    {
        public PlainText Name { get; internal set; }
        public Proportion ExamProportion { get; internal set; }

        public Credits credits { get; internal set; }

        private List<Student> _registeredStudents;
        public ReadOnlyCollection<Student> RegisteredStudents { get { return _registeredStudents.AsReadOnly(); } }

        public SchoolSubjectState State { get; internal set; }

        internal SchoolSubject(PlainText name, SchoolSubjectState subjectState, Credits credits)
        {
            Name = name;
            State = subjectState;
            this.credits = credits;
        } 
        internal SchoolSubject(PlainText name, Proportion examProportion, List<Student> registeredStudents, SchoolSubjectState subjectState, Credits credits )
            :this(name, subjectState, credits)
        {
            
            ExamProportion = examProportion;
            _registeredStudents = registeredStudents;

        }
    }
}
