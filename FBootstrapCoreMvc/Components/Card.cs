using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Card : HtmlComponent,
        ICanCreate<CardBody>,
        ICanCreate<CardHeader>,
        ICanCreate<CardFooter>
    {
        private CardHeader? _header;
        private CardFooter? _footer;
        internal bool HasCardBody { get; set; }
        public Card()
            : base("div", Css.Card)
        {
            HasCardBody = true;
        }

        protected override void Initialize()
        {
            if (HasCardBody)
            {
                AddChild(new CardBody() { RenderMode = RenderMode.Start }, ChildLocation.Header);
                AddChild(new CardBody() { RenderMode = RenderMode.End }, ChildLocation.Footer);
            }

            base.Initialize();
        }

        protected internal void SetHeader(object content)
        {
            _header = new CardHeader
            {
                Content = content
            };
            AddChild(_header, ChildLocation.Header);
        }

        protected internal void SetFooter(object content)
        {
            _footer = new CardFooter
            {
                Content = content
            };
            AddChild(_header, ChildLocation.Footer);
        }
    }
}
