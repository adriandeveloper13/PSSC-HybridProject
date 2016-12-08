using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using University.Generic;
using University.Generic.Enums;

namespace University.Models.SchoolSubject
{
    public class SchoolSubject
    {
        public PlainText Name { get; internal set; }
        public Proportion ExamProportion { get; internal set; }

        public Credits Credits { get; internal set; }
        public EvaluationType EvaluationType { get; internal set; }

        public List<Course> Courses { get; internal set; } 
        public List<Laboratory> Laboratories { get; internal set; } 

        public Professor SchoolSubjectProfessor { get; internal set; }

        private List<Student> _registeredStudents;
        public ReadOnlyCollection<Student> RegisteredStudents { get { return _registeredStudents.AsReadOnly(); } }


        public SchoolSubject() { }
        public SchoolSubject(PlainText name, Proportion examProportion, Credits credits, EvaluationType evaluationType, List<Laboratory> laboratories , List<Course> courses)
        {
            this.Name = name;
            this.EvaluationType = evaluationType;
            this.Credits = credits;
            this.ExamProportion = examProportion;
            this.Laboratories = laboratories;
            this.Courses = courses;

        }
        public SchoolSubject(PlainText name, Proportion examProportion, Credits credits, EvaluationType evaluationType, List<Student> registeredStudents, List<Laboratory> laboratories, List<Course> courses )
            :this(name, examProportion, credits, evaluationType, laboratories, courses)
        {
            ExamProportion = examProportion;
            _registeredStudents = registeredStudents;
        }

        public SchoolSubject(PlainText name, Proportion examProportion, Credits credits, EvaluationType evaluationType, List<Student> registeredStudents, Professor schoolSubjectProfessor, List<Laboratory> laboratories, List<Course> courses)
            : this(name, examProportion, credits, evaluationType, registeredStudents, laboratories, courses)
        {
            ExamProportion = examProportion;
            SchoolSubjectProfessor = schoolSubjectProfessor;
        }
    }
}
