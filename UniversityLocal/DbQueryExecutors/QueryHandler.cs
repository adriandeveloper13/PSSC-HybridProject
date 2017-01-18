using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Models.StudyYear;

namespace DbQueryExecutors
{
    public class QueryHandler : IQueryHandler<StudentQuery, Student>
    {
        public Task<Student> Retrieve(StudentQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
