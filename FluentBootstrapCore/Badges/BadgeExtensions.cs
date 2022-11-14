using FluentBootstrapCore.Badges;

namespace FluentBootstrapCore
{
    public static class BadgeExtensions
    {
        public static ComponentBuilder<TConfig, Badge> Badge<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, object text)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Badge>
        {
            return new ComponentBuilder<TConfig, Badge>(helper.Config, new Badge(helper)).AddCss(Css.BgInfo).SetText(text);
        }

        public static ComponentBuilder<TConfig, Badge> SetPill<TConfig>(this ComponentBuilder<TConfig, Badge> builder, TextBgState state)
            where TConfig : BootstrapConfig
        {
            builder.Component.RemoveCss(Css.BgInfo);
            builder.Component.AddCss(Css.RoundedPill, state.GetDescription());
            return builder;
        }
    }
}
