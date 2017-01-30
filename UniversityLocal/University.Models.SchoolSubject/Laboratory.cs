using System;
using System.Diagnostics.Contracts;
using Interfaces.Queries;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.StudyYear
{
    public class Laboratory : ValueObject<Laboratory>, IQueryResult
    {
        public UniqueIdentifier RegistrationNumber { get; set; }
        public PlainText Name { get; internal set; }

        public string ContentLink { get; internal set; }

        public Laboratory() { }
        internal Laboratory(UniqueIdentifier id, PlainText name, string contentLink)
        {
            Contract.Requires(RegistrationNumber != null, "The course name cannot be empty");
            RegistrationNumber = id;
            Name = name;
            ContentLink = contentLink;
        }

        #region operations

        internal void ActualizingContentLink(string url)
        {
            Contract.Requires(url != null, "The Laboratory url is null");
            ContentLink = url;
        }

        #endregion

        #region override objects

        public override string ToString()
        {
            return Name.ToString();
        }

        public override bool Equals(object obj)
        {
            var laboratory = (Laboratory) obj;

            if (laboratory != null)
            {
                return Name.Equals(laboratory.Name);
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