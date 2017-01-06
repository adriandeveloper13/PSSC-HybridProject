using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Common
{
    public class GenericEventWrapper
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid AggregateId { get; set; }
        public DomainEvent Data { get; set; }

        public GenericEventWrapper()
        { }
    }
}
