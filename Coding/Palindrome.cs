using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class Palindrome
    {
        public Palindrome()
        {
            string str = "aaaaaa";

            char[] charArray = str.ToCharArray();

            if (IsPalindromeCheckUsingRecursion(0, charArray, charArray.Length))
                Console.WriteLine("Palindrome");

            else
                Console.WriteLine("Not Palindrome");

        }

        bool IsPalindromeCheckUsingRecursion(int start, char[] charArray, int arrayCount)
        {
            if (start > arrayCount / 2)
                return true;

            if (charArray[start] != charArray[arrayCount - start - 1])
                return false;

            return IsPalindromeCheckUsingRecursion(start + 1, charArray, arrayCount);
        }
    }
}
