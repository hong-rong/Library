using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common
{
    [TestClass]
    public class IvTest
    {
        #region Am

        [TestMethod]
        public void AmBaseBallCountTest()
        {
            //throw new ArgumentException("n");
            //string[] blocks = new string[10];
            //blocks[0].Substring()
            //char.Parse(blocks[0]);
            //throw new Exception(string.Format("Invalid symbols: {0}", blocks[0]));

            var blocks = new string[] { "5", "-2", "4", "Z", "X", "9", "+", "+" };
            var result = totalScore_correct(blocks, 8);//27
            Assert.AreEqual(27, result);
        }

        //correct so
        public int totalScore_correct(string[] blocks, int n)
        {
            if (blocks == null || blocks.Length == 0) return 0;
            if (n > blocks.Length) throw new ArgumentException("n");

            int sum = 0;
            Stack<int> past = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int score = 0;
                if (blocks[i][0] == '-') //negtive number
                {
                    score = 0 - int.Parse(blocks[i].Substring(1));
                }
                else if (char.Parse(blocks[i].Trim()) >= 48 && char.Parse(blocks[i].Trim()) <= 57)//integer
                {
                    score = int.Parse(blocks[i]);
                }
                else if (blocks[i] == "X")
                {
                    score = past.Peek() * 2;
                }
                else if (blocks[i] == "+")
                {
                    var last = past.Pop();
                    var lastSecond = past.Peek();
                    score = last + lastSecond;
                    past.Push(last);
                }
                else if (blocks[i] == "Z")
                {
                    score = 0 - past.Peek();
                }
                else
                {
                    throw new Exception(string.Format("Invalid symbols: {0}", blocks[i]));
                }

                sum = sum + score;
                if (blocks[i] != "Z")
                {
                    past.Push(score);
                }
                else
                {
                    past.Pop();
                }
            }
            return sum;
        }

        //original solution which is wrong
        public int totalScore(string[] blocks, int n)
        {
            if (blocks == null || blocks.Length == 0) return 0;
            if (n > blocks.Length) throw new ArgumentException("n");

            int sum = 0;
            int lastScore = 0;
            int lastSecondScore = 0;
            for (int i = 0; i < n; i++)
            {
                int score = 0;
                if (blocks[i][0] == '-') //negtive number
                {
                    score = 0 - int.Parse(blocks[i].Substring(1));
                }
                else if (char.Parse(blocks[i].Trim()) >= 48 && char.Parse(blocks[i].Trim()) <= 57)//integer
                {
                    score = int.Parse(blocks[i]);
                }
                else if (blocks[i] == "X")
                {
                    score = lastScore * 2;
                }
                else if (blocks[i] == "+")
                {
                    score = lastScore + lastSecondScore;
                }
                else if (blocks[i] == "Z")
                {
                    score = 0 - lastScore;
                }
                else
                {
                    throw new Exception(string.Format("Invalid symbols: {0}", blocks[i]));
                }

                sum = sum + score;
                if (blocks[i] != "Z")
                {
                    if (i >= 1)
                    {
                        lastSecondScore = lastScore;
                    }
                    lastScore = score;
                }
            }
            return sum;
        }

        [TestMethod]
        public void AmLargestItemAssociationTest()
        {
            var g = new string[,]
            {
                {"Test1", "Test2"},
                {"Test3", "Test4"},
            };
            var ag = largestItemAssociation(g);
            Assert.AreEqual(2, ag.Length);
            Assert.IsTrue(ag.Contains("Test1"));
            Assert.IsTrue(ag.Contains("Test2"));

            g = new string[,]
            {
                {"Test1", "Test2"},
                {"Test2", "Test3"},
                {"Test2", "Test4"},
                {"Test5", "Test6"}
            };
            ag = largestItemAssociation(g);
            Assert.AreEqual(4, ag.Length);
            Assert.IsTrue(ag.Contains("Test1"));
            Assert.IsTrue(ag.Contains("Test2"));
            Assert.IsTrue(ag.Contains("Test3"));
            Assert.IsTrue(ag.Contains("Test4"));
        }

        public static string[] largestItemAssociation(string[,] itemAssociation)
        {
            if (itemAssociation == null) throw new ArgumentException();

            var length0 = itemAssociation.GetLength(0);
            var length1 = itemAssociation.GetLength(1);
            var itemArr = new HashSet<string>[length0];
            for (int i = 0; i < length0; i++)
            {
                itemArr[i] = new HashSet<string>();
            }
            for (int l0 = 0; l0 < length0; l0++)
            {
                for (int h = 0; h < length0; h++)
                {
                    if (itemArr[h].Any() && IsAssociate(itemArr[h], itemAssociation, l0, length1))
                    {
                        for (int i = 0; i < length1; i++)
                        {
                            if (!itemArr[h].Contains(itemAssociation[l0, i]))
                            {
                                itemArr[h].Add(itemAssociation[l0, i]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < length1; i++)
                        {
                            itemArr[l0].Add(itemAssociation[l0, i]);
                        }
                    }
                }
            }

            return ReturnLargestItemAssociation(itemArr, length0);
        }

        private static bool IsAssociate(HashSet<string> set, string[,] items, int l0, int length1)
        {
            for (int i = 0; i < length1; i++)
            {
                if (set.Contains(items[l0, i])) return true;
            }
            return false;
        }

        private static string[] ReturnLargestItemAssociation(HashSet<string>[] itemArr, int length0)
        {
            int maxCount = -1;
            int maxIndex = 0;
            for (int i = 0; i < length0; i++)
            {
                if (itemArr[i].Count > maxCount)
                {
                    maxCount = itemArr[i].Count;
                    maxIndex = i;
                }
            }
            return itemArr[maxIndex].ToArray();
        }

        //code from live
        private static void JagArr()
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

        #endregion
    }
}
