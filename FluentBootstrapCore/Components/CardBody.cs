using FluentBootstrapCore.Enums;
using System.Collections.Generic;
using System.Linq;

namespace FluentBootstrapCore.Components
{
    public class CardBody(string? title = null, string? subtitle = null) : BootstrapComponent("div", Css.CardBody)
    {
        internal object? Title { get; set; } = title;
        internal object? Subtitle { get; set; } = subtitle;
        internal string? CardText { get; set; }
        internal IEnumerable<Link> CardLinks { get; set; } = [];

        protected override void PreBuild()
        {
            if (Title != null)
            {
                var h5 = new Heading(5)
                {
                    Content = Title
                };

                h5.AddCss(Css.CardTitle);
                AddChild(h5, ChildLocation.Header);
            }

            if (Subtitle != null)
            {
                var h6 = new Heading(6)
                {
                    Content = Subtitle
                };
                h6.AddCss(Css.CardSubtitle, Css.Mb2, Css.TextMuted);
                AddChild(h6, ChildLocation.Header);
            }

            if (Content is string)
            {
                var p = new HtmlElement("p", Css.CardText)
                {
                    Content = Content
                };
                Content = p;
            }

            if (CardLinks.Any())
            {
                foreach (var link in CardLinks)
                {
                    AddChild(link, ChildLocation.Footer);
                }
            }

            base.PreBuild();
        }
    }
}