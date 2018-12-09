using System;
using System.Reflection;
using AoC2018.Solutions;

namespace AoC2018
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find all classes inheriting from Solution, create an instance, and execute Run method.
            foreach (Type t in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (t.GetTypeInfo().IsSubclassOf(typeof(Solution)))
                {
                    Solution solution = Activator.CreateInstance(t) as Solution;

                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"Day {solution.Day} - {solution.Title}");
                    Console.WriteLine("-----------------------------------------------------------");

                    solution.Run();

                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}