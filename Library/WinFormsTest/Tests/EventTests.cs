using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.WinForm.Tests
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void EventWithNoDataTest()
        {
            EventCounterWithNoData c = new EventCounterWithNoData(new Random().Next(10));
            c.ThresholdReached += c_ThresholdReachedWithNoData;
            while (true)
            {
                Debug.WriteLine("adding one");
                Debug.WriteLine("increase total by one");
                c.Add(1);
                Thread.Sleep(1000);
            }
        }

        private void c_ThresholdReachedWithNoData(object sender, EventArgs e)
        {
            Debug.WriteLine("The threshold was reached.");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        [TestMethod]
        public void EventWithDataTest()
        {
            EventCounterWithData c = new EventCounterWithData(new Random().Next(10));
            c.ThresholdReachedEventHandler += c_ThresholdReachedWithData;
            while (true)
            {
                Debug.WriteLine("adding one");
                Debug.WriteLine("increase total by one");
                c.Add(1);
                Thread.Sleep(1000);
            }
        }

        private void c_ThresholdReachedWithData(object sender, ThresholdReachedEventArgs e)
        {
            Debug.WriteLine("The threshold of {0} was reached at {1}", e.Threshold, e.TimeReached);
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
    }

    class EventCounterWithNoData
    {
        private int _threshold;
        private int _total;

        public EventCounterWithNoData(int passedThreshold)
        {
            _threshold = passedThreshold;
            Debug.WriteLine("threadhold: " + _threshold);
        }

        public void Add(int x)
        {
            _total += x;
            Debug.WriteLine("total: " + _total);
            if (_total >= _threshold)
            {
                EventHandler handler = ThresholdReached;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler ThresholdReached;
    }

    class EventCounterWithData
    {
        private int _threshold;
        private int _total;

        public EventCounterWithData(int passedThreshold)
        {
            _threshold = passedThreshold;
        }

        public void Add(int x)
        {
            _total += x;
            if (_total >= _threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = _threshold;
                args.TimeReached = DateTime.Now;
                EventHandler<ThresholdReachedEventArgs> handler = ThresholdReachedEventHandler;
                if (handler != null)
                {
                    //handler(this, args);
                    handler.Invoke(this, args);
                }
            }
        }

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReachedEventHandler;
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}