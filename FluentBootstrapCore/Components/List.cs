using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class List(ListType listType) : BootstrapComponent(listType == ListType.Ordered ? "ol" : "ul"),
        ICanCreate<ListItem>
    {
        public ListType Type { get; set; } = listType;

        protected override void PreBuild()
        {
            switch (Type)
            {
                case ListType.Unstyled:
                    AddCss(Css.ListUnstyled);
                    break;
                case ListType.Inline:
                    AddCss(Css.ListInline);
                    break;
            }

            base.PreBuild();
        }
    }
}
