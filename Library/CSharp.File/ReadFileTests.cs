using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace CSharp.IO
{
    [TestClass]
    public class ReadFileTests
    {
        [TestMethod]
        public void TestFile()
        {
            string filePath = @"C:\temp\_johnlewis_products_catalogue.csv.tsv";
            var lines = ReadLineWithPeekCheck(filePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split('\t');
                Debug.WriteLine(parts.Length);
            }
        }

        #region read file

        private IEnumerable<string> ReadFileWithFileStream(string filelPath)
        {
            using (FileStream fileStream = File.Open(filelPath, FileMode.Open))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        yield return streamReader.ReadLine();
                    }
                }
            }
        }

        private IEnumerable<string> ReadFileWithStreamReader(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (streamReader.Peek() >= 0)
                {
                    yield return streamReader.ReadLine();
                }
            }
        }

        private IEnumerable<string> ReadFileWithFile(string filePath)
        {
            return File.ReadLines(filePath);
        }

        private IEnumerable<string> ReadFileWithBufferStream(string filePath)
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamReader streamReader = new StreamReader(bufferedStream))
                    {
                        while (streamReader.Peek() >= 0)
                        {
                            yield return streamReader.ReadLine();
                        }
                    }
                }
            }
        }

        #endregion

        private IEnumerable<string> ReadLineWithNullCheck(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        private IEnumerable<string> ReadLineWithPeekCheck(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (streamReader.Peek() > 0)
                {
                    yield return streamReader.ReadLine();
                }
            }
        }
    }
}
