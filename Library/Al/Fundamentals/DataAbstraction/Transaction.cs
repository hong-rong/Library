using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.DataAbstraction
{
    public class Transaction
    {
        private string _who;

        private Date _when;

        private double _amount;

        public Transaction(string who, Date when, double amount)
        {
            _who = who;
            _when = when;
            _amount = amount;
        }

        public Transaction(string transaction) { }

        public string Who { get { return _who; } }

        public Date When { get { return _when; } }

        public double Amount { get { return _amount; } }

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2}", Who, When, Amount);
        }

        public override int GetHashCode()
        {
            return Who.GetHashCode() ^ 397 + When.GetHashCode() ^ 397 + Amount.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;

            if (obj == null) return false;

            if (obj.GetType() != this.GetType()) return false;

            Transaction transaction = (Transaction)obj;

            if (transaction.Who != this.Who) return false;

            if (transaction.Amount != this.Amount) return false;

            if (transaction.When != this.When) return false;

            return true;
        }
    }
}
