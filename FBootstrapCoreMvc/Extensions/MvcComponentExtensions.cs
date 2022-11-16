namespace FBootstrapCoreMvc.Extensions
{
    public static class MvcComponentExtensions
    {
        public static TComponent DoSth<TComponent, TModel>(this TComponent component)
            where TComponent : MvcComponent<TComponent, TModel>

        {
            return component;
        }
    }
}
