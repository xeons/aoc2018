using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2018.Solutions
{
    public class Day2Solution: Solution
    {
        public override string Title => "Inventory Management System";

        public override int Day => 2;

        public override void Run()
        {
            string[] input = File.ReadAllLines(Path.Combine("Input", "Day2Input.txt"));

            Console.WriteLine($"Part 1: {CalculatePart1(input)}");
            Console.WriteLine($"Part 2: {CalculatePart2(input)}");
        }

        private int CalculatePart1(string[] input)
        {
            int value1 = 0, value2 = 0;

            foreach (var s in input)
            {
                bool two = false, three = false;

                var result = s.GroupBy(c => c).Select(c => new { Char = c.Key, Count = c.Count() });
                foreach (var x in result)
                {
                    if (x.Count == 2)
                        two = true;
                    else if (x.Count == 3)
                        three = true;
                }

                if (two) value1++;
                if (three) value2++;
            }

            return value1 * value2;
        }

        private string CalculatePart2(string[] input)
        {
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    var commonChars = CommonChars(input[i], input[j]).ToArray();
                    if (Math.Abs(input[j].Length - commonChars.Length) == 1)
                        return new string(commonChars);
                }
            }

            return result;
        }

        private List<char> CommonChars(string left, string right)
        {
            List<char> identicalList = new List<char>(left.Length);

            for(int i = 0; i < left.Length; i++)
                if (left[i] == right[i])
                    identicalList.Add(left[i]);

            return identicalList;
        }
    }
}
