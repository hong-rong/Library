using System;
using System.Diagnostics;
using System.Timers;

namespace Lib.Common.Watch
{
    public class TimeOutWatch : IDisposable
    {
        private readonly Timer _timer;
        private readonly bool _enableDebug;

        public TimeOutWatch()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Enabled = true;

            if (_enableDebug)
                Debug.WriteLine("start timer" + DateTime.Now);
        }

        public TimeOutWatch(bool enableDebug)
            : this()
        {
            _enableDebug = enableDebug;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispose();

            throw new TimeoutException();
        }

        public void Dispose()
        {
            if (_timer != null)
                _timer.Dispose();

            if (_enableDebug)
                Debug.WriteLine("dispose timer" + DateTime.Now);
        }
    }
}
