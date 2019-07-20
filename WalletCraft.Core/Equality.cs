using System;
using System.Collections.Generic;
using System.Text;

namespace WalletCraft.Core
{
    public abstract class Equality<T>
         where T : Equality<T>
    {
        public override bool Equals(object obj)
        {
            var other = obj as T;

            if (ReferenceEquals(other, null))
                return false;

            return EqualsCore(other);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(Equality<T> a, Equality<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Equality<T> a, Equality<T> b)
        {
            return !(a == b);
        }
    }
}
