using System;

namespace FluentBootstrapCore.Interfaces
{
    public interface ISizable<TEnum>
        where TEnum : struct, Enum
    {
        TEnum? Size { get; set; }
    }
}