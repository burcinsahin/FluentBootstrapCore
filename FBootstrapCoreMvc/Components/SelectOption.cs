using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class SelectOption : HtmlComponent,
        ICanHaveValue, ICanBeDisabled, ICanBeSelected
    {
        public SelectOption()
            : base("option")
        {
        }

        public SelectOption SetSelected(bool selected = false)
        {
            if (!selected) return this;
            MergeAttribute("selected");
            return this;
        }
    }
}