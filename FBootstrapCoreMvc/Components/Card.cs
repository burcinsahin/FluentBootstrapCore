using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using System;

namespace FBootstrapCoreMvc.Components
{
    public class Card : SingleComponent,
        ICanCreate<CardBody>,
        ICanCreate<CardHeader>,
        ICanCreate<CardFooter>
    {
        internal object? Header { get; set; }
        internal object? Footer { get; set; }
        internal bool HasCardBody { get; set; }
        internal object? BodyTitle { get; set; }
        internal bool Collapsible { get; set; }

        public Card()
            : base("div", Css.Card)
        {
            HasCardBody = true;
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
                var div = new HtmlElement("div", Css.Collapse);
                div.SetId(uid.ToString());
                AddWrappingChild(div, WrapperType.Body);
            }

            if (HasCardBody)
            {
                var cardBody = new CardBody
                {
                    Title = BodyTitle
                };
                //if (Content is string)
                //{
                //    cardBody.Content = Content;
                //}
                AddWrappingChild(cardBody, WrapperType.Body);
            }

            base.PreBuild();
        }
    }
}
