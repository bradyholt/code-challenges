using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> unorderedNumbers = new List<int>() { 4, 5, 17, 1, 2, 2, 9, 8, 3 };

            Console.WriteLine($"Unsorted: {string.Join(" ", unorderedNumbers.ToArray())}");

            List<int> sortedNumbers = Sort(unorderedNumbers);

            Console.WriteLine($"Sorted: {string.Join(" ", sortedNumbers.ToArray())}");
        }

        public static List<int> Sort(List<int> numbers)
        {
            /*
                1. Split the list in half, recursively.
                2. Merge the two recursively split lists, in sorted order. 
            */

            if (numbers.Count() > 1)
            {
                // Split the list in half.
                int half = (numbers.Count() / 2);
                List<int> left = numbers.Take(half).ToList();
                List<int> right = numbers.Skip(half).ToList();

                // Recursively split the lists.
                List<int> leftSorted = Sort(left);
                List<int> rightSorted = Sort(right);

                // Now that we have two recursively split lists, merge them 
                // by combining leftSorted and rightSorted in sorted order.
                var merged = Merge(leftSorted, rightSorted);
                return merged;
            }
            else
            {
                return numbers;
            }
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            /*
                Merge the two list by created a new list that is the ordered result 
                of left and right.  For examp,e, if left if [0, 3, 7] and right is [2, 3, 6]
                the merge result should be [0, 2, 3, 3, 6, 7].
            */

            List<int> sorted = new List<int>();

            int maxCount = Math.Max(left.Count, right.Count);
            while (left.Count > 0 || right.Count > 0)
            {
                int? leftValue = null;
                if (left.Count > 0)
                {
                    leftValue = left[0];
                }

                int? rightValue = null;
                if (right.Count > 0)
                {
                    rightValue = right[0];
                }

                if (leftValue == null || (rightValue.HasValue && rightValue.Value < leftValue.Value))
                {
                    sorted.Add(rightValue.Value);
                    right.RemoveAt(0);
                }
                else if (rightValue == null || leftValue.Value <= rightValue.Value)
                {
                    sorted.Add(leftValue.Value);
                    left.RemoveAt(0);
                }
            }

            return sorted;
        }
    }
}
