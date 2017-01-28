using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;

namespace DbQueryExecutors
{
    public class UpdateSchoolSubjectQuery:IQuery
    {
        public Guid SchoolSubjectId { get; internal set; }

        public UpdateSchoolSubjectQuery(Guid schoolSubjectId)
        {
            this.SchoolSubjectId = schoolSubjectId;
        }
    }
}
