using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class FormRange : FormControl<Range>, IRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public double Step { get; set; }

        protected override Range Input => _range;

        private readonly Range _range;

        public FormRange()
            : base()
        {
            _range = new Range();
            _labelFirst = true;
        }

        protected override void PreBuild()
        {
            _range.Min = Min;
            _range.Max = Max;
            _range.Step = Step;

            base.PreBuild();
        }
    }
}