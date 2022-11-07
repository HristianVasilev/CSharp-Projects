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
            int currentNumber = int.Parse("1" + GetNZeros(intLength - 1));

            List<int> palindromeNumbers = new List<int>();

            while (currentNumber.ToString().Length == intLength)
            {
                var numberAsString = currentNumber.ToString();
                var leftPart = numberAsString.Take(numberAsString.Length / 2).ToArray();
                var rightPartReversed = numberAsString.TakeLast(numberAsString.Length / 2).Reverse().ToArray();

                bool isPalindrom = ArraysAreEqual(leftPart, rightPartReversed);

                if (isPalindrom)
                {
                    palindromeNumbers.Add(currentNumber);
                }
                currentNumber++;
            }

            List<long> result = new List<long>();

            for (int i = 0; i < queries.Length; i++)
            {
                var position = queries[i];
                if (palindromeNumbers.Count >= position)
                {
                    result.Add(palindromeNumbers[position - 1]);
                }
                else
                {
                    result.Add(-1);
                }
            }
            return result.ToArray();
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
