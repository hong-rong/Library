using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.DataAbstraction
{
    public class Date
    {
        private readonly int _year;
        private readonly int _month;
        private readonly int _day;

        public Date(int year, int month, int day)
        {
            _year = year;
            _month = month;
            _day = day;
        }

        public int Year { get { return _year; } }

        public int Month { get { return _month; } }

        public int Day { get { return _day; } }

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2}", Day, Month, Year);
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;

            if (obj == null) return false;

            if (!(obj is Date)) return false;

            if (obj.GetType() != this.GetType()) return false;

            Date date = (Date)obj;

            if (date.Year != this.Year) return false;

            if (date.Month != this.Month) return false;

            if (date.Day != this.Day) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Year.GetHashCode() ^ 397 + Month.GetHashCode() ^ 397 + Day.GetHashCode() ^ 397;
        }
    }
}
