namespace FBootstrapCoreMvc.Components
{
    public class NavbarBrand : Link
    {
        public NavbarBrand(string? text = null)
            : base()
        {
            AddCss(Css.NavbarBrand);
            Content = text;
        }
    }
}