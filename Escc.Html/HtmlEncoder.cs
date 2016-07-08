using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Escc.Html
{
    /// <summary>
    /// Utility methods to work with HTML encoding of text
    /// </summary>
    public class HtmlEncoder : IHtmlEncoder
    {
        /// <summary>
        /// HTML encode all characters, including the lower ASCII characters which do not normally need to be encoded
        /// </summary>
        /// <param name="text">The text to encode.</param>
        /// <returns>HTML encoded text</returns>
        /// <remarks>Code from http://www.codeproject.com/Articles/20255/Full-HTML-Character-Encoding-in-C</remarks>
        public string HtmlEncodeEveryCharacter(string text)
        {
            char[] chars = HttpUtility.HtmlEncode(text).ToCharArray();
            StringBuilder result = new StringBuilder(text.Length + (int)(text.Length * 0.1));

            foreach (char c in chars)
            {
                int value = Convert.ToInt32(c);
                result.AppendFormat("&#{0};", value);
            }

            return result.ToString();
        }
    }
}
