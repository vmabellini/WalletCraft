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
    }
}
