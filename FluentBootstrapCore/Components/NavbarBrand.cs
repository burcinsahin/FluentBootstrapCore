namespace FluentBootstrapCore.Components
{
    public class NavbarBrand : Link
    {
        public NavbarBrand(object? content = null)
            : base()
        {
            AddCss(Css.NavbarBrand);
            Content = content;
        }
    }
}