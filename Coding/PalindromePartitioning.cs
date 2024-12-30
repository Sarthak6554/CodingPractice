using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class PalindromePartitioning
    {
        public PalindromePartitioning()
        {
            string str = "aabb";

            List<List<string>> palindromeStrings = new List<List<string>>();

            List<string> sequence = new List<string>();

            DoPalindromePartitioning(0, ref palindromeStrings, ref sequence, str, str.Length);
        }

        void DoPalindromePartitioning(int index, ref List<List<string>> palindromeStrings, ref List<string> sequence, string str, int stringLength)
        {
            if (index == stringLength)
            {
                palindromeStrings.Add(new List<string>(sequence));

                return;
            }

            for (int i = index; i < stringLength; i++)
            {
                if (IsPalindrome(str, index, i))
                {
                    sequence.Add(str.Substring(index, i - index + 1));
                    DoPalindromePartitioning(i + 1, ref palindromeStrings, ref sequence, str, stringLength);
                    sequence.Remove(sequence[sequence.Count - 1]);
                }
            }
        }

        bool IsPalindrome(string str, int index, int partitionIndex)
        {
            while (index <= partitionIndex)
            {
                if (str[index] != str[partitionIndex])
                {
                    return false;
                }
                index++;
                partitionIndex--;
            }
            return true;
        }
    }
}
