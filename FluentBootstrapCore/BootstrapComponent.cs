using FluentBootstrapCore.Options;

namespace FluentBootstrapCore
{
    /// <summary>
    /// Bootstrap component with bootstrap utilities
    /// </summary>
    public abstract class BootstrapComponent(string tagName, params string[] cssClasses) : SingleComponent(tagName, cssClasses)
    {
        public OptionList UtilityOptions { get; set; } = [];

        protected override void PreBuild()
        {
            foreach (var opts in UtilityOptions)
            {
                AddCss(opts.GetCssList());
            }
            base.PreBuild();
        }

        protected internal TOptions GetOptions<TOptions>()
            where TOptions : IUtilityOptions, new()
        {
            if (!UtilityOptions.Contains<TOptions>())
                UtilityOptions.Add(new TOptions());

            return UtilityOptions.Get<TOptions>()!;
        }
    }
}
