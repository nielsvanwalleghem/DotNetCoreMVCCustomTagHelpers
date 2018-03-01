using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DotNetCoreMVCCustomTagHelpers.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("textarea")]
    public class MyCustomTextArea : TextAreaTagHelper
    {
        [HtmlAttributeName("asp-is-disabled")]
        public bool IsDisabled { set; get; } = true;

        [HtmlAttributeName("asp-size-width")]
        public int Cols { get; set; }

        [HtmlAttributeName("asp-size-height")]
        public int Rows { get; set; }

        [HtmlAttributeName("asp-text")]
        public string Text { get; set; }

        public MyCustomTextArea(IHtmlGenerator generator) : base(generator)
        {

        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("cols", Cols);
            output.Attributes.SetAttribute("rows", Rows);
            output.Content.SetContent(Text);

            if (IsDisabled)
            {
                output.Attributes.Add(new TagHelperAttribute("disabled", "disabled"));
            }
        }
    }
}
