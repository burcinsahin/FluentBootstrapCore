using FluentBootstrapCore.Enums;
using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public class FlexOptions : UtilityOptions
    {
        public EnumList<FlexDirection> Direction { get; set; }
        public EnumList<JustifyContent> JustifyContent { get; set; }
        public EnumList<AlignItems> AlignItems { get; set; }
        public EnumList<AlignSelf> AlignSelf { get; set; }
        public EnumList<AlignContent> AlignContent { get; set; }
        public EnumList<FlexAbility> FlexFill { get; set; }

        public FlexOptions()
        {
            Direction = [];
            JustifyContent = [];
            AlignItems = [];
            AlignSelf = [];
            FlexFill = [];
            AlignContent = [];
        }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            cssList.AddRange(Direction.GetCssDescriptions());
            cssList.AddRange(JustifyContent.GetCssDescriptions());
            cssList.AddRange(AlignItems.GetCssDescriptions());
            cssList.AddRange(AlignSelf.GetCssDescriptions());
            cssList.AddRange(FlexFill.GetCssDescriptions());
            cssList.AddRange(AlignContent.GetCssDescriptions());
            return cssList;
        }
    }
}