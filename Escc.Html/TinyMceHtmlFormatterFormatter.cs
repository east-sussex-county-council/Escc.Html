using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Escc.Html
{
    /// <summary>
    /// Methods for working with the HTML output by TinyMCE
    /// </summary>
    public class TinyMceHtmlFormatterFormatter : ITinyMceHtmlFormatter
    {
        /// <summary>
        /// Fixes the HTML output from an instance of the Tiny MCE editor
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Mce")]
        public string FixTinyMceOutput(string text)
        {
            string[] blockElements = { "address", "blockquote", "dl", "p", "h1", "h2", "h3", "h4", "h5", "h6", "ol", "table", "ul", "dd", "dt", "li", "tbody", "td", "tfoot", "th", "thead", "tr" };

            // Remove any block elements with no content
            foreach (string elementName in blockElements)
            {
                text = Regex.Replace(text, "<" + elementName + @"[^>]*>\s*</" + elementName + ">", String.Empty);
            }

            // Remove dangerous values from tags
            text = Regex.Replace(text, "javascript:", String.Empty, RegexOptions.IgnoreCase);

            return text;
        }
    }
}
