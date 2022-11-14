using System.IO;

namespace FluentBootstrapCore.Alerts
{
    public class Alert : Tag, IHasTextContent, ICanCreate<AlertLink>
    {
        public bool Dismissible { set; get; }
        public string? Heading { set; get; }

        internal Alert(BootstrapHelper helper)
            : base(helper, "div", Css.Alert, Css.AlertInfo)
        {
            MergeAttribute("role", "alert");
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Dismissible)
            {
                AddCss(Css.AlertDismissible);
            }

            base.OnStart(writer);

            if (Dismissible)
            {
                GetHelper().Element("button").AddAttribute("type", "button")
                    .AddCss(Css.BtnClose, Css.Fade, Css.Show)
                    .AddAttribute("data-bs-dismiss", "alert").AddAttribute("aria-label", "Close")
                    .Component.StartAndFinish(writer);
            }

            if (!string.IsNullOrWhiteSpace(Heading))
            {
                GetHelper().Heading6(Heading).AddCss(Css.AlertHeading).Component.StartAndFinish(writer);
            }
        }
    }
}
