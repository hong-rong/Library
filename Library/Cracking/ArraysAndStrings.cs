using System;
using System.Linq;
using System.Text;

namespace Cracking
{
    public class ArraysAndStrings
    {
        #region questions
        public bool HasUnique_1(string s)
        {
            if (s == null) throw new ArgumentException();
            var a = new int[256];
            for (var i = 0; i < s.Length; i++)
            {
                a[s[i]]++;
                if (a[s[i]] > 1)
                    return false;
            }
            return true;
        }

        public bool HasUnique_2(string s)
        {
            if (s == null) throw new ArgumentException();
            var vector = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var bit = 1 << (s[i] - 'A');
                if ((vector & bit) > 0) return false;
                vector = vector | bit;
            }
            return true;
        }

        public bool IsPerm_1(string s1, string s2)
        {
            if (s1 == null || s2 == null) throw new ArgumentException();
            var t1 = s1.ToArray();
            var t2 = s2.ToArray();
            Array.Sort(t1);
            Array.Sort(t2);
            if (new string(t1) == new string(t2)) return true;
            return false;
        }

        public bool IsPerm_2(string s1, string s2)
        {
            if (s1 == null || s2 == null) throw new ArgumentException();
            if (s1.Length != s2.Length) return false;
            var count = new int[256];
            for (var i = 0; i < s1.Length; i++)
            {
                count[s1[i]]++;
            }
            for (var j = 0; j < s2.Length; j++)
            {
                count[s2[j]]--;
                if (count[s2[j]] != 0) return false;
            }
            return true;
        }

        public string UnifyUrl(string s, int n)
        {
            if (string.IsNullOrEmpty(s) || n <= 1) return s;

            var t = s.ToArray();
            var index = s.Length - 1;
            for (var i = n - 1; i >= 0; i--)
            {
                if (t[i] != ' ')
                {
                    t[index--] = t[i];
                }
                else
                {
                    t[index--] = '0';
                    t[index--] = '2';
                    t[index--] = '%';
                }
            }

            return new string(t);
        }

        public bool IsPalinPerm_1(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            int min = 'A';
            int max = 'z';
            var table = new int[max - min + 1];
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] >= min && s[i] <= max)
                    table[s[i] - min]++;
            }
            var sum = 0;
            for (var j = 0; j < table.Length; j++)
            {
                sum = sum + table[j] % 2;
            }
            return sum <= 1;
        }

        public bool IsPalinPerm_2(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            var vector = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'A' && s[i] <= 'z')
                {
                    var mask = 1 << (s[i] - 'A');
                    if ((vector & mask) == 0)
                        vector = vector | mask;
                    else
                        vector = vector ^ mask;
                }
            }

            if (vector == 0 || ((vector - 1) & vector) == 0) return true;
            return false;
        }

        public bool IsOneEditAway_1(string s1, string s2)
        {
            if (s1 == null) throw new ArgumentNullException();
            if (s2 == null) throw new ArgumentNullException();
            if (Math.Abs(s1.Length - s2.Length) > 1) return false;
            var oneEditFlag = false;
            if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] != s2[i])
                    {
                        if (oneEditFlag) return false;
                        oneEditFlag = true;
                    }
                }
            }
            if (s1.Length - s2.Length == 1)
            {
                for (int i = 0; i < s2.Length; i++)
                {
                    if (!oneEditFlag)
                    {
                        if (s1[i] != s2[i]) oneEditFlag = true;
                    }
                    else
                    {
                        if (s1[i + 1] != s2[i]) return false;
                    }
                }
            }
            if (s2.Length - s1.Length == 1)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (!oneEditFlag)
                    {
                        if (s1[i] != s2[i]) oneEditFlag = true;
                    }
                    else
                    {
                        if (s1[i] != s2[i + 1]) return false;
                    }
                }
            }
            return true;
        }

        public bool IsOneEditAway_2(string s1, string s2)
        {
            if (s1 == null) throw new ArgumentNullException();
            if (s2 == null) throw new ArgumentNullException();
            if (Math.Abs(s1.Length - s2.Length) > 1) return false;
            var oneEditFlag = false;
            if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] != s2[i])
                    {
                        if (oneEditFlag) return false;
                        oneEditFlag = true;
                    }
                }
            }
            int length = s1.Length < s2.Length ? s1.Length : s2.Length;
            for (int i = 0; i < length; i++)
            {
                if (!oneEditFlag)
                {
                    if (s1[i] != s2[i]) oneEditFlag = true;
                }
                else
                {
                    if (s1.Length > s2.Length && s1[i + 1] != s2[i]) return false;
                    if (s2.Length > s1.Length && s1[i] != s2[i + 1]) return false;
                }
            }
            return true;
        }

        public bool IsOneEditAway(string s1, string s2)
        {
            if (s1 == null) throw new ArgumentNullException();
            if (s2 == null) throw new ArgumentNullException();
            if (Math.Abs(s1.Length - s2.Length) > 1) return false;
            var oneEditFlag = false;
            int length = s1.Length < s2.Length ? s1.Length : s2.Length;
            for (int i = 0; i < length; i++)
            {
                if (!oneEditFlag)
                {
                    if (s1[i] != s2[i]) oneEditFlag = true;
                }
                else
                {
                    if (s1.Length == s2.Length && s1[i] != s2[i]) return false;
                    if (s1.Length > s2.Length && s1[i + 1] != s2[i]) return false;
                    if (s2.Length > s1.Length && s1[i] != s2[i + 1]) return false;
                }
            }
            return true;
        }

        public string Compression(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length <= 2) return s;
            var sb = new StringBuilder();
            int count = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    sb.Append(string.Format("{0}{1}", s[i - 1], count));
                    count = 1;
                }
                else if (i == s.Length - 1)
                {
                    sb.Append(string.Format("{0}{1}", s[i - 1], ++count));
                }
                else
                {
                    count++;
                }
            }
            return sb.Length < s.Length ? sb.ToString() : s;
        }

        public int[][] RotateM(int[][] m)
        {
            if (m == null || m[0].Length != m.Length) throw new ArgumentException("invalid argument");

            //abcd       miea
            //efgh       njfb
            //ijkl  ---> okgc
            //mnop       plhd
            int n = m.Length;
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)//not <= last, each iteration moves three elements
                {
                    int offset = i - first;
                    int top = m[first][i];
                    //left -> top
                    m[first][i] = m[last - offset][first];

                    //bottom -> left
                    m[last - offset][first] = m[last][last - offset];

                    //right -> bottom
                    m[last][last - offset] = m[i][last];

                    //top -> right
                    m[i][last] = top;
                }
            }

            return m;
        }

        public int[][] ZeroM(int[][] matrix, int m, int n)
        {
            if (matrix == null) throw new ArgumentNullException();
            if (m == 0 || n == 0 || (m == 1 && n == 1)) return matrix;
            int mFlag = 0, nFlag = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (i == 0) mFlag = mFlag | 1;
                        else mFlag = mFlag | (1 << i);
                        if (j == 0) nFlag = nFlag | 1;
                        else nFlag = nFlag | (1 << j);
                    }
                }
            }

            int mIndex = 0;
            do
            {
                if ((mFlag & 1) == 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        matrix[mIndex][i] = 0;
                    }
                }
                mFlag = mFlag >> 1;
                mIndex++;
            } while (mFlag != 0);

            int nIndex = 0;
            do
            {
                if ((nFlag & 1) == 1)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[j][nIndex] = 0;
                    }
                }
                nFlag = nFlag >> 1;
                nIndex++;
            } while (nFlag != 0);

            return matrix;
        }

        public int[][] ZeroMOnTheFly(int[][] ma, int m, int n)//m rows * n columns
        {
            if (ma == null) throw new ArgumentNullException("ma");
            if (m == 0 || n == 0 || (m == 1 && n == 1)) return ma;

            bool hasZeroInFirstRow = false;
            bool hasZeroInFirstColumn = false;
            for (int i = 0; i < n; i++)
            {
                if (ma[0][i] == 0)
                {
                    hasZeroInFirstRow = true;
                    break;
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (ma[i][0] == 0)
                {
                    hasZeroInFirstColumn = true;
                    break;
                }
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (ma[i][j] == 0)
                    {
                        ma[i][0] = 0;
                        ma[0][j] = 0;
                    }
                }
            }

            for (int i = 1; i < m; i++)
            {
                if (ma[i][0] == 0)
                {
                    SetZero(ma, true, i, n);
                }
            }
            for (int j = 1; j < n; j++)
            {
                if (ma[0][j] == 0)
                {
                    SetZero(ma, false, j, m);
                }
            }
            if (hasZeroInFirstRow)
            {
                SetZero(ma, true, 0, n);
            }
            if (hasZeroInFirstColumn)
            {
                SetZero(ma, false, 0, m);
            }

            return ma;
        }

        private void SetZero(int[][] ma, bool isRow, int index, int max)
        {
            if (isRow)
            {
                for (int i = 0; i < max; i++)
                {
                    ma[index][i] = 0;
                }
            }
            else//column
            {
                for (int i = 0; i < max; i++)
                {
                    ma[i][index] = 0;
                }
            }
        }

        public bool IsRotation(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) throw new ArgumentException();
            if (s1.Length == s2.Length)
            {
                var cancate = string.Format("{0}{1}", s1, s1);
                if (cancate.Contains(s2)) return true;
            }
            return false;
        }
        #endregion
    }
}
