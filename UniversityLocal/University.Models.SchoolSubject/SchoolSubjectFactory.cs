using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Modele.Generic.Exceptions;
using University.Generic;
using University.Generic.Enums;

namespace University.Models.SchoolSubject
{
    public class SchoolSubjectFactory
    {
        public static readonly SchoolSubjectFactory Instance = new SchoolSubjectFactory();

        private SchoolSubjectFactory()
        { }

        public SchoolSubject CreateSchoolSubject(string name, int[] proportion, List<Laboratory> laboratories, List<Course> courses )
        {
            Contract.Requires<ArgumentNullException>(name != null, "The name is null !");
            Contract.Requires<ArgumentInvalidLengthException>(name.Length >= 2 && name.Length <= 50, "The name length should be between 2 and 50 characters !");

            var schoolSubject = new SchoolSubject(
                new PlainText(name), 
                new Proportion(proportion[0], proportion[1]), 
                new Credits(3), 
                EvaluationType.DistributedSchoolSubject,
                laboratories,
                courses
                );

            return schoolSubject;
        }

        internal Student CreateStudent(string registrationNumber , string name)
        {
            return new Student(
                new RegistrationNumber(registrationNumber),
                new PlainText(name));
        }
    }
}
