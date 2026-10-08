using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Bootstrap figure. Renders a &lt;figure class="figure"&gt; element.
    /// Use with <see cref="Image"/> (figure-img) and <see cref="FigureCaption"/> children.
    /// </summary>
    public class Figure : BootstrapComponent,
        ICanCreate<Image>,
        ICanCreate<FigureCaption>
    {
        public Figure()
            : base("figure", Css.Figure)
        {
        }
    }
}
