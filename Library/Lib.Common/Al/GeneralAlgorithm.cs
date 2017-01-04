using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Common.Algorithm
{
    public class GeneralAlgorithm
    {
        public static List<List<T>> GetAllSubsets<T>(List<T> set)
        {
            if (set.Count == 1)
            {
                return new List<List<T>>() { set };
            }

            List<List<T>> allSubsets = new List<List<T>>();

            T firstElement = set.First();
            allSubsets.Add(new List<T>() { firstElement });

            List<List<T>> subSets = GetAllSubsets(set.GetRange(1, set.Count - 1));
            allSubsets.AddRange(subSets);

            for (int i = 0; i < subSets.Count; i++)
            {
                List<T> temp = new List<T>() { firstElement };
                temp.AddRange(subSets[i]);

                allSubsets.Add(temp);
            }

            return allSubsets;
        }

        public static string[] GetAllPermutaions(string input)
        {
            if (input.Length == 1)
            {
                return new string[] { input };
            }

            List<string> results = new List<string>();
            string[] subSet = GetAllPermutaions(input.Substring(1, input.Length - 1));
            for (int i = 0; i < subSet.Length; i++)
            {
                string[] subSetPerm = new string[subSet[i].Length + 1];
                for (int j = 0; j < subSetPerm.Length; j++)
                {
                    subSetPerm[j] = subSet[i].Insert(j, input[0].ToString());
                }
                subSetPerm[subSet[i].Length] = subSet[i] + input[0].ToString();

                results.AddRange(subSetPerm);
            }

            return results.ToArray();
        }

        public static string[] GetAllSubstrings(string s)
        {
            throw new NotImplementedException();
        }
    }
}