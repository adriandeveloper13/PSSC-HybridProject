using Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Generic;
using University.Generic.Enums;
using University.Models.SchoolSubject;

namespace University.Models.Deanship
{
    public class Deanship : Entity<Guid> //TODO : here I must to replace the Entity<Guid> with a base class like ValueObject (for the moment the value object does not accept Collection properties)
    {
        public Guid DeanshipId { get; private set; }
        public PlainText Name { get; private set; }
        public Uri Website { get; private set; }

        private List<SchoolSubject.SchoolSubject> _definedSchoolSubjects;
        private List<Professor> _definedProfessors;

        public Deanship(Guid Id, PlainText name, Uri website) : base(Id)
        {
            this.Name = name;
            this.Website = website;
        }

        public Deanship(Guid Id, PlainText name, Uri website, List<SchoolSubject.SchoolSubject> definedSchoolSubjects, List<Professor> definedProfessors) : this(Id, name, website)
        {
            _definedSchoolSubjects = definedSchoolSubjects;
            _definedProfessors = definedProfessors;
        }

        public ReadOnlyCollection<SchoolSubject.SchoolSubject> SchoolSubjects
        {
            get { return _definedSchoolSubjects.AsReadOnly(); }
        }


        public ReadOnlyCollection<Professor> Professors
        {
            get { return _definedProfessors.AsReadOnly(); }
        }

        public void DefinedSchoolSubject(PlainText name, Proportion examProportion, Credits credits,
            EvaluationType evaluationType, List<Laboratory> laboratories, List<Course> courses)
        {
            _definedSchoolSubjects.Add(new SchoolSubject.SchoolSubject(name, examProportion, credits, evaluationType, laboratories, courses) );
        }
        public void DefinedSchoolSubject(PlainText name, Proportion examProportion, Credits credits,
            EvaluationType evaluationType, List<Student> registeredStudents, List<Laboratory> laboratories, List<Course> courses)//profesorul care se ocupa de disciplina respectiva
        {
            _definedSchoolSubjects.Add(new SchoolSubject.SchoolSubject(name, examProportion, credits, evaluationType, registeredStudents, laboratories, courses));
        }
        public void DefinedSchoolSubject(PlainText name, Proportion examProportion, Credits credits,
            EvaluationType evaluationType, List<Student> registeredStudents, Professor schoolSubjectProfessor, List<Laboratory> laboratories, List<Course> courses)//studentii inscrisi pt fiecare disciplina
        {
            _definedSchoolSubjects.Add(new SchoolSubject.SchoolSubject(name, examProportion, credits, evaluationType, registeredStudents, schoolSubjectProfessor, laboratories, courses));
        }
        //above in those methodes, when I define a schoolSubject, I attach for it: students, professor, courses, laboratories, so I do not need separate methods for that
    }
}