using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.Deanship
{
    public class Specialization
    {
        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }
        public Uri SpecializationWebsite { get; internal set; }

        internal Specialization(UniqueIdentifier id, PlainText name, Uri spcializationWebsite)
        {
            Id = id;
            Name = name;
            SpecializationWebsite = spcializationWebsite;
        }

        #region override objects

        public override bool Equals(object obj)
        {
            var specialization = (Specialization) obj;
            if (specialization != null)
            {
                return Name.Equals(specialization.Name);
            }
            return false;
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #endregion
    }
}
