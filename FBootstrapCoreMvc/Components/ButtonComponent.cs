using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public abstract class ButtonComponent : BootstrapComponent,
        ICanHaveName,
        IButton,
        ICanBeActive
    {
        public ButtonState ButtonState { get; set; }
        public ButtonType ButtonType { get; set; }
        public ButtonOutlineState? OutlineState { get; set; }
        public IconType? IconType { get; set; }
        public Badge? Badge { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }

        protected ButtonComponent(string tagName)
            : base(tagName, Css.Btn)
        {
            ButtonState = ButtonState.Primary;
        }

        protected override void PreBuild()//TODO: ButtonType at base?
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

            if (Active)
            {
                AddCss(Css.Active);
                MergeAttribute("aria-pressed", true);
            }
            base.PreBuild();
        }
    }
}
