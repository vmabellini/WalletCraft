using System;
using System.Collections.Generic;
using System.Text;

namespace WalletCraft.Core
{
    public static class ModuloOperation
    {
        public static long Run(long a, long b)
        {
            return ((a %= b) < 0) ? a + b : a;
        }
    }
}
