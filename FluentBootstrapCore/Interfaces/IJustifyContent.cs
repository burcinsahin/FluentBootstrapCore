using System;
using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Interfaces
{
    [Obsolete("Superseded by UtilExtensions.JustifyContent, which uses FlexOptions. Will be removed.")]
    public interface IJustifyContent
    {
        EnumList<JustifyContent>? JustifyContent { get; set; }
    }
}