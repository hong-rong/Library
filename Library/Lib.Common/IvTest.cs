using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common
{
    [TestClass]
    public class IvTest
    {
        [TestMethod]
        public void AmTest()
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
    }
}
