using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class CombinationSumII
    {
        public CombinationSumII()
        {
            int[] array = new int[] { 1, 2, 1, 1, 2 };
            List<int> sequence = new List<int>();

            HashSet<List<int>> hashsetcombinations = new HashSet<List<int>>();

            List<List<int>> listCombinations = new List<List<int>>();


            //Sort the given array
            Array.Sort(array);

            // Given array in sorted order
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n");

            //GetCombinationSumII(0, ref sequence, ref hashsetcombinations, array, array.Count(), 4);
            //foreach (var number in hashsetcombinations)
            //{
            //    foreach (int item in number)
            //    {
            //        Console.Write(item + " ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine();

            GetCombinationSumIIWithoutHashSet(0, ref sequence, ref listCombinations, array, array.Count(), 4);
            foreach (var number in listCombinations)
            {
                foreach (int item in number)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// The time complexity of this approch because will be (2^n)klog(hashset size)
        /// Here this log(Hashset) is extra so we need to remove this
        /// </summary>
        void GetCombinationSumII(int index, ref List<int> sequence, ref HashSet<List<int>> hashsetcombinations, int[] array, int arrayCount, int targetSum)
        {
            if (index == arrayCount)
            {
                if (targetSum == 0)
                {
                    hashsetcombinations.Add(new List<int>(sequence));
                }
                return;
            }

            if (array[index] <= targetSum)
            {
                sequence.Add(array[index]);

                GetCombinationSumII(index + 1, ref sequence, ref hashsetcombinations, array, arrayCount, targetSum - array[index]);

                sequence.Remove(array[index]);
            }
            GetCombinationSumII(index + 1, ref sequence, ref hashsetcombinations, array, arrayCount, targetSum);
        }

        void GetCombinationSumIIWithoutHashSet(int index, ref List<int> sequence, ref List<List<int>> listCombinations, int[] array, int arrayCount, int targetSum)
        {

            if (targetSum == 0)
            {
                listCombinations.Add(new List<int>(sequence));
                return;
            }

            for (int i = index; i < arrayCount; i++)
            {
                if (i > index && array[i] == array[i - 1])
                {
                    continue;
                }
                if (array[i] > targetSum)
                {
                    break;
                }

                sequence.Add(array[i]);

                GetCombinationSumIIWithoutHashSet(i + 1, ref sequence, ref listCombinations, array, arrayCount, targetSum - array[i]);

                sequence.Remove(array[i]);
            }
        }

    }
}
