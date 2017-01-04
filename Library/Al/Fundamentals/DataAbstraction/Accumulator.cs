using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.DataAbstraction
{
    public class Accumulator
    {
        private double m;
        private double s;
        private int N;

        public void AddDataValue(double x)
        {
            N++;
            s = s + 1.0 * (N - 1) / N * (x - m) * (x - m);
            m = m + (x - m) / N;
        }

        public double Mean { get { return m; } }

        public double Var { get { return s / (N - 1); } }

        public double StdDev { get { return Math.Sqrt(this.Var); } }
    }
}
