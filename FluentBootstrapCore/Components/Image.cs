namespace FluentBootstrapCore.Components
{
    public class Image : BootstrapComponent
    {
        public string? Source { get; set; }
        public string? Alt { get; set; }
        public bool Fluid { get; set; }
        public bool Thumbnail { get; set; }
        public Image()
            : base("img")
        {
        }

        protected override void PreBuild()
        {
            if (Source != null)
                MergeAttribute("src", Source);

            if (Alt != null)
                MergeAttribute("alt", Alt);

            if (Fluid)
                AddCss(Css.ImgFluid);

            if (Thumbnail)
                AddCss(Css.ImgThumbnail);

            base.PreBuild();
        }
    }
}