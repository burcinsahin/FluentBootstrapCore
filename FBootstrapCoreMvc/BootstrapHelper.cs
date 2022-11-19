using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;

namespace FBootstrapCoreMvc
{
    public class BootstrapHelper<TModel> : IBootstrapHelper
    {
        private readonly IHtmlHelper<TModel> _htmlHelper;

        public IHtmlHelper HtmlHelper => _htmlHelper;

        public BootstrapHelper(IHtmlHelper<TModel> helper)
        {
            _htmlHelper = helper;
        }

        #region Typography
        public HtmlElement Div()
        {
            return new HtmlElement(HtmlHelper, "div");
        }

        public List List(ListType listType = ListType.Unstyled)
        {
            return new List(HtmlHelper, listType);
        }
        #endregion

        public Container Container()
        {
            return new Container(HtmlHelper);
        }

        ///// <summary>
        ///// Card is new version of old Panel
        ///// </summary>
        ///// <returns></returns>
        //public Card Card(string? header = null, string? footer = null)
        //{
        //    var card = new Card(HtmlHelper);
        //    if (header != null)
        //        card.SetHeader(header);
        //    if (footer != null)
        //        card.SetFooter(footer);
        //    return card;
        //}

        public Navbar Navbar()
        {
            var navbar = new Navbar(HtmlHelper);
            return navbar;
        }

        public Component Element(string tagName, string text)
        {
            var element = new Component(HtmlHelper, tagName);
            element.InnerHtml.SetContent(text);
            return element;
        }

        public Input Hidden(string? name = null, object? value = null)
        {
            var input = new Input(HtmlHelper);
            input.SetType(FormInputType.Hidden);
            input.MergeAttribute("name", name);
            input.MergeAttribute("value", value?.ToString());
            return input;
        }

        public Image Image(string src, string? alt = null)
        {
            return new Image(HtmlHelper).AddAttribute("src", src).AddAttribute("alt", alt);
        }

        public Component Paragraph()
        {
            //TODO:
            var p = new Component(HtmlHelper, "p");
            return p;
        }

        public Link Link(object? content, string href = "#")
        {
            return new Link(HtmlHelper, content).SetHref(href);
        }

        public Link Link(string text, string action, string controller, object routeValues = null)
        {
            var link = new Link(HtmlHelper, text);
            var urlHelper = HtmlHelper.GetUrlHelper();
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            link.MergeAttribute("href", url);
            return link;
        }

        public LinkButton LinkButton(string text, string action, string controller, object routeValues = null)
        {
            var linkButton = new LinkButton(HtmlHelper, ButtonState.Primary, text);
            var htmlHelper = HtmlHelper;
            var urlHelperFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            var urlHelper = urlHelperFactory?.GetUrlHelper(htmlHelper.ViewContext);
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            linkButton.MergeAttribute("href", url);
            return linkButton;
        }

        public Form<TModel> Form()
        {
            return new Form<TModel>(_htmlHelper);
        }

        public Form<TModel> Form(string action, string controller, FormMethod method = FormMethod.Post, object routeValues = null)
        {
            var htmlHelper = HtmlHelper;
            var urlHelperFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            var urlHelper = urlHelperFactory?.GetUrlHelper(htmlHelper.ViewContext);
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            return new Form<TModel>(_htmlHelper).SetAction(url).SetMethod(method.ToString());
        }

        public Table Table()
        {
            return new Table(HtmlHelper);
        }

        public Button Button(ButtonType buttonType = ButtonType.Button, object? value = null)
        {
            var button = new Button();
            button.SetType(buttonType);
            button.SetValue(value);
            return button;
        }

        public CheckBox CheckBox()
        {
            var checkbox = new CheckBox(HtmlHelper);
            return checkbox;
        }

        //public HtmlBuilder<TComponent> Begin<TComponent>(TComponent component)
        //    where TComponent : Component
        //{
        //    return new HtmlBuilder<TComponent>(_htmlHelper, component);
        //}
    }
}
