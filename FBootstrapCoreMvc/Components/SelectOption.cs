using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class SelectOption : BootstrapComponent,
        ICanHaveValue,
        ICanBeDisabled,
        ICanBeSelected
    {
        public bool Disabled { get; set; }
        public object? Value { get; set; }
        public bool Selected { get; set; }
        public SelectOption()
            : base("option")
        { }

        protected override void PreBuild()
        {
            if (Value != null)
                MergeAttribute("value", Value);

            if (Selected)
                MergeAttribute("selected");

            base.PreBuild();
        }

        //protected internal SelectOption SetSelected(bool selected = true)
        //{
        //    if (!selected) return this;
        //    MergeAttribute("selected");
        //    return this;
        //}

        //protected internal SelectOption SetValue(string value)
        //{
        //    MergeAttribute("value", value);
        //    return this;
        //}
    }
}