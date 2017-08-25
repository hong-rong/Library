using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CSharp.String
{
    /// <summary>
    /// http://www.w3resource.com/csharp-exercises/string/index.php
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod3()
        {
            string input = "w3resource.com";
            char[] arr = new char[input.Length * 2];
            int j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                arr[j++] = input[i];
                arr[j++] = ' ';//how can I save last space
            }
            Debug.WriteLine(new string(arr, 0, arr.Length - 1));
        }

        [TestMethod]
        public void TestMethod4()
        {
            string input = "w3resource.com";
            char[] arr = new char[input.Length * 2];
            int index = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                arr[index++] = input[i];
                arr[index++] = ' ';
            }
            Debug.WriteLine(new string(arr, 0, arr.Length - 1));
        }

        [TestMethod]
        public void TestMethod5()
        {
            string input = "This is w3resource.com";
            int count = 0;
            input = input.Trim();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ' || input[i] == '\t' || input[i] == '\n') count++;
            }
            Debug.WriteLine("total nubmer of words: {0}", count + 1);
        }

        [TestMethod]
        public void TestMethod6() 
        {
            string s1 = "This is first string";
            string s2 = "This is first string";

            if (s1.Length == s2.Length)
            {

            }
            else 
            {
                
            }
        }
    }
}
