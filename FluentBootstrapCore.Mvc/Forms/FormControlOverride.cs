using FluentBootstrapCore.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;

namespace FluentBootstrapCore.Mvc.Forms
{
    internal class FormControlOverride<TModel> : ComponentOverride<FormControl>
    {
        protected override void OnStart(TextWriter writer)
        {
            var name = Component.GetAttribute("name");
            if (!string.IsNullOrWhiteSpace(name))
            {
                // Use a TagBuilder to generate the Id
                var tagBuilder = new TagBuilder("form");
                var id = Component.GetAttribute("id");
                if (!string.IsNullOrWhiteSpace(id))
                {
                    tagBuilder.MergeAttribute("id", id);
                }
                tagBuilder.GenerateId(name, "");
                Component.MergeAttribute("id", tagBuilder.Attributes["id"]);
            }

            Component.Prepare(writer);

            // Add the validation data
            if (!string.IsNullOrWhiteSpace(name))
            {
                // Set the validation class
                var config = (MvcBootstrapConfig<TModel>)Config;
                if (config.HtmlHelper.ViewData.ModelState.TryGetValue(name, out var modelState) && modelState.Errors.Count > 0)
                {
                    Component.CssClasses.Add(HtmlHelper.ValidationInputCssClassName);
                }

                // Add other validation attributes
                //TODO:???Component.MergeAttributes<string, object>(config.HtmlHelper.GetUnobtrusiveValidationAttributes(name, null));
            }

            base.OnStart(writer);
        }
    }
}
