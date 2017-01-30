using System;
using Interfaces.Queries;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.StudyYear
{
    public class Course : ValueObject<Course>, IQueryResult
    {
        public UniqueIdentifier RegistrationNumber { get; set; }
        public PlainText Name { get; internal set; }

        public string ContentLink { get; internal set; }

        public Course()
        { }
        internal Course(UniqueIdentifier registrationNumber, PlainText name, string contentLink)
        {
            RegistrationNumber = registrationNumber;
            Name = name;
            ContentLink = contentLink;
        }

        internal void ActualizingContentLink(string url)
        {
            ContentLink = url;
        }
        #region override objects
        public override string ToString()
        {
            return Name.ToString();
        }

        public override bool Equals(object obj)
        {
            var course = (Course) obj;

            if (course != null)
            {
                return Name.Equals(course.Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

#endregion
    }
}
