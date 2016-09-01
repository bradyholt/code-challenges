using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintFibonacciSequence(10);
        }

        public static void PrintFibonacciSequence(int count)
        {
            int a = 0;
            int b = 1;

            Console.WriteLine(a.ToString());

            for (int i = 0; i <= count; i++){
                int currentResult = (a + b);
                Console.WriteLine(currentResult.ToString());

                a = b;
                b = currentResult;
            }
        }
    }
}