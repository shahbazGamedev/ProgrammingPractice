// We are given 5 integer numbers. Write a program that checks if there
// is a subset of these 5 numbers which sums to zero. List all such sums.
// E.g. 5,0,-2,-3,1 should print 1. 0 = 0  2. | 5 - 2 - 3 = 0.

using System;
using System.Collections.Generic;

class SumToZero
{
     public static void Main()
    {
        // this algorithm uses a recursive method to calculate if the the current sum of numbers equals the desired one(0)
        // the main list is beign split until it restores its original size
        // each time, the method adds another number to the end of the second list and checks the new sum
        // the programs stops when the original list size counter (countOfNumbers) reaches zero

        List<int> numbersList = new List<int>() { 5, 0, -2, -3, 1 };
        int targetSum = 0;
        int countOfNumbers = numbersList.Count;

        DoSumRecursive(countOfNumbers, targetSum, numbersList, new List<int>());

        Console.WriteLine();
    }

     private static void DoSumRecursive(int countOfNumbers, int targetSum, List<int> numbersList, List<int> partialList)
     {
         // check if the program should end: 
         if (countOfNumbers == 0)
         {
             return;
         }
         else
         {
             countOfNumbers--;
         }

         // set a value to the new sum:
         int newSum = 0;
         foreach (int number in partialList)
         {
             newSum += number;
         }

         // print the new sum if it equals the desired one:
         if (newSum == targetSum && partialList.Count != 0)
         {
             Console.WriteLine(string.Join(" + ", partialList.ToArray()) + " = " + targetSum);
         }

         // make changes to the other lists:
         for (int i = 0; i < numbersList.Count; i++)
         {
             // used for storing the remaining numbers from the original list of numbers (numbersList):
             List<int> remainingNumbersList = new List<int>();
             for (int j = i + 1; j < numbersList.Count; j++)
             {
                 remainingNumbersList.Add(numbersList[j]);
             }

             // represents the original list of numbers (numbersList):
             List<int> partialRecursiveList = new List<int>(partialList);
             partialRecursiveList.Add(numbersList[i]);

             DoSumRecursive(countOfNumbers, targetSum, remainingNumbersList, partialRecursiveList);
         }
     }
}



