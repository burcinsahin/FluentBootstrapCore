using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class List : HtmlComponent,
        ICanCreate<ListItem>
    {
        public List(ListType listType)
            : base(listType == ListType.Ordered ? "ol" : "ul", Css.ListUnstyled)
        {
            //if (listType == ListType.Ordered)
            //    SetNumbered();
        }

        public List SetInline()
        {
            AddCss(Css.ListInline);
            return this;
        }
    }
}
