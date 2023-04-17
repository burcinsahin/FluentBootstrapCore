using FBootstrapCoreMvc.Options;
using System;
using System.Collections.Generic;

namespace FBootstrapCoreMvc
{
    /// <summary>
    /// Bootstrap component with bootstrap utilities
    /// </summary>
    public abstract class BootstrapComponent : SingleComponent
    {
        internal OptionList UtilityOptions { get; set; }

        protected BootstrapComponent(string tagName, params string[] cssClasses)
            : base(tagName, cssClasses)
        {
            UtilityOptions = new OptionList();
        }

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

            return UtilityOptions.Get<TOptions>();
        }
    }
}
