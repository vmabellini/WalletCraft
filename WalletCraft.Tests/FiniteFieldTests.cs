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

        public static IEnumerable<object[]> NonEqualityData = new List<object[]>
        {
            new object[] { new FiniteField(3, 17), new FiniteField(2, 17) },
            new object[] { new FiniteField(2, 17), new FiniteField(2, 18) }
        };

        [Theory]
        [MemberData(nameof(EqualityData))]
        public void Equality(FiniteField a, FiniteField b)
        {
            Assert.Equal(a, b);
        }

        [Theory]
        [MemberData(nameof(NonEqualityData))]
        public void NonEquality(FiniteField a, FiniteField b)
        {
            Assert.NotEqual(a, b);
        }
    }
}
