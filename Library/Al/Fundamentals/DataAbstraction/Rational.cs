using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.DataAbstraction
{
    public class Rational
    {
        private readonly int _numberator;
        private readonly int _denominator;
        private readonly bool? _isPositive;

        public Rational(int numberator, int denominator)
        {
            if (denominator == 0) throw new ArgumentException("denominator cannot be zero.", "denominator");

            int gcd = GetGcd(numberator, denominator);
            if (Math.Abs(gcd) != 1) throw new ArgumentException(string.Format("{0} and {1} have greatest common divider greater than 1.", numberator, denominator));

            if (numberator == 0) _isPositive = null;
            if (numberator < 0 && denominator < 0) _isPositive = true;
            if (numberator < 0 || denominator < 0) _isPositive = false;

            _numberator = numberator > 0 ? numberator : numberator * -1;
            _denominator = denominator > 0 ? denominator : denominator * -1;
        }

        public int Numberator { get { return _numberator; } }

        public int Denominator { get { return _denominator; } }

        public bool? IsPosition { get { return _isPositive; } }

        protected int GetGcd(int p, int q)
        {
            if (q == 0) return p;

            int r = p % q;

            return GetGcd(q, r);
        }

        public virtual Rational Plus(Rational b)
        {
            int numberator = this.Numberator * b.Denominator + b.Numberator * this.Denominator;
            int denominator = this.Denominator * b.Denominator;

            int gcd = GetGcd(numberator, denominator);

            return new Rational(numberator / gcd, denominator / gcd);
        }

        public virtual Rational Minus(Rational b)
        {
            int numberator = this.Numberator * b.Denominator - b.Numberator * this.Denominator;
            int denominator = this.Denominator * b.Denominator;

            int gcd = GetGcd(numberator, denominator);

            return new Rational(numberator / gcd, denominator / gcd);
        }

        public virtual Rational Times(Rational b)
        {
            int numberator = this.Numberator * b.Numberator;
            int denominator = this.Denominator * b.Denominator;

            int gcd = GetGcd(numberator, denominator);

            return new Rational(numberator / gcd, denominator / gcd);
        }

        public virtual Rational Divides(Rational b)
        {
            int numberator = this.Numberator * b.Denominator;
            int denominator = this.Denominator * b.Numberator;

            int gcd = GetGcd(numberator, denominator);

            return new Rational(numberator / gcd, denominator / gcd);
        }

        public override int GetHashCode()
        {
            return Numberator.GetHashCode() ^ 397 + Denominator.GetHashCode() ^ 397;
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;

            if (obj == null) return false;

            Rational rational = (Rational)obj;

            if (this.Numberator != rational.Numberator) return false;

            if (this.Denominator != rational.Denominator) return false;

            return true;
        }

        public override string ToString()
        {
            return (Numberator / Denominator).ToString();
        }
    }
}
