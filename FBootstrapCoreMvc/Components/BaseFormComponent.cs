namespace FBootstrapCoreMvc.Components
{
    public abstract class BaseFormComponent : HtmlComponent
    {
        protected BaseFormComponent(params string[] cssClasses)
            : base("div", cssClasses)
        {
        }
    }
}