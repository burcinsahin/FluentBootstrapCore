using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class SelectOption : HtmlComponent,
        ICanHaveValue, 
        ICanBeDisabled, 
        ICanBeSelected
    {
        public SelectOption()
            : base("option")
        {
        }

        public bool Disabled { get; set ; }

        protected internal SelectOption SetSelected(bool selected = true)
        {
            if (!selected) return this;
            MergeAttribute("selected");
            return this;
        }

        protected internal SelectOption SetValue(string value)
        {
            MergeAttribute("value", value);
            return this;
        }
    }
}