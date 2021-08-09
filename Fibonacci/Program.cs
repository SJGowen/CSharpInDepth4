using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceFibonacci
{
    public class Program
    {
        public static void Main()
        {
            

            Console.WriteLine("Is a Number a Fibonacci Number?");
            Console.WriteLine("(Enter 'exit' or '0' to Quit)");
            List<ulong> fibonaccis = SetupFibonaccis();
            ulong usersNumber = 1;
            while (usersNumber != 0)
            {
                Console.Write("Enter your potential Fibonacci Number: ");
                string userTyped = Console.ReadLine();
                if (userTyped.ToLower() == "exit" || userTyped == "0")
                {
                    usersNumber = 0;
                }
                else
                {
                    while (!ulong.TryParse(userTyped, out usersNumber))
                    {
                        IndicateThatInputNotNumeric(fibonaccis, userTyped);
                        Console.Write("Enter your potential Fibonacci Number: ");
                        userTyped = Console.ReadLine();
                    }
                    ShowIfEntryIsAFibonacci(fibonaccis, usersNumber);
                }
            }
        }

        private static List<ulong> SetupFibonaccis()
        {
            List<ulong> fibonaccis = new();
            // If you take any more than 93 you get overflow
            foreach (ulong i in Fibonacci().Take(93))
            {
                fibonaccis.Add(i);
            }

            return fibonaccis;
        }

        private static IEnumerable<ulong> Fibonacci()
        {
            ulong current = 1, next = 1;

            while (true)
            {
                yield return current;
                next = current + (current = next);
            }
        }

        private static void ShowIfEntryIsAFibonacci(List<ulong> fibonaccis, ulong usersNumber)
        {
            if (fibonaccis.IndexOf(usersNumber) == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The number '{usersNumber}' is NOT a Fibonacci Number!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The number '{usersNumber}' is a Fibonacci Number!");
            };
            Console.ResetColor();
        }

        private static void IndicateThatInputNotNumeric(List<ulong> fibonaccis, string userTyped)
        {
            if (userTyped.ToLower() == "showme")
            {
                foreach (var fibonacci in fibonaccis)
                {
                    Console.WriteLine(fibonacci);
                }
            }
            else if (userTyped.Length > 5 && userTyped[0..5].ToLower() == "first")
            {
                if (int.TryParse(userTyped[5..], out var max))
                {
                    max = max > 93 ? 93 : max;
                    for (int i = 0; i < max; i++)
                    {
                        Console.WriteLine(fibonaccis[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine($"The entry made '{userTyped}' is invalid (either too big or not a number)!");
                Console.Write("Please try again. ");
            }
        }
    }
}
