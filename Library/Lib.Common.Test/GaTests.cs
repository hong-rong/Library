using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lib.Common.Al;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test
{
    [TestClass]
    public class GaTests
    {
        [TestMethod]
        public void SolveSubset()
        {
            List<int> set = new List<int> { 1, 2, 3 };

            List<List<int>> allSubsets = Ga.GetAllSubsets(set);

            for (int i = 0; i < allSubsets.Count; i++)
            {
                for (int j = 0; j < allSubsets[i].Count; j++)
                {
                    Debug.Write(string.Format("{0}    ", allSubsets[i][j]));
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("");
            Debug.WriteLine(allSubsets.Count);
        }

        [TestMethod]
        public void SolvePermutaion()
        {
            var input = "abcd";
            string[] result = Ga.GetAllPermutaions(input);
            Debug.Write(string.Join(",", result));
            Debug.WriteLine("");
            Debug.WriteLine(result.Length);
            Debug.WriteLine("");
        }
    }
}