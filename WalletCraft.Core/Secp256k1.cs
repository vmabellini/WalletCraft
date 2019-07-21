using System;
using System.Collections.Generic;
using System.Text;

namespace WalletCraft.Core
{
    public class Secp256k1 : ElipticCurvePoint
    {
        public Secp256k1(long x, long y) : base(0, 7, x, y)
        {
        }
    }
}
