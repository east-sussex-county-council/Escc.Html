using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Escc.Html
{
    /// <summary>
    /// Work with the HTML for links
    /// </summary>
    public class HtmlLinkFormatter : IHtmlLinkFormatter
    {
        /// <summary>
        /// Get the text content of an HTML string, but without text used for links
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public string TextOutsideLinks(string text)
        {
            if (String.IsNullOrEmpty(text)) return text;

            // Remove any links including the link text
            const string anythingExceptEndAnchor = "((?!</a>).)*";
            text = Regex.Replace(text, "<a [^>]*>" + anythingExceptEndAnchor + "</a>", String.Empty);

            // Remove any other HTML, and what's left is text outside links
            text = HttpUtility.HtmlDecode(new HtmlTagSantiser().StripTags(text));

            // Any remaining text is invalid
            return text.Trim();
        }
    }
}
