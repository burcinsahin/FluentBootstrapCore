using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Modal : BootstrapComponent,
        ISizable<ModalSize>
    {
        internal object? Header { get; set; }
        internal bool VCentered { get; set; }
        internal bool Scrollable { get; set; }
        internal bool StaticBackdrop { get; set; }
        public bool Fade { get; set; }
        public bool Show { get; set; }
        public ModalSize? Size { get; set; }
        public Breakpoint? Fullscreen { get; set; }
        public Modal()
            : base("div", Css.Modal)
        {
            Fade = true;
            MergeAttribute("tabindex", "-1");
        }

        protected override void PreBuild()
        {
            var modalDialog = new HtmlElement("div", Css.ModalDialog);

            if (Fade)
                AddCss(Css.Fade);

            if (Show)
                AddCss(Css.Show);

            if (VCentered)
                modalDialog.AddCss(Css.ModalDialogCentered);

            if (Scrollable)
                modalDialog.AddCss(Css.ModalDialogScrollable);

            if (StaticBackdrop)
            {
                MergeAttribute("data-bs-backdrop", "static");
                MergeAttribute("data-bs-keyboard", "false");
            }

            if (Size.HasValue)
                modalDialog.AddCss(Size.GetCssDescription());

            if (Fullscreen.HasValue)
            {
                if (Fullscreen.Equals(Breakpoint.Default))
                    modalDialog.AddCss(Css.ModalFullscreen);
                else
                    modalDialog.AddCss($"modal-fullscreen-{Fullscreen.GetCssDescription()}-down");
            }

            AddChild(modalDialog, ChildLocation.FullWrap);

            var modalContent = new HtmlElement("div", Css.ModalContent);
            AddChild(modalContent, ChildLocation.FullWrap);

            if (Header != null)
            {
                var modalHeader = new ModalHeader(Header);
                AddChild(modalHeader, ChildLocation.Header);
            }

            if (Content != null)
            {
                var modalBody = new ModalBody
                {
                    Content = Content
                };
                Content = modalBody;
            }

            base.PreBuild();
        }
    }
}
