using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Image : BootstrapComponent,
        IColumnizable
    {
        public bool Fluid { get; set; }
        public bool Thumbnail { get; set; }
        public Image()
            : base("img")
        {
        }

        protected override void PreBuild()
        {
            if(Fluid)
                AddCss(Css.ImgFluid);

            if (Thumbnail)
                AddCss(Css.ImgThumbnail);

            base.PreBuild();
        }
    }
}
