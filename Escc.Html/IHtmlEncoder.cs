namespace Escc.Html
{
    /// <summary>
    /// Utility methods to work with HTML encoding of text
    /// </summary>
    public interface IHtmlEncoder
    {
        /// <summary>
        /// HTML encode all characters, including the lower ASCII characters which do not normally need to be encoded
        /// </summary>
        /// <param name="text">The text to encode.</param>
        /// <returns>HTML encoded text</returns>
        /// <remarks>Code from http://www.codeproject.com/Articles/20255/Full-HTML-Character-Encoding-in-C</remarks>
        string HtmlEncodeEveryCharacter(string text);
    }
}