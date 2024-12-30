using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class SubsetsII
    {
        public SubsetsII()
        {
            int[] array = new int[] { 1, 2, 2, 2, 3, 3 };

            List<int> sequence = new List<int>();

            List<List<int>> subsets = new List<List<int>>();

            //Sort the Array to keep the duplicate elements adjacent to each other
            Array.Sort(array);

            GetSubsetSumII(0, ref sequence, ref subsets, array, array.Count());

            foreach (var subset in subsets)
            {
                foreach (int number in subset)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }

        void GetSubsetSumII(int index, ref List<int> sequence, ref List<List<int>> subsets, int[] array, int arrayCount)
        {
            subsets.Add(new List<int>(sequence));

            for (int i = index; i < arrayCount; i++)
            {
                if (i > index && array[i] == array[i - 1])
                {
                    continue;
                }

                sequence.Add(array[i]);

                GetSubsetSumII(i + 1, ref sequence, ref subsets, array, arrayCount);

                sequence.Remove(array[i]);
            }
        }
    }
}
