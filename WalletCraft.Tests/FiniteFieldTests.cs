using System;
using System.Collections.Generic;
using System.Text;
using WalletCraft.Core;
using Xunit;

namespace WalletCraft.Tests
{
    public class FiniteFieldTests
    {
        public static IEnumerable<object[]> EqualityData = new List<object[]>
        {
            new object[] { new FiniteField(2, 17), new FiniteField(2, 17) }
        };


        [Theory]
        [MemberData(nameof(EqualityData))]
        public void Equality(FiniteField a, FiniteField b)
        {
            Assert.Equal(a, b);
        }

        public static IEnumerable<object[]> NonEqualityData = new List<object[]>
        {
            new object[] { new FiniteField(3, 17), new FiniteField(2, 17) },
            new object[] { new FiniteField(2, 17), new FiniteField(2, 18) }
        };

        [Theory]
        [MemberData(nameof(NonEqualityData))]
        public void NonEquality(FiniteField a, FiniteField b)
        {
            Assert.NotEqual(a, b);
        }

        public static IEnumerable<object[]> AdditionData = new List<object[]>
        {
            new object[] { new FiniteField(44, 57), new FiniteField(33, 57), new FiniteField(20,57) },
        };

        [Theory]
        [MemberData(nameof(AdditionData))]
        public void Addition(FiniteField a, FiniteField b, FiniteField result)
        {
            Assert.True(a + b == result);
        }

        public static IEnumerable<object[]> SubtractionData = new List<object[]>
        {
            new object[] { new FiniteField(9, 57), new FiniteField(29, 57), new FiniteField(37, 57) },
        };

        [Theory]
        [MemberData(nameof(SubtractionData))]
        public void Subtraction(FiniteField a, FiniteField b, FiniteField result)
        {
            Assert.True(a - b == result);
        }

        public static IEnumerable<object[]> MultiplyData = new List<object[]>
        {
            new object[] { new FiniteField(5, 19), new FiniteField(3, 19), new FiniteField(15, 19) },
        };

        [Theory]
        [MemberData(nameof(MultiplyData))]
        public void Multiply(FiniteField a, FiniteField b, FiniteField result)
        {
            Assert.True(a * b == result);
        }

        public static IEnumerable<object[]> DivisionData = new List<object[]>
        {
            new object[] { new FiniteField(3, 31), new FiniteField(24, 31), new FiniteField(4, 31) },
        };

        [Theory]
        [MemberData(nameof(DivisionData))]
        public void Division(FiniteField a, FiniteField b, FiniteField result)
        {
            Assert.True(a / b == result);
        }

        public static IEnumerable<object[]> ExponentiationData = new List<object[]>
        {
            new object[] { new FiniteField(3, 13), 3, new FiniteField(3, 13) },
            new object[] { new FiniteField(7, 13), -3, new FiniteField(8, 13) },
            new object[] { new FiniteField(17, 31), -3, new FiniteField(29, 31) },
        };

        [Theory]
        [MemberData(nameof(ExponentiationData))]
        public void Exponentiation(FiniteField a, long pow, FiniteField result)
        {
            Assert.True(FiniteField.Pow(a, pow) == result);
        }
    }
}
