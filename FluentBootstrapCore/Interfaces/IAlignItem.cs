using System;
using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Interfaces
{
    [Obsolete("Superseded by UtilExtensions.AlignItems, which uses FlexOptions. Will be removed.")]
    public interface IAlignItem
    {
        EnumList<AlignItems>? AlignItem { get; set; }
    }
}