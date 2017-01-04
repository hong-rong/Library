using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Lib.Common.Watch;

namespace Lib.Common.UnitTest.Sorting
{
    /// <summary>
    /// class help to load 31 test cases from embemed resources
    /// </summary>
    public class SortingTestHelper
    {
        public const string EmbendemResourceTemplate = "Lib.Common.UnitTest.Sorting.TestCase.TestCase{0}.txt";

        public static void SortAssert(Action<IComparable[]> action)
        {
            var testCases = GetTestCases();

            for (int i = 0; i < testCases.Length; i++)
            {
                using (new TimeOutWatch())
                    action(testCases[i]);

                Assert(testCases[i]);

                Debug.WriteLine(string.Format("passed test case{0}", i + 1));
            }
        }

        public static IComparable[][] GetTestCases()
        {
            const int num = 31;
            var testCases = new IComparable[num][];

            for (var i = 0; i < num; i++)
                testCases[i] = GetTestCase(i);

            return testCases;
        }

        public static IComparable[] GetTestCase(int testCaseIndex)
        {
            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format(EmbendemResourceTemplate, testCaseIndex + 1))))
            {
                return LoadTestCase(reader.ReadToEnd().Trim());
            }
        }

        public static void PrintArray(IComparable[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Debug.Write(arr[i] + " ");
            }

            Debug.WriteLine("");
        }

        private static void Assert(IComparable[] testCase)
        {
            for (int k = 1; k < testCase.Length; k++)
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(testCase[k - 1].CompareTo(testCase[k]) < 0);
        }

        private static IComparable[] LoadTestCase(string fileContent)
        {
            var numbers = fileContent.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var testCases = new IComparable[numbers.Length];

            for (var i = 0; i < numbers.Length; i++)
                testCases[i] = int.Parse(numbers[i]);

            return testCases;
        }
    }
}