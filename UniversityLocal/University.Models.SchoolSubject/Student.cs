using Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Generic;

namespace University.Models.SchoolSubject
{
    //Entity
    public class Student : ValueObject<Student>
    {
        public RegistrationNumber RegistrationNumber { get; internal set; }
        public PlainText Name { get; internal set; }
        public Credits Credits { get; internal set; }
        public List<Grade> ActivityGrade { get; internal set; }
        public Grade ExamGrade { get; internal set; }
        public Grade FinalGrade { get; internal set; }

        public Student(RegistrationNumber regNumber, PlainText name)
        {
            Contract.Requires(regNumber != null, "The registration numebr cannot be null !");
            Contract.Requires(name != null, "The student name cannot be null !");
            RegistrationNumber = regNumber;
            Name = name;
            ActivityGrade = new List<Grade>();
        }

        public Student(RegistrationNumber regNumber, PlainText name, Credits credits)
            : this(regNumber, name)
        {
            Credits = credits;
        }

    }
}
