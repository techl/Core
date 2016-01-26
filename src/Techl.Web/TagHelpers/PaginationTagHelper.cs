using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;
using System.Text;
using Microsoft.AspNet.Mvc.Rendering;
using System.IO;
using Microsoft.Extensions.WebEncoders;

namespace Techl.Web.TagHelpers
{
    public class PaginationTagHelper : TagHelper
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; } = 10;

        public bool SearchMode { get; set; }
        public string SearchField { get; set; }
        public string SearchQuery { get; set; }

        public string Url { get; set; }

        private int recordCount;
        public int RecordCount
        {
            get { return recordCount; }
            set
            {
                recordCount = value;
                TotalPages = ((recordCount - 1) / PageSize) + 1;
            }
        }



        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.Attributes["class"] = "pagination pagination-sm";

            if (CurrentPage == 0)
                CurrentPage = 1;

            var writer = new StringWriter();
            var encoder = new HtmlEncoder();

            var li = new TagBuilder("li");
            var a = new TagBuilder("a");
            if (CurrentPage > 10)
            {
                a.MergeAttribute("href", $"{Url}?Page={((CurrentPage - 1) / 10) * 10}{(SearchMode ? $"&SearchField={SearchField}&SearchQuery={SearchQuery}" : "")}");
                a.InnerHtml.AppendHtml("◄");
            }
            else
            {
                a.MergeAttribute("class", "disabled");
                a.InnerHtml.AppendHtml("◁");
            }

            li.InnerHtml.Append(a);
            li.WriteTo(writer, encoder);

            int firstPage = (CurrentPage - 1) / 10 * 10 + 1;
            int i;
            for (i = firstPage; i < firstPage + 10; i++)
            {
                if (i > TotalPages)
                    break;

                li = new TagBuilder("li");
                a = new TagBuilder("a");

                if (i == CurrentPage)
                {
                    li.MergeAttribute("class", "active");
                    a.MergeAttribute("href", "#");
                }
                else
                {
                    a.MergeAttribute("href", $"{Url}?Page={i}{(SearchMode ? $"&SearchField={SearchField}&SearchQuery={SearchQuery}" : "")}");
                }

                a.InnerHtml.AppendHtml(i.ToString());
                li.InnerHtml.Append(a);

                li.WriteTo(writer, encoder);
            }

            li = new TagBuilder("li");
            a = new TagBuilder("a");

            if (i < TotalPages)
            {
                a.MergeAttribute("href", $"{Url}?Page={i}{(SearchMode ? $"&SearchField={SearchField}&SearchQuery={SearchQuery}" : "")}");
                a.InnerHtml.AppendHtml("►");
            }
            else
            {
                a.MergeAttribute("class", "disabled");
                a.InnerHtml.AppendHtml("▷");
            }

            li.InnerHtml.Append(a);
            li.WriteTo(writer, encoder);

            output.Content.AppendHtml(writer.ToString());
        }
    }
}
