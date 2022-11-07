namespace LeetCodeSolutions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net.Http.Headers;

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
    }
}
