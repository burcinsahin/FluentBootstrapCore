using FluentBootstrapCore.Enums;
using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public class TextOptions : UtilityOptions
    {
        public EnumList<TextAlign> TextAlign { get; set; }
        public TextWrap? TextWrap { get; set; }
        public TextTransform? TextTransform { get; set; }
        public FontSize? FontSize { get; set; }
        public FontWeight? FontWeight { get; set; }
        public FontStyle? FontStyle { get; set; }
        public LineHeight? LineHeight { get; set; }
        public bool WordBreak { get; internal set; }
        public bool FontMonospace { get; set; }
        public bool TextReset { get; set; }
        public TextDecoration? TextDecoration { get; internal set; }

        public TextOptions()
        {
            TextAlign = new EnumList<TextAlign>();
        }
        public override IEnumerable<string> GetCssList()
        {
            AddCssFor(TextAlign);
            AddCssFor(TextWrap);
            AddCssFor(TextTransform);
            AddCssFor(FontSize);
            AddCssFor(FontWeight);
            AddCssFor(FontStyle);
            AddCssFor(LineHeight);
            AddCssFor(TextDecoration);
            if (WordBreak)
                _cssList.Add(Css.TextBreak);
            if (FontMonospace)
                _cssList.Add(Css.FontMonospace);
            if (TextReset)
                _cssList.Add(Css.TextReset);
            return base.GetCssList();
        }
    }
}
