using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickSort
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
                1. Pick a value in the list an call it the pivot
                2. Partition the list in two, the left side containing values
                   less that or equal to the pivot and the right side containing values greater than the pivot.
                3. Now, with each of the partitions, recursively do steps 1 and 2 above and store as
                   recursiveLeftPartition and recursiveRightPartition.
                4. Finally, concatnate [recursiveLeftPartition, pivot, recursiveRightPartition] to get the Finally
                   sorted list. 
            */
            
            if (numbers.Count() > 1)
            {
                // Choose a "pivot" that we will use to partition the list.
                // Remove the pivot from the list.
                int pivotIndex = ((numbers.Count() / 2));
                int pivot = numbers[pivotIndex];
                numbers.RemoveAt(pivotIndex);

                // Now, partition the list by placing all values <= to the pivot to the
                // left and those greater than the pivot to the right.
                List<int> leftPartition = new List<int>();
                List<int> rightParition = new List<int>();

                foreach(int currentNum in numbers) {
                    if (currentNum <= pivot) {
                        leftPartition.Add(currentNum);
                    } else {
                        rightParition.Add(currentNum);
                    }
                }

                // Now, recursively partition our partitions.
                List<int> recursiveLeftPartition = Sort(leftPartition);
                List<int> recursiveRightPartition = Sort(rightParition);

                // Combine in order [recursiveLeftPartition, pivot, recursiveRightPartition] to get our sorted list.
                return recursiveLeftPartition
                    .Append(pivot)
                    .Concat(recursiveRightPartition)
                    .ToList();
            }
            else
            {
                return numbers;
            }
        }
    }
}
