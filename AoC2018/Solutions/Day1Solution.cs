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
            Dictionary<int, int> frequencyOccurrences = new Dictionary<int, int>();
            int part1Result = 0, part2Result = 0;
            bool part2Flag = false;

            for (var i = 0; i < input.Length; i++)
            {
                part1Result += int.Parse(input[i]);
            }
            Console.WriteLine($"Part 1 Result: {part1Result}");

            part1Result = 0;
            while (!part2Flag)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    part1Result += int.Parse(input[i]);

                    if (!frequencyOccurrences.ContainsKey(part1Result))
                        frequencyOccurrences.Add(part1Result, 0);

                    frequencyOccurrences[part1Result]++;

                    if (frequencyOccurrences[part1Result] > 1)
                    {
                        part2Flag = true;
                        part2Result = part1Result;
                        break;
                    }
                }
            }

            Console.WriteLine($"Part 2 Result: {part2Result}");
        }
    }
}
