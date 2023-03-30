using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public abstract class ButtonComponent : BootstrapComponent, ICanHaveName, IButton
    {
        public ButtonState ButtonState { get; set; }
        public ButtonType ButtonType { get; set; }
        public ButtonOutlineState? OutlineState { get; set; }
        public IconType? IconType { get; set; }
        public string? Badge { get; set; }
        public bool PositionBadge { get; set; }
        public string? Name { get; set; }

        protected ButtonComponent(string tagName)
            : base(tagName, Css.Btn)
        {
            ButtonState = ButtonState.Primary;
        }

        protected override void PreBuild()
        {
            AddCss(ButtonState.GetCssDescription());
            if (Name != null)
                MergeAttribute("name", Name);
            if (OutlineState.HasValue)
                AddCss(OutlineState.GetCssDescription());

            if (IconType.HasValue)
            {
                var icon = new Icon(IconType.Value);
                AddChild(icon, ChildLocation.Header);
            }
            base.PreBuild();
        }
    }
}
