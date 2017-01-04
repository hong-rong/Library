using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.DataAbstraction
{
    public enum Week
    {
        Sunday = 0,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public class SmartDate : IComparable<SmartDate>
    {
        private int _year;
        private int _month;
        private int _day;

        public SmartDate(int year, int month, int day)
        {
            ValidateYear(year);
            ValidateMonth(month);
            ValidateDay(year, month, day);

            _year = year;
            _month = month;
            _day = day;
        }

        public SmartDate(string date)
        {
            var d = DateTime.Parse(date);
            _year = d.Year;
            _month = d.Month;
            _day = d.Day;
        }

        public int Year
        {
            get { return _year; }
        }

        public int Month
        {
            get { return _month; }
        }

        public int Day
        {
            get { return _day; }
        }

        public string DayOfWeek()
        {
            int dayOfWeek = (Year / 4 + Year - Year / 100 + Year / 400 + Day + Month - 1) % 7;

            return Enum.GetName(typeof(Week), dayOfWeek);
        }

        public override string ToString()
        {
            return string.Format(@"{0}/{1}/{2}", Year, Month, Day);
        }

        public override bool Equals(Object that)
        {
            if (this == that) return true;

            if (that == null) return false;

            if (this.GetType() != that.GetType()) return false;

            SmartDate date = (SmartDate)that;

            if (date.Year != date.Year) return false;
            if (date.Month != date.Month) return false;
            if (date.Day != date.Day) return false;

            return true;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(SmartDate other)
        {
            throw new NotImplementedException();
        }

        private static int GetNumberOfDays(int year, int month)
        {
            ValidateYear(year);
            ValidateMonth(month);

            bool isLeapYear = year % 4 == 0 ? true : false;

            switch (month)
            {
                case 1: return 31;
                case 2: return isLeapYear ? 29 : 28;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                default:
                    throw new InvalidOperationException(string.Format("Invalid month: {0}", month));
            }
        }

        private static void ValidateYear(int year)
        {
            if (year < 1700 || year > 2100)
                throw new ArgumentException(string.Format("Invalid year: {0}", year));
        }

        private static void ValidateMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentException(string.Format("Invalid month: {0}", month));
        }

        private static void ValidateDay(int year, int month, int day)
        {
            int numberOfDays = GetNumberOfDays(year, month);

            if (day < 1 || day > numberOfDays)
                throw new ArgumentException(string.Format("Invalid day: {0}", day));
        }
    }
}
