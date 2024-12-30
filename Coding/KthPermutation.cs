using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class KthPermutation
    {
        public KthPermutation()
        {
            Console.WriteLine(GetKthPermuatation(9, 1101));
        }

        string GetKthPermuatation(int N, int K)
        {
            int fact = 1;

            string result = string.Empty;

            List<int> numbers = new List<int>();

            for (int i = 1; i < N; i++)
            {
                fact = fact * i;
                numbers.Add(i);
            }

            numbers.Add(N);

            K = K - 1;

            while (numbers.Count != 0)
            {
                result = result + numbers[K / fact];
                numbers.RemoveAt(K / fact);

                if (numbers.Count != 0)
                {
                    K = K % fact;
                    fact = fact / numbers.Count();
                }
            }
            return result;
        }
    }
}
