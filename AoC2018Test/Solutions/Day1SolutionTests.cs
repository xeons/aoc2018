using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AoC2018.Solutions;

namespace AoC2018Test.Solutions
{
    [TestClass]
    public class Day1SolutionTests
    {
        [TestMethod]
        public void TestPart1()
        {
            Day1Solution target = new Day1Solution();

            // Example 1
            var result = target.CalculatePart1(new string[]
            {
                "+1", "+1", "+1"
            });
            Assert.AreEqual(3, result);

            // Example 2
            result = target.CalculatePart1(new string[]
            {
                "+1", "+1", "-2"
            });
            Assert.AreEqual(0, result);

            // Example 3
            result = target.CalculatePart1(new string[]
            {
                "-1", "-2", "-3"
            });
            Assert.AreEqual(-6, result);
        }

        [TestMethod]
        public void TestPart2()
        {
            Day1Solution target = new Day1Solution();

            // Example 1
            var result = target.CalculatePart2(new string[]
            {
                "+1", "-1"
            });
            Assert.AreEqual(0, result);

            // Example 2
            result = target.CalculatePart2(new string[]
            {
                "+3", "+3", "+4", "-2", "-4"
            });
            Assert.AreEqual(10, result);

            // Example 3
            result = target.CalculatePart2(new string[]
            {
                "-6", "+3", "+8", "+5", "-6"
            });
            Assert.AreEqual(5, result);

            // Example 4
            result = target.CalculatePart2(new string[]
            {
                "+7", "+7", "-2", "-7", "-4"
            });
            Assert.AreEqual(14, result);
        }
    }
}
