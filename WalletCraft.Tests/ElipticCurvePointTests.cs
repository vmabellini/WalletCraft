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
            new ElipticCurvePoint(5, 7, -1, -1);
            new ElipticCurvePoint(5, 7, 18, 77);
        }

        [Fact]
        public void InvalidPoint()
        {
            Assert.Throws<ArgumentException>(() => new ElipticCurvePoint(5, 7, 2, 4));
            Assert.Throws<ArgumentException>(() => new ElipticCurvePoint(5, 7, 5, 7));
        }
    }
}
