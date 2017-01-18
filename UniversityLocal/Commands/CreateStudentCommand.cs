using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Commands;
using University.Common;
using University.Common.Interfaces;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.StudyYear;

namespace Commands
{
    public class CreateStudentCommand :  ICommand, IEntity
    {
        public Guid RegistrationNumber { get; internal set; }
        public PlainText Name { get; internal set; }
        public Credits Credits { get; internal set; }

        public CreateStudentCommand(Student student)
        {
            RegistrationNumber = student.RegistrationNumber.UniqueId;
            Name = student.Name;
            Credits = student.Credits;
        }


    }
}
