using FBootstrapCoreMvc.Enums;
using System.Collections.Generic;
using System.Linq;

namespace FBootstrapCoreMvc.Components
{
    public class CardBody : HtmlComponent
    {
        internal string? Title { get; set; }
        internal string? Subtitle { get; set; }
        internal string? CardText { get; set; }
        internal IEnumerable<Link> CardLinks { get; set; }
        
        public CardBody(string? title = null, string? subtitle = null)
            : base("div", Css.CardBody)
        {
            Title = title;
            Subtitle = subtitle;
            CardLinks= new List<Link>();
        }

        protected override void Initialize()
        {
            if (Title != null)
            {
                var h5 = new Heading(5);
                h5.AddCss(Css.CardTitle);
                h5.Content = Title;
                AddChild(h5);
            }

            if (Subtitle != null)
            {
                var h6 = new Heading(6);
                h6.AddCss(Css.CardSubtitle, Css.Mb2, Css.TextMuted);
                h6.Content = Subtitle;
                AddChild(h6);
            }

            if (CardText != null) 
            {
                var p = new HtmlElement("p", Css.CardText)
                {
                    Content = CardText
                };
                AddChild(p);
            }

            if (CardLinks.Any()) 
            {
                foreach (var link in CardLinks)
                {
                    AddChild(link, ChildLocation.Footer);
                }
            }

            base.Initialize();
        }
    }
}