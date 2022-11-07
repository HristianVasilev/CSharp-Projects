namespace RomanToInteger
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

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
    }
}
