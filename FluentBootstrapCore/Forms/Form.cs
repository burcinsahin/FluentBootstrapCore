namespace FluentBootstrapCore.Forms
{
    public class Form : Tag,
        ICanCreate<FormGroup>,
        ICanCreate<ControlLabel>,
        ICanCreate<FormControl>,
        ICanCreate<HelpBlock>,
        ICanCreate<FieldSet>,
        ICanCreate<InputGroup>,
        ICanCreate<Hidden>
    {
        internal Form(BootstrapHelper helper, params string[] cssClasses)
            : base(helper, "form", cssClasses)
        {
            DefaultLabelWidth = helper.GetConfig().DefaultFormLabelWidth;
            MergeAttribute("role", "form");
        }

        public int DefaultLabelWidth { get; set; }    // This is only used for horizontal forms

        public bool Horizontal
        {
            get { return false/*CssClasses.Contains(Css.FormHorizontal)*/; }
        }
    }
}
