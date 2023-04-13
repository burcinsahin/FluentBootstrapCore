using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FBootstrapCoreMvc.Options
{
    public abstract class UtilityOptions : IUtilityOptions
    {
        protected List<string> _cssList;
        protected Dictionary<string, object> _styles;

        public UtilityOptions()
        {
            _cssList = new List<string>();
            _styles = new Dictionary<string, object>();
        }

        public virtual IEnumerable<string> GetCssList()
        {
            //TODO: Implement reflection to add css for all props
            //foreach (var propertyInfo in GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            //{
            //    if (propertyInfo.PropertyType.IsSubclassOf(typeof(Enum)))
            //    {
            //        var e = (Enum)propertyInfo.GetValue(this);
            //    }
            //}
            return _cssList;
        }

        public virtual Dictionary<string, object>? GetStyles() => _styles;

        protected void AddCssFor<T>(T? @enum) where T : struct, Enum
        {
            if (@enum.HasValue)
                _cssList.Add(@enum.GetCssDescription());
        }

        protected void AddCssFor<T>(EnumList<T> list) where T : struct, Enum
        {
            if (list.Any())
                _cssList.AddRange(list.GetCssDescriptions());
        }
    }
}
