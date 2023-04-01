using FBootstrapCoreMvc.Enums;
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
            SetBackground();
            SetBorder();
            SetColor();
            SetFloat();
            SetDisplay();
            base.PreBuild();
        }

        private void SetDisplay()
        {
            if (UtilityOpts.DisplayOpts != null)
            {
                var displayOpts = UtilityOpts.DisplayOpts;
                foreach (var item in displayOpts.Display)
                {
                    AddCss(string.Format(item.Value.GetCssDescription(), item.Key.GetHyphenatedDescription()));
                }
                if (displayOpts.DisplayPrint.HasValue)
                    AddCss(displayOpts.DisplayPrint.GetCssDescription());
            }
        }

        #region Utility Methods
        private void SetFloat()
        {
            if (UtilityOpts.FloatOpts != null)
            {
                var floatOpts = UtilityOpts.FloatOpts;
                foreach (var item in floatOpts.Float)
                {
                    var floatCss = string.Format(item.Value.GetCssDescription(), item.Key.GetHyphenatedDescription());
                    AddCss(floatCss);
                }
            }
        }

        private void SetColor()
        {
            if (UtilityOpts.ColorOpts != null)
            {
                var colorOpts = UtilityOpts.ColorOpts;
                if (colorOpts.TextColor.HasValue)
                    AddCss(colorOpts.TextColor.GetCssDescription());
                if (colorOpts.Opacity.HasValue)
                    AddCss($"text-opacity-{colorOpts.Opacity}");
            }
        }

        private void SetBorder()
        {
            if (UtilityOpts.BorderOpts != null)
            {
                var borderOpts = UtilityOpts.BorderOpts;
                if (borderOpts.Border.HasValue)
                    AddCss(borderOpts.Border.GetCssDescription());
                if (borderOpts.BorderColor.HasValue)
                    AddCss(borderOpts.BorderColor.GetCssDescription());
                if (borderOpts.BorderRadius.HasValue)
                    AddCss(borderOpts.BorderRadius.GetCssDescription());
                if (borderOpts.Opacity.HasValue)
                    AddCss($"border-opacity-{borderOpts.Opacity}");
            }
        }

        private void SetBackground()
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
        }
        #endregion
    }
}
