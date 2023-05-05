using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using FluentBootstrapCore.Options;
using System;

namespace FluentBootstrapCore.Components
{
    public class Card : BootstrapComponent,
        ICanCreate<CardBody>,
        ICanCreate<CardHeader>,
        ICanCreate<CardFooter>
    {
        internal object? Header { get; set; }
        internal object? Footer { get; set; }
        internal bool WrapBody { get; set; }
        internal object? BodyTitle { get; set; }
        internal bool Collapsible { get; set; }
        public TextColor? BodyColor { get; set; }
        //public List<CardBody> CardBodyList { get; set; }
        public Card()
            : base("div", Css.Card)
        {
            //CardBodyList = new List<CardBody>();
            WrapBody = false;
        }

        protected override void PreBuild()
        {
            var uid = $"cb_{DateTime.Now.Ticks}";

            if (Header != null)
            {
                var header = new CardHeader();
                if (Collapsible)
                {
                    var link = new Link();
                    link.MergeAttribute("data-bs-toggle", "collapse");
                    link.MergeAttribute("aria-expanded", "true");
                    link.MergeAttribute("aria-controls", uid.ToString());
                    link.MergeAttribute("href", $"#{uid}");
                    link.Content = Header;
                    header.Content = link;
                }
                else
                    header.Content = Header;
                AddChild(header, ChildLocation.Header);
            }

            if (Footer != null)
            {
                var cardFooter = new CardFooter();
                var footer = cardFooter;
                footer.Content = Footer;
                AddChild(footer, ChildLocation.Footer);
            }

            if (Collapsible)
            {
                var div = new HtmlElement("div", Css.Collapse)
                {
                    Id = uid.ToString()
                };
                AddChild(div, ChildLocation.BodyWrap);
            }

            if (WrapBody)
            {
                var cardBody = new CardBody
                {
                    Title = BodyTitle
                };
                if (BodyColor.HasValue)
                {
                    cardBody.UtilityOptions.AddOrUpdate(new ColorOptions
                    {
                        TextColor = BodyColor
                    });
                }
                AddChild(cardBody, ChildLocation.BodyWrap);
            }

            base.PreBuild();
        }
    }
}
