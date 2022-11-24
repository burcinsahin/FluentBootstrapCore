using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Card : HtmlComponent,
        ICanCreate<CardBody>,
        ICanCreate<CardHeader>,
        ICanCreate<CardFooter>
    {
        private CardHeader _header;
        private CardFooter _footer;

        public Card()
            : base("div", Css.Card)
        {
        }

        protected internal void SetHeader(object content)
        {
            _header = new CardHeader();
            _header.Content = content;
            AddChild(_header, ChildType.Header);
        }

        protected internal void SetFooter(object content)
        {
            _footer = new CardFooter();
            _footer.Content = content;
            AddChild(_header, ChildType.Footer);
        }

        //public void SetBackground(BackgroundState backgroundState = BackgroundState.Primary)
        //{
        //    AddCss(backgroundState.GetCssDescription());
        //}

        //public void SetState(TextBgState textBgState = TextBgState.Primary)
        //{
        //    AddCss(textBgState.GetCssDescription());
        //}

        //private void SetContentHtml()
        //{
        //    InnerHtml.Clear();
        //    if (_header != null)
        //        InnerHtml.AppendHtml(_header);
        //    if (_footer != null)
        //        InnerHtml.AppendHtml(_footer);
        //}
    }
}
