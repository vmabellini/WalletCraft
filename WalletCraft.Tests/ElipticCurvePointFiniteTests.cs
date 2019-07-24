using System;
using System.Collections.Generic;
using System.Text;
using WalletCraft.Core;
using Xunit;

namespace WalletCraft.Tests
{
    public class ElipticCurvePointFiniteTests
    {
        [Fact]
        public void ValidPoint()
        {
            new ElipticCurvePointFinite(
                new FiniteField(192,223), 
                new FiniteField(105, 223), 
                new FiniteField(0, 223), 
                new FiniteField(7, 223));
            new ElipticCurvePointFinite(
                new FiniteField(17, 223),
                new FiniteField(56, 223),
                new FiniteField(0, 223),
                new FiniteField(7, 223));
            new ElipticCurvePointFinite(
                new FiniteField(1, 223),
                new FiniteField(193, 223),
                new FiniteField(0, 223),
                new FiniteField(7, 223));
        }

        [Fact]
        public void InvalidPoint()
        {
            Assert.Throws<ArgumentException>(() => new ElipticCurvePointFinite(
                new FiniteField(200, 223),
                new FiniteField(119, 223),
                new FiniteField(0, 223),
                new FiniteField(7, 223)));
            Assert.Throws<ArgumentException>(() => new ElipticCurvePointFinite(
                new FiniteField(42, 223),
                new FiniteField(99, 223),
                new FiniteField(0, 223),
                new FiniteField(7, 223)));
        }

        public static IEnumerable<object[]> AdditionData = new List<object[]>
        {
            new object[] {
                new ElipticCurvePointFinite(
                    new FiniteField(170, 223),
                    new FiniteField(142, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223)),
                new ElipticCurvePointFinite(
                    new FiniteField(60, 223),
                    new FiniteField(139, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223)),
                new ElipticCurvePointFinite(
                    new FiniteField(220, 223),
                    new FiniteField(181, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223))
            },
            new object[] {
                new ElipticCurvePointFinite(
                    new FiniteField(47, 223),
                    new FiniteField(71, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223)),
                new ElipticCurvePointFinite(
                    new FiniteField(17, 223),
                    new FiniteField(56, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223)),
                new ElipticCurvePointFinite(
                    new FiniteField(215, 223),
                    new FiniteField(68, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223))
            },
            new object[] {
                new ElipticCurvePointFinite(
                    new FiniteField(143, 223),
                    new FiniteField(98, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223)),
                new ElipticCurvePointFinite(
                    new FiniteField(76, 223),
                    new FiniteField(66, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223)),
                new ElipticCurvePointFinite(
                    new FiniteField(47, 223),
                    new FiniteField(71, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223))
            },
        };

        [Theory]
        [MemberData(nameof(AdditionData))]
        public void Addition(ElipticCurvePointFinite a, ElipticCurvePointFinite b, ElipticCurvePointFinite result)
        {
            Assert.True(a + b == result);
        }

        public static IEnumerable<object[]> MultiplicationData = new List<object[]>
        {
            new object[] {
                new ElipticCurvePointFinite(
                    new FiniteField(192, 223),
                    new FiniteField(105, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223)),
                2,
                new ElipticCurvePointFinite(
                    new FiniteField(49, 223),
                    new FiniteField(71, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223))
            },
            new object[] {
                new ElipticCurvePointFinite(
                    new FiniteField(47, 223),
                    new FiniteField(71, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223)),
                4,
                new ElipticCurvePointFinite(
                    new FiniteField(194, 223),
                    new FiniteField(51, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223))
            },
            new object[] {
                new ElipticCurvePointFinite(
                    new FiniteField(47, 223),
                    new FiniteField(71, 223),
                    new FiniteField(0, 223),
                    new FiniteField(7, 223)),
                21,
                new ElipticCurvePointFinite(
                    null,
                    null,
                    new FiniteField(0, 223),
                    new FiniteField(7, 223))
            }
        };

        [Theory]
        [MemberData(nameof(MultiplicationData))]
        public void Multiplication(ElipticCurvePointFinite a, long b, ElipticCurvePointFinite result)
        {
            Assert.Equal(result, a * b);
        }
    }
}
