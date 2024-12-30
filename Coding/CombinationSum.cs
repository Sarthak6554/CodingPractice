using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class CombinationSum
    {
        public CombinationSum()
        {
            int[] array = new int[] { 2, 3, 5, 7 };

            List<int> sequence = new List<int>();

            GetCombinationSum(0, sequence, array, array.Count(), 6);
        }

        void GetCombinationSum(int index, List<int> sequence, int[] array, int arrayCount, int targetSum)
        {
            if (index == arrayCount)
            {
                if (targetSum == 0)
                {
                    foreach (int number in sequence)
                    {
                        Console.Write(number + " ");
                    }

                    Console.WriteLine();
                }
                return;
            }


            if (array[index] <= targetSum)
            {
                sequence.Add(array[index]);

                targetSum -= array[index];

                GetCombinationSum(index, sequence, array, arrayCount, targetSum);

                sequence.Remove(array[index]);

                targetSum += array[index];

                // Or
                //sequence.Add(array[index]);
                //GetCombinationSum(index, sequence, array, arrayCount, targetSum - array[index]);
                //sequence.Remove(array[index]);
            }

            GetCombinationSum(index + 1, sequence, array, arrayCount, targetSum);
        }

    }
}
