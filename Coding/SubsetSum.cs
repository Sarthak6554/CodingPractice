using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class SubsetSum
    {
        public SubsetSum()
        {
            int[] array = new int[] { 3, 1, 2 };

            List<int> subsetSum = new List<int>();

            //Time complexity of this will be 2^N 
            GetSubsetSum(0, ref subsetSum, array, array.Count(), 0);

            //Time complexity of sorting 2^N elements will be 2^Nlog(2^N)
            subsetSum.Sort();

            //Final time complexity will be 2^N + 2^Nlog(2^N)

            foreach (int item in subsetSum)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

        }

        /// <summary>
        /// Time complexity of this will be 2^N but since we need to sort the sum also
        /// Final time complexity will be 2^N + 2^Nlog(2^N)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="subsetSum"></param>
        /// <param name="array"></param>
        /// <param name="arrayCount"></param>
        /// <param name="sum"></param>
        void GetSubsetSum(int index, ref List<int> subsetSum, int[] array, int arrayCount, int sum)
        {
            if (index == arrayCount)
            {
                subsetSum.Add(sum);
                return;
            }

            // Pick the element 
            GetSubsetSum(index + 1, ref subsetSum, array, arrayCount, sum + array[index]);

            // Do-not pick the element
            GetSubsetSum(index + 1, ref subsetSum, array, arrayCount, sum);
        }
    }
}
