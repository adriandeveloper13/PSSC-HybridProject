using Base;
using System;
using System.Diagnostics.Contracts;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.SchoolSubject
{
    public class Course : ValueObject<Course>
    {
        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }

        public Uri ContentLink { get; internal set; }

        internal Course(UniqueIdentifier id, PlainText name, Uri contentLink)
        {
            Id = id;
            Name = name;
            ContentLink = contentLink;
        }

        internal void ActualizingContentLink(Uri url)
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
