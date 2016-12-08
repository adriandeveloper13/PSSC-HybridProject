using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.Deanship
{
   public  class Faculty
    {
        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }
        public Uri WebsiteLink { get; internal set; }

       internal Faculty(UniqueIdentifier id, PlainText name, Uri websiteLink)
       {
           Id = id;
           Name = name;
           WebsiteLink = websiteLink;
       }

       internal void ActualizingContent(Uri url)
       {
           WebsiteLink = url;
       }

        #region overrride objects
        public override bool Equals(object obj)
       {
           var faculty = (Faculty) obj;
           if (faculty != null)
           {
               return Name.Equals(faculty.Name);
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
