using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class PermutationString
    {
        public PermutationString()
        {
            string str = "ABC";

            char[] charArray = str.ToCharArray();

            bool[] boolArray = new bool[charArray.Length];

            List<char> sequence = new List<char>();

            List<string> permutations = new List<string>();

            //GetAllPermutations(ref permutations, sequence, charArray, charArray.Length, boolArray);

            GetAllPermutationsII(0, ref permutations, ref charArray, charArray.Count());

            foreach (string combinationString in permutations)
            {
                Console.Write(combinationString + " ");
            }

        }

        /// <summary>
        /// Time complexity = n! {For all the combination} x n {For the for loop we are using}
        /// Space complexity = O(n) {For the sequence we are using} + O(n) {This extra space is because of the freq[] array. So we need to remove this}
        /// In the space complexity we ignore the permuations list as is is used to stored the ans
        /// Auxilary space {depth of recusion} = O(n)
        /// </summary>
        void GetAllPermutations(ref List<string> permuatations, List<char> sequence, char[] charArray, int charArrayCount, bool[] freq)
        {
            if (sequence.Count() == charArrayCount)
            {
                permuatations.Add(new string(sequence.ToArray()));
                return;
            }

            for (int i = 0; i < charArrayCount; i++)
            {
                if (!freq[i])
                {
                    freq[i] = true;

                    sequence.Add(charArray[i]);

                    GetAllPermutations(ref permuatations, sequence, charArray, charArrayCount, freq);

                    sequence.Remove(charArray[i]);

                    freq[i] = false;
                }
            }

        }

        /// <summary>
        /// Time complexity = n! {For all the combination} x n {For the for loop we are using}
        /// Space complexity = nothing as we are not using any extra space
        /// Auxilary space {depth of recusion} = O(n)
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="permuatations"></param>
        /// <param name="charArray"></param>
        /// <param name="charArrayCount"></param>
        void GetAllPermutationsII(int startIndex, ref List<string> permuatations, ref char[] charArray, int charArrayCount)
        {
            if (startIndex == charArrayCount)
            {
                permuatations.Add(new string(charArray));
                return;
            }
            for (int i = startIndex; i < charArrayCount; i++)
            {
                SwapCharacters(ref charArray, startIndex, i);
                GetAllPermutationsII(startIndex + 1, ref permuatations, ref charArray, charArrayCount);
                SwapCharacters(ref charArray, startIndex, i);
            }
        }

        private void SwapCharacters(ref char[] array, int firstIndex, int secondIndex)
        {
            char temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
