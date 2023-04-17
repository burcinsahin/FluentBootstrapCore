using System.Collections.Generic;
using System.Linq;

namespace FBootstrapCoreMvc.Options
{
    public class OptionList : HashSet<IUtilityOptions>
    {
        public OptionList()
            : base(new TypeEqualityComparer<IUtilityOptions>())
        {
        }

        public T Get<T>() 
            where T : IUtilityOptions
        {
            return (T)this.FirstOrDefault(o => o.GetType().Equals(typeof(T)));
        }

        public bool Contains<T>() 
            where T : IUtilityOptions
        {
            return this.Any(o => o.GetType().Equals(typeof(T)));
        }


        public void AddOrUpdate<T>(T options) 
            where T : IUtilityOptions
        {
            if (Contains<T>())
            {
                var opts = Get<T>();
                Remove(opts);
            }
            Add(options);
        }

        private class TypeEqualityComparer<T> : EqualityComparer<T>
            where T : class
        {
            public override bool Equals(T x, T y)
            {
                return x.GetType().Equals(y.GetType());
            }

            public override int GetHashCode(T obj)
            {
                return typeof(T).GetHashCode();
            }
        }
    }
}
