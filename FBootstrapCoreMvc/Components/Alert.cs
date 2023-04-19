using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;

namespace FBootstrapCoreMvc.Components
{
    public class Alert : BootstrapComponent
    {
        public bool Dismissible { get; set; }
        public string? Heading { get; set; }
        public AlertState State { get; set; }
        public IconType? IconType { get; set; }
        
        public Alert()
            : base("div", Css.Alert)
        {
            State = AlertState.Primary;
        }

        protected override void PreBuild()
        {
            AddCss(State.GetCssDescription());

            if (Heading != null)
            {
                var h4 = new HtmlElement("h4");
                h4.AppendContent(Heading);
                AddChild(h4, ChildLocation.Header);
            }
            if (IconType.HasValue)
            {
                var icon = new Icon(IconType.Value);
                AddChild(icon, ChildLocation.Header);
            }
            if (Dismissible)
            {
                AddCss(Css.AlertDismissible, Css.Fade, Css.Show);
                var button = new HtmlElement("button", Css.BtnClose);
                button.MergeAttribute("data-bs-dismiss", "alert");
                AddChild(button, ChildLocation.Footer);
            }

            base.PreBuild();
        }
    }
}