using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Generic;

namespace University.Models
{
    public class Professor
    {
        public PlainText Name { get; internal set; }
        public List<SchoolSubject> SchoolSubjects
        {
            get;
            internal set;
        } 

        public Professor(PlainText name)
        {
            Name = name;
        }
    }
}
