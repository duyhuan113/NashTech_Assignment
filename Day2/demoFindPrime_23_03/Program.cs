using System;
using System.Collections.Generic;

namespace demoFindPrime_23_03
{
    class Program
    {
        public static void FindPrime()
        {
            System.Console.WriteLine("Please Enter Random Number: ");
            int inputNumber = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("-----------------------------");

            System.Console.WriteLine("List of Prime Number: ");

            for (int x = 2; x < inputNumber; x++)
            {
                int isPrime = 0;
                for (int y = 1; y < x; y++)
                {
                    if (x % y == 0)
                        isPrime++;

                    if (isPrime == 2) break;
                }
                if (isPrime != 2)
                    Console.WriteLine(x);

                isPrime = 0;
            }

        }
        static void Main(string[] args)
        {
            FindPrime();
        }


    }
}
