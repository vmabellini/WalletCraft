using System;
using System.Collections.Generic;
using System.Text;
using WalletCraft.Core;
using Xunit;

namespace WalletCraft.Tests
{
    public class ElipticCurvePointTests
    {
        [Fact]
        public void ValidPoint()
        {
            new ElipticCurvePoint(-1, -1, 5, 7);
            new ElipticCurvePoint(18, 77, 5, 7);
        }

        [Fact]
        public void InvalidPoint()
        {
            Assert.Throws<ArgumentException>(() => new ElipticCurvePoint(2, 4, 5, 7));
            Assert.Throws<ArgumentException>(() => new ElipticCurvePoint(5, 7, 5, 7));
        }

        public static IEnumerable<object[]> AdditionData = new List<object[]>
        {
            new object[] { new ElipticCurvePoint(2, 5, 5, 7), new ElipticCurvePoint(-1, -1, 5, 7), new ElipticCurvePoint(3, -7, 5, 7) },
            new object[] { new ElipticCurvePoint(2, 5, 5, 7), new ElipticCurvePoint(2, -5, 5, 7), new ElipticCurvePoint(null, null, 5, 7) },
            new object[] { new ElipticCurvePoint(-1, -1, 5, 7), new ElipticCurvePoint(-1, -1, 5, 7), new ElipticCurvePoint(18, 77, 5, 7) },
        };

        [Theory]
        [MemberData(nameof(AdditionData))]
        public void Addition(ElipticCurvePoint a, ElipticCurvePoint b, ElipticCurvePoint result)
        {
            Assert.Equal(result, a + b);
        }
    }
}
