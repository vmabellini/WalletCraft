using System;
using System.Collections.Generic;
using System.Text;

namespace WalletCraft.Core
{
    public class ElipticCurvePoint : Equality<ElipticCurvePoint>
    {
        private readonly long? _x;
        private readonly long? _y;
        private readonly long _a;
        private readonly long _b;

        public ElipticCurvePoint(long? x, long? y, long a, long b)
        {
            _x = x;
            _y = y;
            _a = a;
            _b = b;

            //Constraint
            //y2 = x3 + ax + b

            if (Infinity)
                return;

            if ((y * y) != (x * x * x) + (a * x) + b)
                throw new ArgumentException("Invalid values for a eliptic curve");
        }

        public long A => _a;

        public long B => _b;

        public long? X => _x;

        public long? Y => _y;

        public bool Infinity => _x == null && _y == null;

        public static ElipticCurvePoint operator +(ElipticCurvePoint first, ElipticCurvePoint second)
        {
            if (first.A != second.A || first.B != second.B)
                throw new ArgumentException("The points aren't on the same curve");

            if (first.Infinity)
                return second;
            if (second.Infinity)
                return first;

            if (first.X == second.X && first.Y != second.Y) //returns infinity point
                return new ElipticCurvePoint(null, null, first.A, first.B);

            var slope = (second.Y - first.Y) / (second.X - first.X);

            var x3 = (slope * slope) - first.X - second.X;

            var y3 = slope * (first.X - x3) - first.Y;

            return new ElipticCurvePoint(x3, y3, first.A, first.B);
        }

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
