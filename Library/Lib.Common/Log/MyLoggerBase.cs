using System;
using System.IO;

namespace Lib.Common.Log
{
    public class MyLoggerBase : IMyLogger
    {
        private readonly string _filePath;

        public MyLoggerBase(string folder)
        {
            string date = string.Format("{0}_{1}_{2}_{3}_{4}_{5}",
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second);

            _filePath = Path.Combine(folder, string.Format("my_log_{0}{1}", date, ".txt"));

            if (!File.Exists(_filePath))
            {
                using (File.Create(_filePath)) { };
            }
        }

        public void Log(string logContent)
        {
            using (var sr = File.AppendText(_filePath))
            {
                sr.WriteLine(logContent);
            }
        }
    }
}
