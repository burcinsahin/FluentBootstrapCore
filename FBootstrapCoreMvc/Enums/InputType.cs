using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum FormInputType
    {
        [Description("text")]
        Text,
        [Description("password")]
        Password,
        [Description("datetime")]
        DateTime,
        [Description("datetime-local")]
        DateTimeLocal,
        [Description("date")]
        Date,
        [Description("month")]
        Month,
        [Description("time")]
        Time,
        [Description("week")]
        Week,
        [Description("number")]
        Number,
        [Description("email")]
        Email,
        [Description("url")]
        Url,
        [Description("search")]
        Search,
        [Description("tel")]
        Tel,
        [Description("color")]
        Color,
        [Description("hidden")]
        Hidden,
        [Description("checkbox")]
        Checkbox,
        [Description("radio")]
        Radio,
        [Description("range")]
        Range,
        [Description("file")]
        File,
        [Description("button")]
        Button
    }
}
