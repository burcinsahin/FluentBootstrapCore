namespace FBootstrapCoreMvc.Components
{
    public class ModalHeader : HtmlComponent
    {
        public ModalHeader(object? content = null)
            : base("div", Css.ModalHeader)
        {
            Content = content;
        }

        protected override void PreBuild()
        {
            var h5 = new Heading(5)
            {
                Content = Content
            };

            Content = h5;

            var closeBtn = new Button();
            closeBtn.AddCss(Css.BtnClose);
            closeBtn.MergeAttribute("data-bs-dismiss", "modal");
            AddChild(closeBtn);

            base.PreBuild();
        }
    }
}