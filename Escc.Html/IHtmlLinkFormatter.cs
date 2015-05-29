namespace Escc.Html
{
    public interface IHtmlLinkFormatter
    {
        /// <summary>
        /// Get the text content of an HTML string, but without text used for links
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        string TextOutsideLinks(string text);
    }
}