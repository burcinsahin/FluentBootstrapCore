using System;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface ISizable<TEnum> 
        where TEnum : struct, Enum
    {
        TEnum? Size { get; set; }
    }
}