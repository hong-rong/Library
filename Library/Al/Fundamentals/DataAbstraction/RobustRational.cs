using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.DataAbstraction
{
    public class RobustRational : Rational
    {
        public RobustRational(int p, int q) : base(p, q) { }

        public override Rational Plus(Rational b)
        {
            return base.Plus(b);
        }
    }
}
