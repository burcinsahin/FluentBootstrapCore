using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class List : BootstrapComponent,
        ICanCreate<ListItem>
    {
        public ListType Type { get; set; }
        public List(ListType listType)
            : base(listType == ListType.Ordered ? "ol" : "ul")
        {
            Type = listType;
        }

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
