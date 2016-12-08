using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Generic.Exceptions;

namespace University.Generic.Exceptions
{
    public class UniqueIdentifier
    {
        private Guid _uniqueIdentifier;
        public Guid UniqueId { get { return _uniqueIdentifier; } }

        public UniqueIdentifier(Guid uniqueId)
        {
            Contract.Requires<ArgumentNullException>(uniqueId != null, "The unique id cannot be null !");
            Contract.Requires<ArgumentCannotBeEmptyStringException>(string.IsNullOrEmpty(uniqueId.ToString()), "The unique id cannot be empty !");
            _uniqueIdentifier = uniqueId;
        }
    }
    
}
