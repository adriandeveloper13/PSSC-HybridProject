using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Modele.Generic.Exceptions;
using University.DataLayer.Interfaces;
using University.Generic;
using University.Generic.Enums;
using University.Generic.Exceptions;

namespace University.Models.StudyYear
{
    public class StudyYearFactory : IAggregationRoot
    {
        public static readonly StudyYearFactory Instance = new StudyYearFactory();

        private StudyYearFactory()
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

        internal Student CreateStudent(Guid registrationNumber , string name)
        {
            return new Student(
                new UniqueIdentifier(registrationNumber),
                new PlainText(name));
        }
    }
}
