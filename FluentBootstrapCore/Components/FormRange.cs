﻿using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class FormRange : FormControl<Range>, IRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public double Step { get; set; }

        internal override Range Input => _range;

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