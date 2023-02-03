using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public abstract class FormControl<TComponent> : SingleComponent,
        ICanBeReadonly,
        ICanHaveLabel,
        ICanHaveName,
        ICanHaveValue,
        ICanBeRequired
        where TComponent : SingleComponent, IInput
    {
        public bool Readonly { get; set; }
        public string? Label { get; set; }
        public string? Name { get; set; }
        public object? Value { get; set; }
        public bool Required { get; set; }
        protected bool _labelFirst;
        protected abstract TComponent Input { get; }
        protected readonly Label _label;

        public FormControl() : base("div")
        {
            _label = new Label();
        }

        protected override void PreBuild()
        {
            if (Input != null)
            {
                Input.Value = Value;
                Input.Disabled = Readonly;
                Input.Name = Name;
                Input.Required = Required;
                Input.SetId();

                if (Label != null)
                {
                    _label.Content = Label;
                    _label.For = Input.Id;
                    if (_labelFirst)
                        AddChild(_label);
                }

                AddChild(Input);

                if (Label != null && !_labelFirst)
                    AddChild(_label);
            }

            base.PreBuild();
        }
    }
}