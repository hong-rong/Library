using System;
using System.Diagnostics;

namespace Lib.Common.Watch
{
    public class TimeWatch : IDisposable
    {
        private readonly Stopwatch _watch = new Stopwatch();

        public TimeWatch()
        {
            _watch.Start();
        }

        public void Dispose()
        {
            _watch.Stop();

            Console.WriteLine(string.Format("time: {0}s", _watch.ElapsedMilliseconds / 1000));
        }
    }
}
