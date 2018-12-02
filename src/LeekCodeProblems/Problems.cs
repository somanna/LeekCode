using System;
using System.Diagnostics;
using System.Xml.Xsl;

namespace LeekCodeProblems
{
    public class Problems
    {
        /*
           Given an array of integers, return indices of the two numbers such that they add up to a specific target.
           
           You may assume that each input would have exactly one solution, and you may not use the same element twice.
           
           Example:
           
           Given nums = [2, 7, 11, 15], target = 9,
           
           Because nums[0] + nums[1] = 2 + 7 = 9,
           return [0, 1].
         */
        public static int[] GetTwoSumIndices(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] {i, j};
                    }
                }
            }

            return null;
        }

        /*
           You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
           
           You may assume the two numbers do not contain any leading zero, except the number 0 itself.
           
           Example:
           
           Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
           Output: 7 -> 0 -> 8
           Explanation: 342 + 465 = 807.
         */
        [DebuggerDisplay("{Val}")]
        public class ListNode
        {
            public int Val;
            public ListNode Next;

            public ListNode(int x)
            {
                Val = x;
            }
        }

        public static ListNode SumTwoSingleLinkedLists(ListNode left, ListNode right)
        {
            ListNode first = null;
            ListNode current = null;
            int borrow = 0;
            while (left != null || right != null)
            {
                var sum = borrow + (left?.Val ?? 0) + (right?.Val ?? 0);
                borrow = sum / 10;
                ListNode newNode = new ListNode(sum % 10);
                if (current == null)
                {
                    first = newNode;
                }
                else
                {
                    current.Next = newNode;
                }

                current = newNode;

                left = left?.Next;
                right = right?.Next;
            }

            if (borrow > 0)
            {
                current.Next = new ListNode(borrow);
            }

            return first;
        }

        /*
           Given a string, find the length of the longest substring without repeating characters.
           
           Example 1:
           
           Input: "abcabcbb"
           Output: 3 
           Explanation: The answer is "abc", with the length of 3. 
           Example 2:
           
           Input: "bbbbb"
           Output: 1
           Explanation: The answer is "b", with the length of 1.
           Example 3:
           
           Input: "pwwkew"
           Output: 3
           Explanation: The answer is "wke", with the length of 3. 
           Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
         */
        public static int LengthOfLongestSubstring(string input)
        {
            int maxLength = -1;
            string currentSubstring = string.Empty;
            foreach (var c in input)
            {
                var index = currentSubstring.IndexOf(c);
                if (index >= 0)
                {
                    var currentSubstringLength = currentSubstring.Length;
                    if (maxLength < currentSubstringLength)
                    {
                        maxLength = currentSubstringLength;
                    }

                    var startIndex = index + 1;
                    currentSubstring = startIndex == currentSubstringLength
                        ? string.Empty
                        : currentSubstring.Substring(startIndex, currentSubstringLength - startIndex);
                }

                currentSubstring += c;
            }

            return maxLength < currentSubstring.Length ? currentSubstring.Length : maxLength;
        }

        /*
           There are two sorted arrays nums1 and nums2 of size m and n respectively.
           
           Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
           
           You may assume nums1 and nums2 cannot be both empty.
           
           Example 1:
           
           nums1 = [1, 3]
           nums2 = [2]
           
           The median is 2.0
           Example 2:
           
           nums1 = [1, 2]
           nums2 = [3, 4]
           
           The median is (2 + 3)/2 = 2.5
         */
        public static double FindMedianSortedArrays(int[] left, int[] right)
        {
            if (left.Length < right.Length)
            {
                var temp = left;
                left = right;
                right = temp;
            }

            if (right.Length > 0)
            {
                int li = 0;
                while (li < left.Length)
                {
                    if (left[li] > right[0])
                    {
                        var temp = left[li];
                        left[li] = right[0];
                        right[0] = temp;

                        int ri = 0;
                        for (int i = ri + 1; i < right.Length; i++)
                        {
                            if (right[ri] <= right[i])
                            {
                                break;
                            }

                            temp = right[ri];
                            right[ri] = right[i];
                            right[i] = temp;
                            ri = i;
                        }
                    }

                    li++;
                }
            }

            int totalLength = left.Length + right.Length;
            int medianLeftIndex = -1;
            int medianLeftValue;
            int medianRightIndex = -1;
            int medianRightValue;
            medianRightIndex = totalLength / 2;
            if (totalLength % 2 == 0) // event length
            {
                medianLeftIndex = medianRightIndex - 1;
            }

            medianRightValue = medianRightIndex < left.Length ? left[medianRightIndex] : right[medianRightIndex - left.Length];
            if (medianLeftIndex == -1)
            {
                return medianRightValue;
            }

            medianLeftValue = medianLeftIndex < left.Length ? left[medianLeftIndex] : right[medianLeftIndex - left.Length];
            return (double) (medianLeftValue + medianRightValue) / 2;
        }
    }
}
