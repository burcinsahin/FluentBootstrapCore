using System;

namespace FluentBootstrapCore.Interfaces
{
    public interface IStatable<TEnum>
        where TEnum : struct, Enum
    {
        TEnum? State { get; set; }
    }
}