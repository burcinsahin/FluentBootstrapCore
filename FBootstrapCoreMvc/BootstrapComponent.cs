using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Options;

namespace FBootstrapCoreMvc
{
    /// <summary>
    /// Bootstrap component with bootstrap utilities
    /// </summary>
    public abstract class BootstrapComponent : SingleComponent
    {
        public UtilityOptions UtilityOpts { get; set; }

        protected BootstrapComponent(string tagName, params string[] cssClasses)
            : base(tagName, cssClasses)
        {
            UtilityOpts = new UtilityOptions();
        }

        protected override void PreBuild()
        {
            if (UtilityOpts.BackgroundOpts != null)
            {
                var bgOpts = UtilityOpts.BackgroundOpts;
                if (bgOpts.BgColor.HasValue)
                    AddCss(bgOpts.BgColor.GetCssDescription());
                if (bgOpts.Gradient)
                    AddCss(Css.BgGradient);
                if (bgOpts.Opacity.HasValue)
                    AddCss($"bg-opacity-{bgOpts.Opacity}");
            }

            if (UtilityOpts.BorderOpts != null)
            {
                //TODO: implement
            }

            if (UtilityOpts.ColorOpts != null)
            {
                var colorOpts = UtilityOpts.ColorOpts;
                if (colorOpts.TextColor.HasValue)
                    AddCss(colorOpts.TextColor.GetCssDescription());
                if (colorOpts.Opacity.HasValue)
                    AddCss($"text-opacity-{colorOpts.Opacity}");
            }

            base.PreBuild();
        }
    }
}
