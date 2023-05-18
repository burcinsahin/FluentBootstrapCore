using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Options;

namespace FluentBootstrapCore.Components
{
    public class ModalHeader : BootstrapComponent
    {
        public ModalHeader(object? content = null)
            : base("div", Css.ModalHeader)
        {
            Content = content;
        }

        protected override void PreBuild()
        {
            var h5 = new Heading(1)
            {
                Content = Content
            };

            h5.AddCss(Css.ModalTitle);
            h5.UtilityOptions.Add(new TextOptions() { FontSize = FontSize._5 });
            Content = h5;

            var closeBtn = new Button();
            closeBtn.AddCss(Css.BtnClose);
            closeBtn.MergeAttribute("data-bs-dismiss", "modal");
            closeBtn.MergeAttribute("aria-label", "Close");

            AddChild(closeBtn);

            base.PreBuild();
        }
    }
}