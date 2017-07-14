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
        public void Test()
        {
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
            jaggedArray[1] = new int[] { 0, 2, 4, 6 };
            jaggedArray[2] = new int[] { 11, 22 };


            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = i; j < jaggedArray.Length; j++)
                {
                    if (jaggedArray[j].Intersect(jaggedArray[i]).ToList().Count() > 0)
                    {
                        jaggedArray[j].ToList().AddRange(jaggedArray[i]);
                        var bba = jaggedArray[j].Distinct();
                    }
                }
            }

            var abc = jaggedArray[0].Intersect(jaggedArray[2]).ToList().Distinct();
            jaggedArray[0].ToList().AddRange(jaggedArray[2]);
            jaggedArray.OrderByDescending(j => j.Length).First();
        }

        //public static string[] largestItemAssociation(string[,] itemAssociation)
        //{
        //    // WRITE YOUR CODE HERE
        //    if (itemAssociation == null || itemAssociation.Length == 0) throw new ArgumentException();
        //    for (int i = 0; i < itemAssociation.Length; i++)
        //    {
        //        for (int j = i; j < itemAssociation.Length; j++)
        //        {
        //            if (itemAssociation[j,i].Intersect(itemAssociation[j,i]).ToList().Any())
        //            {
        //                itemAssociation[j,i].ToList().AddRange(itemAssociation[j,i]);
        //            }
        //        }
        //    }
        //    return itemAssociation;
        //}

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