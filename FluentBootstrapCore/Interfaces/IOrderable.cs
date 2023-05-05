using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Interfaces
{
    public interface IOrderable
    {
        Order? Order { get; set; }
    }
}