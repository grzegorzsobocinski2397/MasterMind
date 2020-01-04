using MasterMind.Algorithms.Models;
using MasterMind.Algorithms.Strategies;
using System;
namespace MasterMind.Algorithms
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("How many tests do you want to perform?");
            int numberOfTests = int.Parse(Console.ReadLine());
            Console.WriteLine("What's the length of the code?");
            int lengthOfCode = int.Parse(Console.ReadLine());

            BruteForceStrategy bruteForceStrategy = new BruteForceStrategy(numberOfTests, lengthOfCode);
            RunStrategy(bruteForceStrategy);

            ColorEliminationStrategy colorEliminationStrategy = new ColorEliminationStrategy(numberOfTests, lengthOfCode);
            RunStrategy(colorEliminationStrategy);

            HumanStrategy humanStrategy = new HumanStrategy(numberOfTests, lengthOfCode);
            RunStrategy(humanStrategy);

            Console.ReadKey();
        }

        static void RunStrategy(BaseStrategy strategy)
        {
            Result result = strategy.RunTests();

            Console.WriteLine($"{strategy.Name}:");
            Console.WriteLine($"Average: {result.GetAverage()}");
            Console.WriteLine($"Maximum number of tries: {result.GetMax()}");
            Console.WriteLine($"Minimum number of tries: {result.GetMin()}\n");
            
        }
    }
}
