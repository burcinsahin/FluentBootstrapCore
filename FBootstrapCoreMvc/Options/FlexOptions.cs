using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Options
{
    public class FlexOptions : UtilityOptions
    {
        public EnumList<FlexDirection> Direction { get; set; }
        public EnumList<JustifyContent> JustifyContent { get; set; }

        public FlexOptions()
        {
            Direction = new EnumList<FlexDirection>();
            JustifyContent = new EnumList<JustifyContent>();
        }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            cssList.AddRange(Direction.GetCssDescriptions());
            cssList.AddRange(JustifyContent.GetCssDescriptions());

            //foreach (var item in Direction)
            //{
            //    cssList.Add(string.Format(item.Value.GetCssDescription(), item.Key.GetHyphenatedDescription()));
            //}
            //foreach (var item in JustifyContent)
            //{
            //    cssList.Add(string.Format(item.Value.GetCssDescription(), item.Key.GetHyphenatedDescription()));
            //}
            return cssList;
        }
    }
}