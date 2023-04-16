using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Components
{
    public class Modal : BootstrapComponent
    {
        internal string? Title { get; set; }
        internal bool VCentered { get; set; }
        internal bool Scrollable { get; set; }
        internal bool StaticBackdrop { get; set; }

        public Modal()
            : base("div", Css.Modal, Css.Fade)
        {
            MergeAttribute("tabindex", "-1");
        }

        protected override void PreBuild()
        {
            var modalDialog = new HtmlElement("div", Css.ModalDialog);
            if (VCentered)
                modalDialog.AddCss(Css.ModalDialogCentered);

            if (Scrollable)
                modalDialog.AddCss(Css.ModalDialogScrollable);

            if (StaticBackdrop)
            {
                MergeAttribute("data-bs-backdrop", "static");
                MergeAttribute("data-bs-keyboard", "false");
            }

            AddChild(modalDialog, ChildLocation.FullWrap);

            var modalContent = new HtmlElement("div", Css.ModalContent);
            AddChild(modalContent, ChildLocation.FullWrap);

            if (Title != null)
            {
                var modalHeader = new ModalHeader(Title);
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
