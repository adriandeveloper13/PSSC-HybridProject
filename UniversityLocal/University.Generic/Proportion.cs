using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Generic
{
    public class Proportion
    {

        private int _numerator;
        private int _denominator;

        public decimal Fraction { get { return (decimal)_numerator / (decimal)_denominator; } }

        public Proportion(int numerator, int denominator)
        {
            Contract.Requires<ArgumentException>(numerator > 0, "numerator");
            Contract.Requires<ArgumentException>(denominator > 0, "denominator");
            Contract.Requires<ArgumentException>(denominator > numerator, "nu este subunitar");

            _denominator = denominator;
            _numerator = numerator;
        }

        #region override object
        public override bool Equals(object obj)
        {
            var coeficient = (Proportion)obj;
            return coeficient._numerator == _numerator && coeficient._denominator == _denominator;
        }

        public override int GetHashCode()
        {
            return Fraction.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", _numerator, _denominator);
        }
        #endregion
    }
}
