namespace FluentBootstrapCore.Dropdowns
{
    public class DropdownDivider : Tag
    {
        internal DropdownDivider(BootstrapHelper hepler)
            : base(hepler, "li"/*, Css.Divider*/)
        {
            MergeAttribute("role", "separator");
        }
    }
}
