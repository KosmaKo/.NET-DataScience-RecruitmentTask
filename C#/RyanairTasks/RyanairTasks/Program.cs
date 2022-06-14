using System;
using System.Collections.Generic;

namespace RyanairTasks
{
    internal class Program
    {
        //COMPLEXITY
        //Calculating LeastCommonMultiple takes log2(max(dividerA,dividerB))
        //Sorting in line 33 uses either Heapsorf or Quicksort depending on size of the array (number of partitions to be precise), the coplexity of sorting is n log n
        //Finally after sorting we have to search for Kth biggest number divisible has N complexity however for very long sets of numbers Kth number can be found much quicker.
        //The general complexity is decided by the most complex part, in our case sorting. - n long n + n = n(log(n) + 1) ~ n log n

        static void Main(string[] args)
        {
            List<double?> numbers = new List<double?>
            {
                1.1, 2, 3, 4, 5, 6, 7,null, 30, 60, 120, 150, 180, 210, 240, 270, 300, null, 330, null, 330.1
            };
            double result = KthBiggestNumber(numbers,5);
            Console.WriteLine(result);
        }

        public static double KthBiggestNumber(List<double?> numbers, int indexK, int dividerA = 6, int dividerB = 15)
        {
            //instead of checking both dividers we can use LeastCommonMultiple, additionally in case like 6 and 15, we only have to check division by 30
            int divider = LeastCommonMultiple(dividerA, dividerB);

            //getting rid of non integers and nulls
            List<int> integers = getIntegersFromDoubleList(numbers);

            //at some point we will have to sort our list of numbers to assess which one is K-th biggest, if its done at the beggining finding k=th divisible number will mean that we dont have to look anymore
            integers.Sort();

            //now we look for K=th divisible number

            foreach (var n in integers)
            {
                if (n % divider == 0) indexK--;
                //with assumption that we index from 1
                if (indexK == 1) return n;
            }
            throw new Exception(String.Format("provided list does not contain K-th number that is divisible by {0}, {1}", dividerA, dividerB));
        }

        private static int LeastCommonMultiple(int a , int b )
        {
            int multiplication = a * b;
            
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return multiplication / a;
        }

        static List<int> getIntegersFromDoubleList(List<double?> numbers)
        {
            List<int> list = new List<int>();
            foreach (var n in numbers)
            {
                if (n.HasValue && n % 1 == 0)
                {
                    list.Add((int)n);
                }
            }

            return list;
        }
    }



}
