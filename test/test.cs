using System;
using System.Collections.Generic;
using tkor;
using Xunit;

namespace test
{
    public class UtilitiesTest
    {
        [Fact]
        public void TestHelloWorld()
        {
            var result = Utilities.GetHelloWorld();
            Assert.Equal("Hello World ...", result);
        }

        [Fact]
        public void TestCorrectness()
        {
            var input = new List<string>(new string[] {
                "[]{}()",
                "[{]}"
            });

            var result = Utilities.Correctness(input);

            var expected = new List<string>(new string[] {"YES", "NO"});
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestCorrectnessComplex()
        {
            var input = new List<string>(new string[] {
                "[]{}()aa",
                "[{-]}",
                "[{}]}",
                "[]{}(){[{[()]}]}"
            });

            var result = Utilities.Correctness(input);

            var expected = new List<string>(new string[] {"NO", "NO", "NO", "YES"});
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestNumberOfPayment1()
        {
            var coupons = new List<int>(new int[] {1, 3, 46, 1, 3, 9});
            var cost = 47;

            var result = Utilities.NumberOfPayment(coupons, cost);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestNumberOfPayment2()
        {
            var coupons = new List<int>(new int[] {6, 6, 3, 9, 3, 5, 1});
            var cost = 12;

            var result = Utilities.NumberOfPayment(coupons, cost);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestNumberOfPayment3()
        {
            var coupons = new List<int>(new int[] {1, 3, 46, 1, 3, 9});
            var cost = -1;

            var result = Utilities.NumberOfPayment(coupons, cost);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestNumberOfPayment4()
        {
            var coupons = new List<int>(new int[] {-1, 3, 46, 1, 3, 9});
            var cost = 47;

            var result = Utilities.NumberOfPayment(coupons, cost);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestNumGroups1()
        {
            var greatBarrierReefs = new List<string>(new string[] {
                "1100",
                "1110",
                "0110",
                "0001"
            });
            var result = Utilities.NumGroups(greatBarrierReefs);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestNumGroup2()
        {
            var greatBarrierReefs = new List<string>(new string[] {
                "10000",
                "01000",
                "00100",
                "00010",
                "00001"
            });
            var result = Utilities.NumGroups(greatBarrierReefs);
            Assert.Equal(5, result);
        }
    }
}
