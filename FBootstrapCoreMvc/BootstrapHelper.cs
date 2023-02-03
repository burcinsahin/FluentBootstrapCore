using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections.Generic;

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

        #region Content
        #region Typography
        public BootstrapContent<Heading> Heading(byte size = 1, object? content = null)
        {
            if (size < 1) size = 1;
            else if (size > 6) size = 6;

            var heading = new Heading(size);
            heading.AppendContent(content);
            return new BootstrapContent<Heading>(HtmlHelper, heading);
        }

        public BootstrapContent<Heading> Heading1(object? content = null) => Heading(1, content);

        public BootstrapContent<Heading> Heading2(object? content = null) => Heading(2, content);

        public BootstrapContent<Heading> Heading3(object? content = null) => Heading(3, content);

        public BootstrapContent<Heading> Heading4(object? content = null) => Heading(4, content);

        public BootstrapContent<Heading> Heading5(object? content = null) => Heading(5, content);

        public BootstrapContent<Heading> Heading6(object? content = null) => Heading(6, content);

        public BootstrapContent<HtmlElement> Lead(object? content = null)
        {
            var lead = new HtmlElement("p", Css.Lead);
            lead.SetContent(content);
            return new BootstrapContent<HtmlElement>(HtmlHelper, lead);
        }

        public BootstrapContent<HtmlElement> Mark(object? content = null)
        {
            var mark = new HtmlElement("mark");
            mark.SetContent(content);
            return new BootstrapContent<HtmlElement>(HtmlHelper, mark);
        }

        public BootstrapContent<HtmlElement> Abbr(object? content = null, bool initialism = false)
        {
            var abbr = new HtmlElement("abbr")
            {
                Content = content
            };
            if (initialism)
                abbr.AddCss(Css.Initialism);
            return new BootstrapContent<HtmlElement>(HtmlHelper, abbr);
        }

        public BootstrapContent<HtmlElement> Blockquote(object? content = null, object? footerContent = null)
        {
            //TODO: Convert to an HtmlComponent
            var figure = new HtmlElement("figure");
            var blockquote = new HtmlElement("blockquote", Css.Blockquote)
            {
                Content = content
            };
            figure.AddChild(blockquote);
            if (footerContent != null)
            {
                var figcaption = new HtmlElement("figcaption", Css.BlockquoteFooter)
                {
                    Content = footerContent
                };
                figure.AddChild(figcaption);
            }
            return new BootstrapContent<HtmlElement>(HtmlHelper, figure);
        }

        public BootstrapContent<List> List(ListType listType = ListType.Unstyled)
        {
            var list = new List(listType);
            return new BootstrapContent<List>(HtmlHelper, list);
        }
        #endregion

        public BootstrapContent<Image> Image(string src, string? alt = null)
        {
            var image = new Image();
            image.MergeAttribute("src", src);
            image.MergeAttribute("alt", alt);
            return new BootstrapContent<Image>(_htmlHelper, image);
        }
        #endregion

        #region Layout
        public BootstrapContent<Container> Container()
        {
            return new BootstrapContent<Container>(HtmlHelper, new Container());
        }
        #endregion

        #region DOM
        public BootstrapContent<HtmlElement> Element(string tagName, object? content = null)
        {
            var element = new HtmlElement(tagName);
            element.SetContent(content);
            return new BootstrapContent<HtmlElement>(_htmlHelper, element);
        }

        public BootstrapContent<HtmlElement> Paragraph(object? content = null)
        {
            var p = new HtmlElement("p") { Content = content };
            return new BootstrapContent<HtmlElement>(_htmlHelper, p);
        }

        public BootstrapContent<HtmlElement> Div()
        {
            var div = new HtmlElement("div");
            return new BootstrapContent<HtmlElement>(HtmlHelper, div);
        }

        public BootstrapContent<HtmlElement> IFrame(string src, string? width = null, string? height = null, byte frameborder = 0)
        {
            var iframe = new HtmlElement("iframe");
            iframe.MergeAttribute("src", src);
            if (width != null)
                iframe.MergeAttribute("width", width);
            if (height != null)
                iframe.MergeAttribute("height", height);
            if (frameborder > 0)
                iframe.MergeAttribute("frameborder", frameborder);
            return new BootstrapContent<HtmlElement>(HtmlHelper, iframe);
        }
        #endregion

        #region Components
        public BootstrapContent<Accordion> Accordion()
        {
            var accordion = new Accordion();
            return new BootstrapContent<Accordion>(HtmlHelper, accordion);
        }

        public BootstrapContent<Alert> Alert(
            object? content = null,
            string? heading = null)
        {
            var component = new Alert
            {
                Heading = heading,
                Content = content
            };
            return new BootstrapContent<Alert>(HtmlHelper, component);
        }

        public BootstrapContent<Badge> Badge(object? content = null)
        {
            var badge = new Badge() { Content = content };
            return new BootstrapContent<Badge>(HtmlHelper, badge);
        }

        public BootstrapContent<Breadcrumb> Breadcrumb(string? divider = null)
        {
            var breadcrumb = new Breadcrumb();
            if (divider != null)
            {
                breadcrumb.MergeStyle("--bs-breadcrumb-divider", $"'{divider}'");
            }
            return new BootstrapContent<Breadcrumb>(HtmlHelper, breadcrumb);
        }

        public BootstrapContent<Button> Button(object? content = null)
        {
            var button = new Button() { Content = content };
            return new BootstrapContent<Button>(_htmlHelper, button);
        }

        public BootstrapContent<ButtonGroup> ButtonGroup()
        {
            var buttonGroup = new ButtonGroup();
            return new BootstrapContent<ButtonGroup>(_htmlHelper, buttonGroup);
        }

        public BootstrapContent<ButtonToolbar> ButtonToolbar()
        {
            var buttonToolbar = new ButtonToolbar();
            return new BootstrapContent<ButtonToolbar>(_htmlHelper, buttonToolbar);
        }

        /// <summary>
        /// Card is new version of old Panel
        /// </summary>
        /// <returns></returns>
        public BootstrapContent<Card> Card(
            string? header = null,
            string? footer = null)
        {
            var card = new Card();
            if (header != null)
                card.Header = header;
            if (footer != null)
                card.Footer = footer;
            return new BootstrapContent<Card>(HtmlHelper, card);
        }

        public BootstrapContent<CheckBox> CheckBox()
        {
            var checkbox = new CheckBox();
            return new BootstrapContent<CheckBox>(HtmlHelper, checkbox);
        }

        public CompositeContent<CheckButton> CheckButton(string? label = null)
        {
            var checkButton = new CheckButton
            {
                Content = label
            };
            return new CompositeContent<CheckButton>(HtmlHelper, checkButton);
        }

        public BootstrapContent<Input> Hidden(string? name = null, object? value = null)
        {
            var input = new Input
            {
                Type = FormInputType.Hidden,
                Name = name,
                Value = value
            };

            return new BootstrapContent<Input>(_htmlHelper, input);
        }

        public BootstrapContent<Icon> Icon(IconType iconType, object? content = null)
        {
            var icon = new Icon(iconType)
            {
                Content = content
            };
            return new BootstrapContent<Icon>(HtmlHelper, icon);
        }
        public BootstrapContent<LinkButton> LinkButton(object? content, string href = "#")
        {
            var linkButton = new LinkButton
            {
                Content = content
            };
            linkButton.MergeAttribute("href", href);
            return new BootstrapContent<LinkButton>(HtmlHelper, linkButton);
        }

        public BootstrapContent<LinkButton> LinkButton(string text, string action, string controller, object? routeValues = null)
        {
            var linkButton = new LinkButton(text);
            var urlHelperFactory = HtmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            var urlHelper = urlHelperFactory?.GetUrlHelper(HtmlHelper.ViewContext);
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            linkButton.MergeAttribute("href", url);
            return new BootstrapContent<LinkButton>(HtmlHelper, linkButton);
        }

        public BootstrapContent<Link> Link(object? content, string href = "#")
        {
            var link = new Link(content)
            {
                Href = href
            };
            return new BootstrapContent<Link>(HtmlHelper, link);
        }

        public BootstrapContent<Link> Link(string text, string action, string controller, object? routeValues = null)
        {
            var link = new Link(text);
            var urlHelper = HtmlHelper.GetUrlHelper();
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            link.MergeAttribute("href", url);
            return new BootstrapContent<Link>(HtmlHelper, link);
        }

        public BootstrapContent<Modal> Modal(
            string? title = null,
            object? content = null)
        {
            var modal = new Modal
            {
                Title = title,
                Content = content
            };
            return new BootstrapContent<Modal>(HtmlHelper, modal);
        }
        public BootstrapContent<Navbar> Navbar()
        {
            var navbar = new Navbar();
            return new BootstrapContent<Navbar>(_htmlHelper, navbar);
        }

        public BootstrapContent<Pagination> Pagination()
        {
            var component = new Pagination();
            return new BootstrapContent<Pagination>(HtmlHelper, component);
        }

        public BootstrapContent<RadioButton> Radio()
        {
            var component = new RadioButton();
            return new BootstrapContent<RadioButton>(HtmlHelper, component);
        }

        public CompositeContent<CheckButton> RadioButton(string? content = null)
        {
            var button = new CheckButton
            {
                Content = content,
                Radio = true
            };
            return new CompositeContent<CheckButton>(HtmlHelper, button);
        }

        public BootstrapContent<Range> Range(int min = 0, int max = 0, double step = 0)
        {
            var component = new Range()
            {
                Min = min,
                Max = max,
                Step = step
            };
            return new BootstrapContent<Range>(HtmlHelper, component);
        }

        public BootstrapContent<Select> Select(string name, IEnumerable<SelectListItem> selectList)
        {
            var select = new Select
            {
                Name = name,
                SelectList = selectList
            };
            return new BootstrapContent<Select>(_htmlHelper, select);
        }

        public BootstrapContent<Table> Table()
        {
            var table = new Table();
            return new BootstrapContent<Table>(HtmlHelper, table);
        }
        #endregion

        #region Forms
        public BootstrapContent<Form> Form()
        {
            var form = new Form();
            return new BootstrapContent<Form>(_htmlHelper, form);
        }

        public BootstrapContent<Form, TModel> Form(string action, string controller, FormMethod method = FormMethod.Post, object? routeValues = null)
        {
            var htmlHelper = HtmlHelper;
            var urlHelperFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            var urlHelper = urlHelperFactory?.GetUrlHelper(htmlHelper.ViewContext);
            var urlActionContext = new UrlActionContext() { Action = action, Controller = controller, Values = routeValues };
            var url = urlHelper?.Action(urlActionContext);
            var form = new Form
            {
                Action = url,
                Method = method.ToString()
            };
            return new BootstrapContent<Form, TModel>(_htmlHelper, form);
        }

        public BootstrapContent<FormCheck> FormCheck(string? label = null)
        {
            var formCheck = new FormCheck
            {
                Label = label
            };
            return new BootstrapContent<FormCheck>(_htmlHelper, formCheck);
        }

        public BootstrapContent<FormRadio> FormRadio(string? label = null)
        {
            var radio = new FormRadio(label);
            return new BootstrapContent<FormRadio>(_htmlHelper, radio);
        }

        #endregion
    }
}
