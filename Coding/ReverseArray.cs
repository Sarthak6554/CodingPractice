using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class ReverseArray
    {
        public ReverseArray()
        {
            int[] intArray = new int[] { 2, 5, 9, 6, 7 };

            ReverseArrayUsingRecursion(0, intArray, intArray.Length);

            foreach (var item in intArray)
            {
                Console.Write(item + " ");
            }
        }

        internal void ReverseArrayUsingRecursion(int start, int[] intArray, int elementsCount)
        {
            if (start < elementsCount / 2)
            {
                Swap(start, elementsCount - start - 1, intArray);
                ReverseArrayUsingRecursion(start + 1, intArray, elementsCount);
            }
        }

        public void Swap(int index1, int index2, int[] array)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
