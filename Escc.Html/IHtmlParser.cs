using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Escc.Html
{
    /// <summary>
    /// Utility methods to parse and work with fragments of HTML
    /// </summary>
    public interface IHtmlParser
    {
        /// <summary>
        /// Gets a collection of XHTML attributes which can contain multiple values.
        /// </summary>
        /// <value>The XHTML multi-valued attributes.</value>
        Collection<string> HtmlMultiValuedAttributes { get; }
            
        /// <summary>
        /// Parses the attributes string from inside an HTML opening tag, even if they are not correctly quoted.
        /// </summary>
        /// <param name="attributes">The attributes from the tag as a single string.</param>
        /// <param name="attributeValues">Dictionary to store attributes.</param>
        void ParseAttributes(string attributes, Dictionary<string, string> attributeValues);

        /// <summary>
        /// Parses the attributes string from inside an HTML opening tag, even if they are not correctly quoted.
        /// </summary>
        /// <param name="attributes">The attributes from the tag as a single string.</param>
        /// <param name="singleValueAttributes">Dictionary to store attributes which only have a single value.</param>
        /// <param name="multiValueAttributes">Dictionary to store attributes which can have multiple values.</param>
        /// <param name="splitValuesFor">Names of the attributes which can have multiple values.</param>
        /// <param name="splitValuesBy">Separators to split multiple values by.</param>
        /// <param name="unwantedAttributes">The names of any unwanted attributes, which will be discarded.</param>
        /// <remarks><see cref="List&lt;T&gt;"/> used for multi-valued attributes rather than <see cref="Collection&lt;T&gt;"/> because <see cref="Collection&lt;T&gt;"/> 
        /// was being treated as read-only. <see cref="List&lt;T&gt;"/> works, so it is used despite a recommendation from FxCop not to expose it.</remarks>
        void ParseAttributes(string attributes, Dictionary<string, string> singleValueAttributes, Dictionary<string, List<string>> multiValueAttributes, Collection<string> splitValuesFor, string[] splitValuesBy, Collection<string> unwantedAttributes);

        /// <summary>
        /// Rebuilds an HTML opening tag which was parsed by <see cref="HtmlParser.ParseAttributes(string,System.Collections.Generic.Dictionary{string,string},System.Collections.Generic.Dictionary{string,System.Collections.Generic.List{string}},System.Collections.ObjectModel.Collection{string},string[],System.Collections.ObjectModel.Collection{string})"/>
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="singleValueAttributes">The single value attributes.</param>
        /// <param name="multiValueAttributes">The multi value attributes.</param>
        /// <returns>HTML opening tag</returns>
        /// <remarks><see cref="List&lt;T&gt;"/> used for multi-valued attributes rather than <see cref="Collection&lt;T&gt;"/> because <see cref="Collection&lt;T&gt;"/> 
        /// was being treated as read-only. <see cref="List&lt;T&gt;"/> works, so it is used despite a recommendation from FxCop not to expose it.</remarks>
        string RebuildTag(string tagName, Dictionary<string, string> singleValueAttributes, Dictionary<string, List<string>> multiValueAttributes);

        /// <summary>
        /// Rebuilds an HTML opening tag which was parsed by <see cref="HtmlParser.ParseAttributes(string,System.Collections.Generic.Dictionary{string,string},System.Collections.Generic.Dictionary{string,System.Collections.Generic.List{string}},System.Collections.ObjectModel.Collection{string},string[],System.Collections.ObjectModel.Collection{string})"/>
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="singleValueAttributes">The single value attributes.</param>
        /// <param name="multiValueAttributes">The multi value attributes.</param>
        /// <param name="restrictToAttributes">The only attributes to use when reassembling tag.</param>
        /// <param name="isEmptyElement">if set to <c>true</c> [is empty element].</param>
        /// <returns>HTML opening tag</returns>
        /// <remarks><see cref="List&lt;T&gt;"/> used for multi-valued attributes rather than <see cref="Collection&lt;T&gt;"/> because <see cref="Collection&lt;T&gt;"/>
        /// was being treated as read-only. <see cref="List&lt;T&gt;"/> works, so it is used despite a recommendation from FxCop not to expose it.</remarks>
        string RebuildTag(string tagName, Dictionary<string, string> singleValueAttributes, Dictionary<string, List<string>> multiValueAttributes, Collection<string> restrictToAttributes, bool isEmptyElement);

        /// <summary>
        /// Rebuilds an HTML element which was parsed by <see cref="HtmlParser.ParseAttributes(string,System.Collections.Generic.Dictionary{string,string},System.Collections.Generic.Dictionary{string,System.Collections.Generic.List{string}},System.Collections.ObjectModel.Collection{string},string[],System.Collections.ObjectModel.Collection{string})"/>
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="singleValueAttributes">The single value attributes.</param>
        /// <param name="multiValueAttributes">The multi value attributes.</param>
        /// <param name="innerHtml">The inner HTML.</param>
        /// <returns>HTML tag</returns>
        /// <remarks><see cref="List&lt;T&gt;"/> used for multi-valued attributes rather than <see cref="Collection&lt;T&gt;"/> because <see cref="Collection&lt;T&gt;"/> 
        /// was being treated as read-only. <see cref="List&lt;T&gt;"/> works, so it is used despite a recommendation from FxCop not to expose it.</remarks>
        string RebuildElement(string tagName, Dictionary<string, string> singleValueAttributes, Dictionary<string, List<string>> multiValueAttributes, string innerHtml);
    }
}