using FluentBootstrapCore.Buttons;
using FluentBootstrapCore.Dropdowns;

namespace FluentBootstrapCore.Forms
{
    public class InputGroupButton : Tag,
        ICanCreate<Button>,
        ICanCreate<Dropdown>
    {
        internal InputGroupButton(BootstrapHelper helper)
            : base(helper, "span"/*, Css.InputGroupBtn*/)
        {
        }
    }
}
