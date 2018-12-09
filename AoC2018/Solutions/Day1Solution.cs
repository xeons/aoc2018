using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018.Solutions
{
    public class Day1Solution : Solution
    {
        public override string Title => "Chronal Calibration";

        public override int Day => 1;

        public override void Run()
        {
            string[] input = File.ReadAllLines(Path.Combine("Input", "Day1Input.txt"));

            Console.WriteLine($"Part 1 Result: {CalculatePart1(input)}");
            Console.WriteLine($"Part 2 Result: {CalculatePart2(input)}");
        }

        public int CalculatePart1(string[] input)
        {
            int sum = 0;

            for (var i = 0; i < input.Length; i++)
                sum += int.Parse(input[i]);

            return sum;
        }

        public int CalculatePart2(string[] input)
        {
            Dictionary<int, int> frequencyOccurrences = new Dictionary<int, int>();
            int sum = 0, result = 0;
            bool foundResult = false;

            frequencyOccurrences.Add(0, 1);
            while (!foundResult)
            {
                foreach (var s in input)
                {
                    sum += int.Parse(s);

                    if (!frequencyOccurrences.ContainsKey(sum))
                        frequencyOccurrences.Add(sum, 0);

                    if (++frequencyOccurrences[sum] > 1)
                    {
                        foundResult = true;
                        result = sum;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
