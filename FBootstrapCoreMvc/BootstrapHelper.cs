using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Xml;

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
        public BootstrapContent<HtmlElement> Div()
        {
            var div = new HtmlElement("div");
            return new BootstrapContent<HtmlElement>(HtmlHelper, div);
        }

        public BootstrapContent<List> List(ListType listType = ListType.Unstyled)
        {
            var list = new List(listType);
            return new BootstrapContent<List>(HtmlHelper, list);
        }
        #endregion

        public BootstrapContent<Container> Container()
        {
            return new BootstrapContent<Container>(HtmlHelper, new Container());
        }

        public BootstrapContent<Navbar> Navbar()
        {
            var navbar = new Navbar();
            return new BootstrapContent<Navbar>(_htmlHelper, navbar);
        }

        public BootstrapContent<HtmlElement> Element(string tagName, string text)
        {
            var element = new HtmlElement(tagName);
            element.SetContent(text);
            return new BootstrapContent<HtmlElement>(_htmlHelper, element);
        }

        public BootstrapContent<Input> Hidden(string? name = null, object? value = null)
        {
            var input = new Input();
            input.SetType(FormInputType.Hidden);
            input.MergeAttribute("name", name);
            input.MergeAttribute("value", value?.ToString());
            return new BootstrapContent<Input>(_htmlHelper, input);
        }

        public BootstrapContent<Image> Image(string src, string? alt = null)
        {
            var image = new Image();
            image.MergeAttribute("src", src);
            image.MergeAttribute("alt", alt);
            return new BootstrapContent<Image>(_htmlHelper, image);
        }

        public BootstrapContent<HtmlElement> Paragraph()
        {
            var p = new HtmlElement("p");
            return new BootstrapContent<HtmlElement>(_htmlHelper, p);
        }

        public Link Link(object? content, string href = "#")
        {
            return new Link(content).SetHref(href);
        }

        public Link Link(string text, string action, string controller, object routeValues = null)
        {
            var link = new Link(text);
            var urlHelper = HtmlHelper.GetUrlHelper();
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            link.MergeAttribute("href", url);
            return link;
        }

        public BootstrapContent<LinkButton> LinkButton(string text, string action, string controller, object routeValues = null)
        {
            var linkButton = new LinkButton(ButtonState.Primary, text);
            var urlHelperFactory = HtmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            var urlHelper = urlHelperFactory?.GetUrlHelper(HtmlHelper.ViewContext);
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            linkButton.MergeAttribute("href", url);
            return new BootstrapContent<LinkButton>(HtmlHelper, linkButton);
        }

        public BootstrapContent<Form> Form()
        {
            var form = new Form();
            return new BootstrapContent<Form>(_htmlHelper, form);
        }

        public BootstrapContent<Form, TModel> Form(string action, string controller, FormMethod method = FormMethod.Post, object routeValues = null)
        {
            var htmlHelper = HtmlHelper;
            var urlHelperFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            var urlHelper = urlHelperFactory?.GetUrlHelper(htmlHelper.ViewContext);
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            var form = new Form();
            form.SetAction(url);
            form.SetMethod(method.ToString());
            return new BootstrapContent<Form, TModel>(_htmlHelper, form);
        }

        //public Table Table()
        //{
        //    return new Table();
        //}

        //public Button Button(ButtonType buttonType = ButtonType.Button, object? value = null)
        //{
        //    var button = new Button();
        //    button.SetType(buttonType);
        //    button.SetValue(value);
        //    return button;
        //}

        //public CheckBox CheckBox()
        //{
        //    var checkbox = new CheckBox(HtmlHelper);
        //    return checkbox;
        //}

        //public HtmlBuilder<TComponent> Begin<TComponent>(TComponent component)
        //    where TComponent : Component
        //{
        //    return new HtmlBuilder<TComponent>(_htmlHelper, component);
        //}
    }
}
