using System;
using System.Collections.Generic;
using System.Text;
using WalletCraft.Core;
using Xunit;

namespace WalletCraft.Tests
{
    public class FiniteFieldTests
    {
        [Fact]
        public void Equality()
        {
            Assert.Equal(new FiniteField(2, 17), new FiniteField(2, 17));
            Assert.NotEqual(new FiniteField(2, 17), new FiniteField(3, 17));
            Assert.NotEqual(new FiniteField(2, 17), new FiniteField(2, 13));
        }
    }
}
