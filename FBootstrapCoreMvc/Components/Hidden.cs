using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Hidden : BaseInput,
        ICanHaveName,
        ICanHaveValue
    {
        public Hidden() : base(FormInputType.Hidden)
        {
        }
    }
}