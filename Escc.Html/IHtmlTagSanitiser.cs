namespace Escc.Html
{
    /// <summary>
    /// Remove or escape HTML tags in a string
    /// </summary>
    public interface IHtmlTagSanitiser
    {
        /// <summary>
        /// Removes XML/HTML tags from a string, leaving only the text content
        /// </summary>
        /// <param name="text">Text with tags</param>
        /// <returns>Text without tags</returns>
        string StripTags(string text);

        /// <summary>
        /// Removes XML/HTML tags from a string, leaving only the text content
        /// </summary>
        /// <param name="text">Text with tags</param>
        /// <param name="allowTagNames">The tag names which are allowed</param>
        /// <returns>Text without tags</returns>
        string StripTags(string text, string[] allowTagNames);

        /// <summary>
        /// Escapes XML/HTML tags in a string so that they appear as literal text within HTML or XML.
        /// </summary>
        /// <param name="text">The text containing tags to escape.</param>
        /// <returns>Escaped string</returns>
        string EscapeTags(string text);

        /// <summary>
        /// Escapes XML/HTML tags in a string so that they appear as literal text within HTML or XML.
        /// </summary>
        /// <param name="text">The text containing tags to escape.</param>
        /// <param name="allowTagNames">The names of tags which should be allowed to remain.</param>
        /// <returns>Escaped string</returns>
        string EscapeTags(string text, string[] allowTagNames);
    }
}