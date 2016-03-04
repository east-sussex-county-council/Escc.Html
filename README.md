# Escc.Html

Generic utility methods for parsing and formatting HTML.

* `HtmlParser` parses badly formed HTML.
* `HtmlTagSanitiser` strips or escapes tags in strings, but allows you to specify tags which aren't affected.
* `TinyMceHtmlFormatter` cleans up the HTML output by TinyMCE.
* `HtmlLinkFormatter` and `HtmlBlockElementFormatter` have methods commonly used for parsing and formatting their respective types of HTML element.
* `HtmlEncoder` can HTML encode all characters, including those in the lower ASCII character set

This project is packaged for our private NuGet feed using [NuBuild](https://github.com/bspell1/NuBuild).