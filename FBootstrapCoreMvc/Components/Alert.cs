using FBootstrapCoreMvc.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Alert : HtmlComponent
    {
        public bool Dismissible { get; set; }
        public string? Heading { get; internal set; }

        public Alert() : base("div", Css.Alert) 
        { 
        }

        protected override void Initialize()
        {
            if (Heading != null)
            {
                var h4 = new HtmlComponent("h4");
                h4.AppendContent(Heading);
                AddChild(h4, ChildType.Header);
            }
            if (Dismissible)
            {
                AddCss(Css.AlertDismissible, Css.Fade, Css.Show);
                var button = new HtmlComponent("button", Css.BtnClose);
                button.MergeAttribute("data-bs-dismiss", "alert");
                AddChild(button, ChildType.Footer);
            }

            base.Initialize();
        }
    }
}