using System;
using System.Diagnostics;
using Lib.Common.Log;

namespace Lib.Common
{
    public class PerformanceWatch : IDisposable
    {
        private readonly IMyLogger _logger;
        private readonly Stopwatch _watch;
        private readonly string _message;

        public PerformanceWatch(IMyLogger logger, string message)
        {
            _logger = logger;
            _watch = new Stopwatch();
            _watch.Start();
            _message = message;
        }

        public void Dispose()
        {
            _watch.Stop();

            //if (_watch.ElapsedMilliseconds >= 1000)
            //    _logger.Log(string.Format("{0} in {1} s", _message, _watch.ElapsedMilliseconds / 1000));

            _logger.Log(string.Format("{0} in {1} ms", _message, _watch.ElapsedMilliseconds));
        }
    }
}