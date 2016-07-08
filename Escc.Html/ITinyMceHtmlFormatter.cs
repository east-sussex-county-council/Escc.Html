namespace Escc.Html
{
    /// <summary>
    /// Methods for working with the HTML output by TinyMCE
    /// </summary>
    public interface ITinyMceHtmlFormatter
    {
        /// <summary>
        /// Fixes the HTML output from an instance of the Tiny MCE editor
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Mce")]
        string FixTinyMceOutput(string text);
    }
}