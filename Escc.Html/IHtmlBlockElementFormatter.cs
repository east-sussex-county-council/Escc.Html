namespace Escc.Html
{
    public interface IHtmlBlockElementFormatter
    {
        /// <summary>
        /// Formats a text string, which may already contain some HTML tags, as HTML paragraphs.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        string FormatAsHtmlParagraphs(string text);
    }
}