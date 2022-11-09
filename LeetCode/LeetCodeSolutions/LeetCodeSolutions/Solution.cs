namespace LeetCodeSolutions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Numerics;

    public class Solution
    {
        public bool IsPalindrome(ListNode head)
        {
            List<int> list = new List<int>();
            ListNode node = head;
            list.Add(node.val);

            while (node.next != null)
            {
                node = node.next;
                list.Add(node.val);
            }
            var leftPart = list.Take(list.Count / 2).ToArray();
            var rightPartReversed = list.TakeLast(list.Count / 2).Reverse().ToArray();

            for (int i = 0; i < leftPart.Count(); i++)
            {
                if (leftPart[i] != rightPartReversed[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPalindrome(int x)
        {
            var numbers = x.ToString().ToCharArray();

            var leftPart = numbers.Take(numbers.Length / 2).ToArray();
            var rightPartReversed = numbers.TakeLast(numbers.Length / 2).Reverse().ToArray();

            for (int i = 0; i < leftPart.Length; i++)
            {
                if (leftPart[i] != rightPartReversed[i])
                {
                    return false;
                }
            }
            return true;
        }

        public long[] KthPalindrome(int[] queries, int intLength)
        {
            int n = queries.Length;
            long[] result = new long[n];
            long maxNumber = 0;
            for (int i = 0; i < intLength; i++)
            {
                maxNumber = maxNumber * 10 + 9;
            }

            for (int i = 0; i < n; i++)
            {
                int nth = queries[i];
                int k = intLength;

                long temp = ((k & 1) == 1) ? (k / 2) : (k / 2 - 1);
                long palin = (long)Math.Pow(10, temp);

                palin += nth - 1;
                temp = palin;
                if ((k & 1) == 1)
                {
                    palin /= 10;
                }

                while (palin > 0)
                {
                    temp = temp * 10 + palin % 10;
                    palin /= 10;
                }

                if (maxNumber < temp || temp < 0)
                {
                    temp = -1;
                }
                result[i] = temp;
            }
            return result;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            StringBuilder firstNumber = new StringBuilder();
            StringBuilder secondNumber = new StringBuilder();
            while (l1 != null)
            {
                firstNumber.Append(l1.val.ToString());
                l1 = l1.next;
            }

            while (l2 != null)
            {
                secondNumber.Append(l2.val.ToString());
                l2 = l2.next;
            }

            string firstNumberText = string.Join(string.Empty, firstNumber.ToString().Trim().Reverse());
            string secondNumberText = string.Join(string.Empty, secondNumber.ToString().Trim().Reverse());

            var result = (BigInteger.Parse(firstNumberText) + BigInteger.Parse(secondNumberText)).ToString();
            ListNode resultNode = null;

            for (int i = 0; i < result.Length; i++)
            {
                resultNode = new ListNode(int.Parse(result[i].ToString()), resultNode);
            }
            return resultNode;
        }

        public int Reverse(int x)
        {
            string intAsString = x.ToString();
            StringBuilder sb = new StringBuilder();

            if (intAsString.StartsWith("-"))
            {
                intAsString = intAsString.Replace("-", string.Empty);
                sb.Append("-");
            }

            for (int i = intAsString.Length - 1; i >= 0; i--)
            {
                sb.Append(intAsString[i].ToString());
            }
            int result = 0;
            int.TryParse(sb.ToString().Trim(), out result);
            return result;
        }

        public double MyPow(double x, int n)
        {
            if (n == 0 | x == 1) return 1;
            if (x == 0) return 0;

            if (n < 0)
            {
                n = -n;
                x = 1 / x;
            }

            if (n % 2 == 0)
            {
                return MyPow(x * x, n / 2);
            }
            else
            {
                return x * MyPow(x, n - 1);
            }
        }

        #region Help methods
        private bool ArraysAreEqual(char[]? firstArray, char[]? secondArray)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }
            return true;
        }

        private string GetNZeros(int count)
        {
            IEnumerable<char> zeros = Enumerable.Repeat('0', count);
            return string.Join(string.Empty, zeros);
        }
        #endregion
    }
}
