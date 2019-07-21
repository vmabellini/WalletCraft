using System;
using System.Collections.Generic;
using System.Text;

namespace WalletCraft.Core
{
    public class ElipticCurvePoint : Equality<ElipticCurvePoint>
    {
        private readonly long _a;
        private readonly long _b;
        private readonly long _x;
        private readonly long _y;

        public ElipticCurvePoint(long a, long b, long x, long y)
        {
            _a = a;
            _b = b;
            _x = x;
            _y = y;
            //Constraint
            //y2 = x3 + ax + b
            if ((y * y) != (x * x * x) + (a * x) + b)
                throw new ArgumentException("Invalid values for a eliptic curve");
        }

        public long A => _a;

        public long B => _b;

        public long X => _x;

        public long Y => _y;

        protected override bool EqualsCore(ElipticCurvePoint other)
        {
            return A == other.A &&
                B == other.B &&
                X == other.X &&
                Y == other.Y;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = _a.GetHashCode();
                hashCode = (hashCode * 397) ^ _b.GetHashCode();
                hashCode = (hashCode * 397) ^ _x.GetHashCode();
                hashCode = (hashCode * 397) ^ _y.GetHashCode();
                return hashCode;
            }
        }
    }
}
