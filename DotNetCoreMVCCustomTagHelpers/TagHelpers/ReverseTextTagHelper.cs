using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DotNetCoreMVCCustomTagHelpers.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("reverse")]
    public class ReverseTextTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-word")]
        public string Keyword { get; set; }

        [HtmlAttributeName("asp-cap")]
        public bool Caps { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string result = string.Join("", Keyword.Reverse());
            if (Caps)
            {
                result = result.ToUpper();
            }

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "text-danger");
            output.Content.SetContent(result);

        }
    }
}
