using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;
using FluentBootstrapCore.Options;

namespace FluentBootstrapCore.Components
{
    public class Button : ButtonComponent,
        ICanHaveValue,
        ICanHaveName
    {
        public object? Value { get; set; }

        public Button()
            : base("button")
        {
        }

        protected override void PreBuild()
        {
            MergeAttribute("type", ButtonType.GetCssDescription());

            if (Value != null)
                MergeAttribute("value", Value);

            if (Badge != null)
            {
                if (!Badge.UtilityOptions.Contains<BackgroundOptions>())
                    Badge.UtilityOptions.Add(new BackgroundOptions() { BgColor = BgColor.Secondary });

                var posOptions = Badge.UtilityOptions.Get<PositionOptions>();
                if (Badge.UtilityOptions.Contains<PositionOptions>() && posOptions?.Absolute.HasValue == true)
                {
                    UtilityOptions.Add(new PositionOptions
                    {
                        Position = Position.Relative,
                    });
                }

                AddChild(Badge);
            }

            base.PreBuild();
        }
    }
}