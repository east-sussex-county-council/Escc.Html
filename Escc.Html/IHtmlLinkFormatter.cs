using System;

namespace Escc.Html
{
    /// <summary>
    /// Work with the HTML for links
    /// </summary>
    public interface IHtmlLinkFormatter
    {
        /// <summary>
        /// Get the text content of an HTML string, but without text used for links
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="tagSanitiser">The tag sanitiser.</param>
        /// <returns></returns>
        string TextOutsideLinks(string text, IHtmlTagSanitiser tagSanitiser);

        /// <summary>
        /// Gets an abridged version of an absolute URL with a maximum of 60 characters, which may not work as a link
        /// </summary>
        /// <param name="urlToAbbreviate">The URL to abbreviate.</param>
        /// <returns></returns>
        string AbbreviateUrl(Uri urlToAbbreviate);

        /// <summary>
        /// Gets an abridged version of a URL with a maximum of 60 characters, which may not work as a link
        /// </summary>
        /// <param name="urlToAbbreviate">The URL to abbreviate.</param>
        /// <param name="baseUrl">The base URL, typically the URL of the current page.</param>
        /// <returns></returns>
        string AbbreviateUrl(Uri urlToAbbreviate, Uri baseUrl);

        /// <summary>
        /// Gets an abridged version of a URL, which may not work as a link
        /// </summary>
        /// <param name="urlToAbbreviate">The URL.</param>
        /// <param name="baseUrl">The base URL, typically the URL of the current page.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <returns></returns>
        string AbbreviateUrl(Uri urlToAbbreviate, Uri baseUrl, int maximumLength);
    }
}