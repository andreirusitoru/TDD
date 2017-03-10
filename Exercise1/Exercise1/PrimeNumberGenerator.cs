using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    public class PrimeNumberGenerator
    {
        public List<int> GetPrimeNumbers(int upTo)
        {
            List<int> primeList = new List<int>();

            for (int i = 1; i < upTo; i++)
            {
                if (IsPrime(i))
                {
                    primeList.Add(i);
                }
            }

            return primeList;
        }

        public bool IsPrime(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            else if (n <= 3)
            {
                return true;
            }
            else if (n % 2 == 0 || n % 3 == 0)
            {
                return false;
            }
            int i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }

                i += 6;
            }

            return true;
        }
    }
}
