using System.Collections.Generic;
using System.Linq;
using LeekCodeProblems;
using NUnit.Framework;

namespace Tests
{
    public class ProblemTests
    {
        [TestCase(new[] {2, 7, 11, 15}, 9, new[] {0, 1})]
        [TestCase(new[] { 2, 7, 11, 15 }, 18, new[] { 1, 2 })]
        [TestCase(new[] { 2, 7, 11, 15 }, 26, new[] { 2, 3 })]
        public void GetTwoSumIndicesTests(int[] nums, int target, int[] expected)
        {
            // Arrange

            // Act
            var actual = Problems.GetTwoSumIndices(nums, target);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] {7, 0, 8})]
        public void SumTwoSingleLinkedListsTests(int[] left, int[] right, int[] expected)
        {
            // Arrange
            Problems.ListNode leftRoot = BuildList(left);
            Problems.ListNode rightRoot = BuildList(right);

            // Act
            Problems.ListNode totalRoot = Problems.SumTwoSingleLinkedLists(leftRoot, rightRoot);
            int[] totalArray = BuildArray(totalRoot);

            // Assert
            CollectionAssert.AreEqual(expected, totalArray);
        }

        private Problems.ListNode BuildList(int[] items)
        {
            if (items.Length == 0)
            {
                return null;
            }
            Problems.ListNode root = new Problems.ListNode(items[0]);
            var temp = root;
            for (int i = 1; i < items.Length; i++)
            {
                temp.Next = new Problems.ListNode(items[i]);
                temp = temp.Next;
            }

            return root;
        }

        private int[] BuildArray(Problems.ListNode root)
        {
            IEnumerable<int> GetItems(Problems.ListNode node)
            {
                while (node != null)
                {
                    yield return node.Val;
                    node = node.Next;
                }
            }

            return GetItems(root).ToArray();
        }

        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        [TestCase(" ", 1)]
        [TestCase("aab", 2)]
        [TestCase("dvdf", 3)]
        public void LengthOfLongestSubstringTests(string input, int expected)
        {
            // Arrange
            
            // Act
            var actual = Problems.LengthOfLongestSubstring(input);
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { 1 }, new[] { 2 }, 1.5)]
        [TestCase(new[] {1, 2}, new[] {2}, 2.0)]
        [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
        [TestCase(new[] { 1, 3, 4 }, new[] { 2 }, 2.5)]
        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 5 }, 3)]
        [TestCase(new[] { 1, 3, 4 }, new[] { 5 }, 3.5)]
        [TestCase(new[] { 1, 2, 8 }, new[] { 2, 4 }, 2)]
        [TestCase(new[] { 1, 2, 8 }, new[] { 3, 4, 6 }, 3.5)]
        [TestCase(new int[] { }, new[] { 1 }, 1)]
        public void FindMedianSortedArraysTests(int[] left, int[] right, double expected)
        {
            // Arrange

            // Act
            var actual = Problems.FindMedianSortedArrays(left, right);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}