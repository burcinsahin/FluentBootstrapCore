using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class ListGroup : BootstrapComponent,
        ICanCreate<ListGroupItem>
    {
        public bool Flush { get; set; }
        public ListGroup()
            : base("ul", Css.ListGroup)
        {
        }

        protected override void PreBuild()
        {
            // A list group placed directly inside a card must be flush (Bootstrap docs: Cards > List groups)
            if (Flush || HasParent<Card>())
                AddCss(Css.ListGroupFlush);

            base.PreBuild();
        }
    }
}
