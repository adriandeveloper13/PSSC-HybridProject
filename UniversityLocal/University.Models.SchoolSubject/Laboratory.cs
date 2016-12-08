using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.SchoolSubject
{
    public class Laboratory
    {
        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }

        public Uri ContentLink { get; internal set; }

        internal Laboratory(PlainText name)
        {
            Contract.Requires(name != null, "The course name cannot be empty");
            Name = name;
        }

        #region operations

        internal void ActualizingContentLink(Uri url)
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