using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Escc.Html
{
    /// <summary>
    /// Format and fix HTML block elements such as paragraphs and headings
    /// </summary>
    public class HtmlBlockElementFormatter : IHtmlBlockElementFormatter
    {
        /// <summary>
        /// Formats a text string, which may already contain some HTML tags, as HTML paragraphs.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public string FormatAsHtmlParagraphs(string text)
        {
            if (text == null) return text;

            // establish some strings which will be reused
            string[] blockElements = { "address", "blockquote", "dl", "p", "h1", "h2", "h3", "h4", "h5", "h6", "ol", "table", "ul", "dd", "dt", "li", "tbody", "td", "tfoot", "th", "thead", "tr" };
            string twoNewLines = Environment.NewLine + Environment.NewLine;
            string threeNewLines = Environment.NewLine + Environment.NewLine + Environment.NewLine;
            string lineBreak = "<br />";

            // First, ensure each block element is preceded by at least two newlines, because that helps split them from paragraphs.
            // None of these block elements should end up inside a paragraph.
            text = Regex.Replace(text, "<(" + String.Join("|", blockElements) + ")([^>]*)>", twoNewLines + "<$1$2>");

            // We're going to assume that one newline is a line break and two newlines is a paragraph break, 
            // so ensure there are never more that two consecutive newlines
            int lenBefore = 0;
            int lenAfter = -1;
            while (lenBefore > lenAfter)
            {
                lenBefore = text.Length;
                text = text.Replace(threeNewLines, twoNewLines);
                lenAfter = text.Length;
            }

            // Split the text into chunks based on the separator (two newlines) which should now appear between all block elements
            string[] chunks = text.Split(new string[] { twoNewLines }, StringSplitOptions.RemoveEmptyEntries);

            // Surround each chunk with a paragraph element, if it doesn't already start with a block element
            int lenChunks = chunks.Length;
            for (int i = 0; i < lenChunks; i++)
            {
                bool addParagraphElement = true;
                chunks[i] = chunks[i].Trim();
                foreach (string elementName in blockElements)
                {
                    if (chunks[i].StartsWith("<" + elementName, StringComparison.Ordinal)) addParagraphElement = false;
                }
                if (addParagraphElement) chunks[i] = "<p>" + chunks[i] + "</p>";
            }

            // Join the chunks back together
            text = String.Join(String.Empty, chunks);

            // Any remaining newlines should be line breaks
            text = text.Replace(Environment.NewLine, lineBreak);

            // But remove line breaks which appear just before the close of a block element, because that's definitely a misuse of
            // the line break element and more often than not it creates spacing problems
            foreach (string blockElement in blockElements)
            {
                string closingTag = "</" + blockElement + ">";
                text = text.Replace(lineBreak + closingTag, closingTag);

                // Add a newline after each closing block element, purely to make the HTML source easier to read
                text = text.Replace(closingTag, closingTag + Environment.NewLine);
            }
            return text;
        }
    }
}
