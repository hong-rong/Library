using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lib.Common.Al;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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

        [TestMethod]
        public void RenameFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\rocorong\Desktop\ilr\rename");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var info in dir.GetFiles())
            {
                //C:\Users\rocorong\Desktop\ilr\rename\Payslip_28042015.pdf
                Debug.WriteLine(info.FullName);
                char[] newName = new char[info.FullName.Length + 2];
                for (int i = 0; i < info.FullName.Length; i++)
                {
                    newName[i] = info.FullName[i];
                }
                newName[45] = info.FullName[49];
                newName[46] = info.FullName[50];
                newName[47] = info.FullName[51];
                newName[48] = info.FullName[52];
                newName[49] = '-';
                newName[50] = info.FullName[47];
                newName[51] = info.FullName[48];
                newName[52] = '-';
                newName[53] = info.FullName[45];
                newName[54] = info.FullName[46];
                newName[55] = '.';
                newName[56] = 'p';
                newName[57] = 'd';
                newName[58] = 'f';

                //Debug.WriteLine(new string(newName));
                File.Move(info.FullName, new string(newName));
            }
        }
    }
}