using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace Escc.Html
{
    /// <summary>
    /// Remove or escape HTML tags in a string
    /// </summary>
    public class HtmlTagSantiser : IHtmlTagSanitiser
    {
        /// <summary>
        /// Removes XML/HTML tags from a string, leaving only the text content
        /// </summary>
        /// <param name="text">Text with tags</param>
        /// <returns>Text without tags</returns>
        public string StripTags(string text)
        {
            return StripTags(text, null);
        }

        /// <summary>
        /// Removes XML/HTML tags from a string, leaving only the text content
        /// </summary>
        /// <param name="text">Text with tags</param>
        /// <param name="allowTagNames">The tag names which are allowed</param>
        /// <returns>Text without tags</returns>
        public string StripTags(string text, string[] allowTagNames)
        {
            if (allowTagNames != null)
            {
                foreach (string tagName in allowTagNames)
                {
                    text = Regex.Replace(text, "<(/?" + tagName + "[^>]*)>", "{{{$1}}}");
                }
            }

            text = text.Replace("<br />", Environment.NewLine);
            text = text.Replace("</p>", Environment.NewLine + Environment.NewLine);
            text = Regex.Replace(text, "<[^>]*>", "", RegexOptions.IgnoreCase).Trim();

            if (allowTagNames != null)
            {
                foreach (string tagName in allowTagNames)
                {
                    text = Regex.Replace(text, "{{{(/?" + tagName + "[^}]*)}}}", "<$1>");
                }
            }

            return text;
        }

        /// <summary>
        /// Escapes XML/HTML tags in a string so that they appear as literal text within HTML or XML.
        /// </summary>
        /// <param name="text">The text containing tags to escape.</param>
        /// <returns>Escaped string</returns>
        public string EscapeTags(string text)
        {
            return EscapeTags(text, null);
        }

        /// <summary>
        /// Escapes XML/HTML tags in a string so that they appear as literal text within HTML or XML.
        /// </summary>
        /// <param name="text">The text containing tags to escape.</param>
        /// <param name="allowTagNames">The names of tags which should be allowed to remain.</param>
        /// <returns>Escaped string</returns>
        public string EscapeTags(string text, string[] allowTagNames)
        {
            // Work on any individual tag in a structured way
            // Anonymous function allows a match evaluator delegate containing the passed-in variable, where normally the delegate could not receive any custom parameters
            text = Regex.Replace(text, @"(?<OpenTag></?)(?<TagName>[a-z]+)(?<CloseTag> [^>]*>|>)", delegate(Match match) { return EscapeTag_MatchEvaluator(match, allowTagNames); }, RegexOptions.Singleline & RegexOptions.IgnoreCase);

            return text;
        }

        /// <summary>
        /// Parses an opening tag with attributes within the HTML and tidies it up
        /// </summary>
        /// <param name="match">A single matched tag</param>
        /// <param name="allowTagNames">The names of tags which should be allowed to remain.</param>
        /// <returns></returns>
        private static string EscapeTag_MatchEvaluator(Match match, string[] allowTagNames)
        {
            string tag = match.Groups["OpenTag"].Value + match.Groups["TagName"].Value + match.Groups["CloseTag"].Value;
            if (allowTagNames != null && new List<string>(allowTagNames).Contains(match.Groups["TagName"].Value))
            {
                return tag;
            }
            else return HttpUtility.HtmlEncode(tag);
        }
    }
}
