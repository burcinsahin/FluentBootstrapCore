using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class List : Component<List>,
        ICanCreate<ListItem>
    {
        public List(IHtmlHelper helper, ListType listType)
            : base(helper, listType == ListType.Ordered ? "ol" : "ul", Css.ListGroup)
        {
            if (listType == ListType.Ordered)
                SetNumbered();
        }

        public List SetNumbered() => AddCss(Css.ListGroupNumbered);

        public List SetHorizontal() => AddCss(Css.ListGroupHorizontal);

    }
}
