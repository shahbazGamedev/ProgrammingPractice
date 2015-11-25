using System;
using LinkedList;

namespace MergeSort
{
    public static class LinkedListExtensions
    {
        public static LinkedList<T> Sort<T>(this LinkedList<T> list, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                LinkedList<T> result = new LinkedList<T>();
                result.AddLast(list[startIndex]);
                return result;
            }
 
            int splitIndex = startIndex + (endIndex - startIndex) / 2;

            LinkedList<T> left = Sort(list, startIndex, splitIndex);
            LinkedList<T> right = Sort(list, splitIndex + 1, endIndex);

            return Merge(left, right);
        }

        private static LinkedList<T> Merge<T>(LinkedList<T> left, LinkedList<T> right)
        {
            LinkedList<T> result = new LinkedList<T>();

            int leftIterator = 0;
            int rightIterator = 0;

            // not needed if the list implements iteration logic
            bool leftIterated = (leftIterator != 0) && (leftIterator == left.Count);
            bool rightIterated = (rightIterator != 0) && (rightIterator == right.Count);

            while (!(leftIterated && rightIterated))
            {
                if (leftIterated)
                {
                    result.AddLast(right[rightIterator]);
                    rightIterator++;
                }
                else if (rightIterated)
                {
                    result.AddLast(left[leftIterator]);
                    leftIterator++;
                }
                else if (left.Compare(left[leftIterator], right[rightIterator]) >= 0)
                {
                    result.AddLast(left[leftIterator]);
                    leftIterator++;
                }
                else
                {
                    result.AddLast(right[rightIterator]);
                    rightIterator++;
                }

                leftIterated = (leftIterator != 0) && (leftIterator == left.Count);
                rightIterated = (rightIterator != 0) && (rightIterator == right.Count);
            }

            return result;
        }
    }
}

