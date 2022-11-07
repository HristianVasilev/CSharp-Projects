namespace LeetCodeSolutions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
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
    }
}
