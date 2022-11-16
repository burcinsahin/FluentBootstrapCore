using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Components
{
    public class Card : Component<Card>,
        ICanCreate<CardBody>,
        ICanCreate<CardHeader>,
        ICanCreate<CardFooter>
    {
        private CardHeader _header;
        private CardFooter _footer;

        public Card(IHtmlHelper helper)
            : base(helper, "div", Css.Card)
        {
        }

        public Card SetHeader(string text)
        {
            _header = new CardHeader(_helper);
            _header.InnerHtml.SetContent(text);
            SetContentHtml();
            return this;
        }

        public Card SetFooter(string text)
        {
            _footer = new CardFooter(_helper);
            _footer.InnerHtml.SetContent(text);
            SetContentHtml();
            return this;
        }

        public Card SetBackground(BackgroundState backgroundState = BackgroundState.Primary)
        {
            AddCssClass(backgroundState.GetCssDescription());
            return this;
        }

        public Card SetState(TextBgState textBgState = TextBgState.Primary)
        {
            AddCssClass(textBgState.GetCssDescription());
            return this;
        }

        private void SetContentHtml()
        {
            InnerHtml.Clear();
            if (_header != null)
                InnerHtml.AppendHtml(_header);
            if (_footer != null)
                InnerHtml.AppendHtml(_footer);
        }
    }
}
