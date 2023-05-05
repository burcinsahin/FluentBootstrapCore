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
            if (Flush)
                AddCss(Css.ListGroupFlush);

            base.PreBuild();
        }
    }
}
