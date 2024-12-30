using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class Subsequence
    {
        public Subsequence()
        {
            int[] numberArray = new int[] { 3, 1, 2 };

            List<int> sequence = new();

            GetSubsequence(0, ref sequence, numberArray, numberArray.Length);

            // GetSubsequenceWithSumK(0, ref sequence, numberArray, numberArray.Length, 3, 0);

            // GetAnySingleSubsequenceWithSumK(0, ref sequence, numberArray, numberArray.Length, 3, 0);

            // Console.WriteLine(GetCountOfSubsequenceWithSumK(0, numberArray, numberArray.Length, 3, 0));
        }

        /// <summary>
        /// Time complexity - O(2^N*N) Here we are getting 2^N because for every index we have 2 options pick and not pick
        /// And extra N we are using to print the sequence 
        /// Auxilary space complexity - O(N) because at max at any time in stack we have N elements 
        /// </summary>
        public void GetSubsequence(int index, ref List<int> sequence, int[] array, int arrayCount)
        {
            if (index == arrayCount)
            {
                foreach (int number in sequence)
                {
                    Console.Write(number + " ");
                }

                if (sequence.Count == 0)
                    Console.WriteLine("{}");

                Console.WriteLine();
                return;
            }

            //take or pich the particular index into subsequence
            sequence.Add(array[index]);
            GetSubsequence(index + 1, ref sequence, array, arrayCount);
            sequence.Remove(array[index]);

            // not pick, or not take condition, this element is not added to our subsequence 
            GetSubsequence(index + 1, ref sequence, array, arrayCount);
        }

        public void GetSubsequenceWithSumK(int index, ref List<int> sequence, int[] array, int arrayCount, int sum, int sequenceSum)
        {
            if (index == arrayCount)
            {
                if (sequenceSum == sum)
                {
                    foreach (int number in sequence)
                    {
                        Console.Write(number + " ");
                    }

                    Console.WriteLine();
                }
                return;
            }

            sequence.Add(array[index]);
            sequenceSum += array[index];

            GetSubsequenceWithSumK(index + 1, ref sequence, array, arrayCount, sum, sequenceSum);

            sequence.Remove(array[index]);
            sequenceSum -= array[index];

            GetSubsequenceWithSumK(index + 1, ref sequence, array, arrayCount, sum, sequenceSum);
        }

        public bool GetAnySingleSubsequenceWithSumK(int index, ref List<int> sequence, int[] array, int arrayCount, int sum, int sequenceSum)
        {
            if (index == arrayCount)
            {
                if (sequenceSum == sum)
                {
                    foreach (int number in sequence)
                    {
                        Console.Write(number + " ");
                    }

                    Console.WriteLine();

                    return true;
                }
                else
                {
                    return false;
                }

            }

            sequence.Add(array[index]);
            sequenceSum += array[index];

            if (GetAnySingleSubsequenceWithSumK(index + 1, ref sequence, array, arrayCount, sum, sequenceSum))
            {
                return true;
            }

            sequence.Remove(array[index]);
            sequenceSum -= array[index];

            if (GetAnySingleSubsequenceWithSumK(index + 1, ref sequence, array, arrayCount, sum, sequenceSum))
            {
                return true;
            }

            return false;
        }

        public int GetCountOfSubsequenceWithSumK(int index, int[] array, int arrayCount, int sum, int sequenceSum)
        {
            if (index == arrayCount)
            {
                //To optimize the code we have a check, in the case of postive array only
                if (sequenceSum > sum)
                {
                    return 0;
                }

                if (sequenceSum == sum)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            sequenceSum += array[index];

            int LeftSum = GetCountOfSubsequenceWithSumK(index + 1, array, arrayCount, sum, sequenceSum);

            sequenceSum -= array[index];

            int RightSum = GetCountOfSubsequenceWithSumK(index + 1, array, arrayCount, sum, sequenceSum);

            return LeftSum + RightSum;
        }
    }
}
