using System;

namespace WalletCraft.Core
{
    public class FiniteField : Equality<FiniteField>
    {
        private readonly long _value;
        private readonly long _prime;

        public FiniteField(long value, long prime)
        {
            if (value >= prime)
                throw new ArgumentOutOfRangeException($"Value cannot be greater than prime");

            if (value < 0)
                throw new ArgumentOutOfRangeException($"Value cannot be less than zero");

            _value = value;
            _prime = prime;
        }

        public long Prime => _prime;

        public long Value => _value;

        public static FiniteField operator+(FiniteField a, FiniteField b)
        {
            if (a.Prime != b.Prime)
                throw new ArgumentException("The prime number must be the same");

            var value = ModuloOperation.Run(a.Value + b.Value, a.Prime);
            return new FiniteField(value, a.Prime);
        }

        public static FiniteField operator -(FiniteField a, FiniteField b)
        {
            if (a.Prime != b.Prime)
                throw new ArgumentException("The prime number must be the same");

            var value = ModuloOperation.Run(a.Value - b.Value, a.Prime);
            return new FiniteField(value, a.Prime);
        }

        public static FiniteField operator *(FiniteField a, FiniteField b)
        {
            if (a.Prime != b.Prime)
                throw new ArgumentException("The prime number must be the same");

            var value = ModuloOperation.Run(a.Value * b.Value, a.Prime);
            return new FiniteField(value, a.Prime);
        }

        protected override bool EqualsCore(FiniteField other)
        {
            return _value == other.Value && _prime == other.Prime;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = _value.GetHashCode();
                hashCode = (hashCode * 397) ^ _prime.GetHashCode();
                return hashCode;
            }
        }
    }
}
