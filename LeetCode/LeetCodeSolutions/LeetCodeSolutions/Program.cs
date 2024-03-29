﻿using LeetCodeSolutions;

Solution solution = new Solution();
//bool isPalindrome = solution.IsPalindrome(new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1)))));
//bool isPalindrome = solution.IsPalindrome(121);
//Console.WriteLine(isPalindrome);

//var kthPalindrome = solution.KthPalindrome(new int[] { 1, 2, 3, 4, 5, 90 }, 3);
//var kthPalindrome = solution.KthPalindrome(new int[] { 3, 421228234, 730303391, 22, 296799274, 610019431, 83, 8, 389148978, 76 }, 6);
//Console.WriteLine(String.Join(", ", kthPalindrome));

//var twoSumResult = solution.TwoSum(new int[] { 3, 2, 3 }, 6);
//Console.WriteLine($"[{String.Join(", ", twoSumResult)}]");

//var addTwoNumbers = solution.AddTwoNumbers(
//    new ListNode(2, new ListNode(4, new ListNode(3))),
//    new ListNode(5, new ListNode(6, new ListNode(4))));
//while (addTwoNumbers != null)
//{
//    Console.Write(addTwoNumbers.val);
//    addTwoNumbers = addTwoNumbers.next;
//}

//var reverse = solution.Reverse(1534236469);
//Console.WriteLine(reverse);

//var myPow = solution.MyPow(2.00000, -2);
//Console.WriteLine(myPow);

//MinStack minStack = new MinStack();
//minStack.Push(2);
//minStack.Push(0);
//minStack.Push(3);

//Console.WriteLine(minStack.GetMin());
//minStack.Pop();
//Console.WriteLine(minStack.GetMin());
//minStack.Pop();
//Console.WriteLine(minStack.GetMin());

//TreeNode treeNode = new TreeNode(1, right: new TreeNode(2, left: new TreeNode(3)));
TreeNode treeNode = null;

var inorder = solution.InorderTraversal(treeNode);
Console.WriteLine($"[{String.Join(", ", inorder)}]");
