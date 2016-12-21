using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Generic.Exceptions;
using University.Generic;

namespace University.Models.Deanship
{
    public class DeanshipFactory
    {
        public static readonly DeanshipFactory Instance = new DeanshipFactory();

        private DeanshipFactory() { }

        public Deanship CreateDeanship(string name, Uri website)
        {
            Contract.Requires<ArgumentNullException>(name != null,"The name cannot be null !");
            Contract.Requires<ArgumentInvalidLengthException>(name.Length >= 2 && name.Length <= 50,"The name length should be between 2 and 50 characters !");
            var deanship = new Deanship(new Guid(), new PlainText(name), (Uri)website);

            return deanship;
        }
    }
}
