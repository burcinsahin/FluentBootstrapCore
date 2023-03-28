using System;
using System.Runtime.CompilerServices;

namespace FBootstrapCoreMvc.Extensions
{
    internal static class NumericExtensions
    {
        internal static TPrimitive Trim<TPrimitive>(this TPrimitive val, TPrimitive lowest, TPrimitive highest)
            where TPrimitive : struct, IComparable<TPrimitive>, IEquatable<TPrimitive>
        {
            if (val.CompareTo(lowest) < 0)
                return lowest;
            else if (val.CompareTo(highest) > 0)
                return highest;
            return val;
        }

        internal static TPrimitive? Trim<TPrimitive>(this TPrimitive? val, TPrimitive lowest, TPrimitive highest)
            where TPrimitive : struct, IComparable<TPrimitive>, IEquatable<TPrimitive>
        {
            if (!val.HasValue)
                return default;

            if (val.Value.CompareTo(lowest) < 0)
                return lowest;
            else if (val.Value.CompareTo(highest) > 0)
                return highest;
            return val;
        }
    }
}
