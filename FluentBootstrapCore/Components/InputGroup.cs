using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class InputGroup : BootstrapComponent,
        ICanCreate<Input>,
        ICanCreate<InputGroupText>,
        ICanCreate<Select>,
        ICanCreate<TextArea>,
        ICanCreate<Button>,
        ICanCreate<Label>,
        ICanCreate<DropdownMenu>,
        ISizable<InputGroupSize>
    {
        public InputGroupSize? Size { get; set; }
        public bool NoWrap { get; set; }

        public InputGroup() : base("div", Css.InputGroup)
        {
        }

        protected override void PreBuild()
        {
            if (Size.HasValue)
                AddCss(Size.GetCssDescription());

            if (NoWrap)
                AddCss(Css.FlexNowrap);

            base.PreBuild();
        }
    }
}
