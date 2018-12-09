using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2018.Solutions
{
    public class Day3Solution : Solution
    {
        public override string Title => "No Matter How You Slice It";

        public override int Day => 3;

        public override void Run()
        {
            string[] input = File.ReadAllLines(Path.Combine("Input", "Day3Input.txt"));

            Console.WriteLine($"Part 1: {CalculatePart1(input)}");
            Console.WriteLine($"Part 2: {CalculatePart2(input)}");
        }

        public int CalculatePart1(string[] input)
        {
            List<Claim> claims = new List<Claim>();

            int maxX = 0, maxY = 0;
            foreach (var s in input)
            {
                var claim = new Claim(s);
                maxX = Math.Max(maxX, claim.X + claim.Width);
                maxY = Math.Max(maxY, claim.Y + claim.Height);
                claims.Add(claim);
            }

            int[] map = new int[maxX * maxY];
            foreach (Claim claim in claims)
            {
                for (int y = 0; y < claim.Height; y++)
                for (int x = 0; x < claim.Width; x++)
                    map[(maxX * (claim.Y + y)) + (claim.X + x)]++;
            }

            int count = 0;
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (map[y * maxX + x] > 1)
                        count++;
                }
            }

            return count;
        }

        public int CalculatePart2(string[] input)
        {
            List<Claim> claims = new List<Claim>();

            int maxX = 0, maxY = 0;
            foreach (var s in input)
            {
                var claim = new Claim(s);
                maxX = Math.Max(maxX, claim.X + claim.Width);
                maxY = Math.Max(maxY, claim.Y + claim.Height);
                claims.Add(claim);
            }

            int[] map = new int[maxX * maxY];
            foreach (Claim claim in claims)
            {
                for (int y = 0; y < claim.Height; y++)
                for (int x = 0; x < claim.Width; x++)
                    map[(maxX * (claim.Y + y)) + (claim.X + x)]++;
            }

            foreach (Claim claim in claims)
            {
                bool clean = true;

                for (int y = 0; y < claim.Height; y++)
                for (int x = 0; x < claim.Width; x++)
                {
                    if (map[(maxX * (claim.Y + y)) + (claim.X + x)] > 1)
                        clean = false;
                }

                if (clean)
                    return claim.Index;
            }

            return -1;
        }
    }

    public class Claim
    {
        public int Index { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Claim(string line)
        {
            Match match = Regex.Match(line, @"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)");
            if (match.Success)
            {
                Index = int.Parse(match.Groups[1].Value);
                X = int.Parse(match.Groups[2].Value);
                Y = int.Parse(match.Groups[3].Value);
                Width = int.Parse(match.Groups[4].Value);
                Height = int.Parse(match.Groups[5].Value);
            }
        }

        public override string ToString()
        {
            return $"Index: {Index}, Pos: {X},{Y}, Size: {Width}x{Height}";
        }
    }
}
