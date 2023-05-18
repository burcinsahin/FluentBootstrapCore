using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class ModalFooter : BootstrapComponent,
        ICanCreate<Button>
    {
        public ModalFooter()
            : base("div", Css.ModalFooter)
        {
        }
    }
}