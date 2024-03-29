﻿using System;

namespace FluentBootstrapCore.Extensions
{
    internal static class NumericExtensions
    {
        internal static TPrimitive Limit<TPrimitive>(this TPrimitive val, TPrimitive lowest, TPrimitive highest)
            where TPrimitive : struct, IComparable<TPrimitive>, IEquatable<TPrimitive>
        {
            if (val.CompareTo(lowest) < 0)
                return lowest;
            else if (val.CompareTo(highest) > 0)
                return highest;
            return val;
        }

        internal static TPrimitive? Limit<TPrimitive>(this TPrimitive? val, TPrimitive lowest, TPrimitive highest)
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
