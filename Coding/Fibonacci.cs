using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class Fibonacci
    {
        public Fibonacci()
        {
            //Console.Write(FibonacciSeriesUsingRecursion(0, 1, 9, 3));
            Console.Write(FibonacciSeriesUsingRecursion2(8));
        }

        public int FibonacciSeriesUsingRecursion(int first, int second, int number, int currentIndex)
        {
            if (number <= 1)
                return number;

            else if (number == 2 || currentIndex == number)
                return first + second;

            return FibonacciSeriesUsingRecursion(second, first + second, number, currentIndex + 1);
        }

        /// <summary>
        /// Time complexity = O(2^N) as for ever N we are getting 2 more calls
        /// Ex- N = 4 we will get total 9 calls but which is nearly equal to 2^N 
        /// that is 2^4 = 16 which not exactly equal to 9 but its still 2^N 
        /// because of N= 4 we are getting 1, 2, 4, 2 which is exponential
        /// </summary>
        public int FibonacciSeriesUsingRecursion2(int number)
        {
            if (number <= 1)
                return number;

            return FibonacciSeriesUsingRecursion2(number - 1) + FibonacciSeriesUsingRecursion2(number - 2);
        }
    }

}
