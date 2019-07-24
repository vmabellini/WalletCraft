using System;
using System.Collections.Generic;
using System.Text;

namespace WalletCraft.Core
{
    public class ElipticCurvePointFinite : Equality<ElipticCurvePointFinite>
    {
        private readonly FiniteField _x;
        private readonly FiniteField _y;
        private readonly FiniteField _a;
        private readonly FiniteField _b;

        public ElipticCurvePointFinite(FiniteField x, FiniteField y, FiniteField a, FiniteField b)
        {
            _x = x;
            _y = y;
            _a = a;
            _b = b;

            //Constraint
            //y2 = x3 + ax + b

            if (a.Prime != b.Prime || (a.Prime != x.Prime && x != null) || (a.Prime != y.Prime && y != null))
                throw new ArgumentException("All Finite Fields must have the same prime number");

            if (Infinity)
                return;

            if ((y * y) != (x * x * x) + (a * x) + b)
                throw new ArgumentException("Invalid values for a eliptic curve");
        }


        public FiniteField A => _a;

        public FiniteField B => _b;

        public FiniteField X => _x;

        public FiniteField Y => _y;

        public bool Infinity => _x == null && _y == null;

        public static ElipticCurvePointFinite operator +(ElipticCurvePointFinite first, ElipticCurvePointFinite second)
        {
            if (first.A != second.A || first.B != second.B)
                throw new ArgumentException("The points aren't on the same curve");

            if (first.Infinity)
                return second;
            if (second.Infinity)
                return first;

            //Case 1: self.x == other.x, self.y != other.y
            //Result is point at infinity
            if (first.X == second.X && first.Y != second.Y)
                return new ElipticCurvePointFinite(null, null, first.A, first.B);

            //Case 2: self.x ≠ other.x
            if (first.X != second.X)
            {
                //Formula (x3,y3)==(x1,y1)+(x2,y2)
                var slope = (second.Y - first.Y) / (second.X - first.X);

                var x3 = (slope * slope) - first.X - second.X;

                var y3 = slope * (first.X - x3) - first.Y;

                return new ElipticCurvePointFinite(x3, y3, first.A, first.B);
            }

            //Case 3: self == other
            if (first == second && first.Y.Value > 0)
            {
                var slope = (new FiniteField(3, first.A.Prime) * (first.X * first.X) + first.A) / (new FiniteField(2, first.A.Prime) * first.Y);

                var x3 = (slope * slope) - new FiniteField(2, first.A.Prime) * first.X;

                var y3 = slope * (first.X - x3) - first.Y;

                return new ElipticCurvePointFinite(x3, y3, first.A, first.B);
            }

            //Case 4: self == other and Y == 0
            if (first == second && first.Y.Value == 0)
                return new ElipticCurvePointFinite(null, null, first.A, first.B);

            throw new InvalidOperationException("Addition error - invalid values");
        }

        protected override bool EqualsCore(ElipticCurvePointFinite other)
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
