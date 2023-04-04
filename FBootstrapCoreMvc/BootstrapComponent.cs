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
        internal Dictionary<Type, IUtilityOptions> UtilityOptions { get; set; }

        protected BootstrapComponent(string tagName, params string[] cssClasses)
            : base(tagName, cssClasses)
        {
            UtilityOptions = new Dictionary<Type, IUtilityOptions>();
        }

        protected override void PreBuild()
        {
            foreach (var opts in UtilityOptions.Values)
            {
                AddCss(opts.GetCssList());
            }
            base.PreBuild();
        }

        protected internal TOptions GetOptions<TOptions>() 
            where TOptions : IUtilityOptions, new()
        {
            if (!UtilityOptions.ContainsKey(typeof(TOptions)))
                UtilityOptions.Add(typeof(TOptions), new TOptions());

            return (TOptions)UtilityOptions[typeof(TOptions)];
        }
    }
}
