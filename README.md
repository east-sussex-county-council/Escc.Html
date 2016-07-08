# Escc.Html

Generic utility methods for parsing and formatting HTML.

* `HtmlParser` parses badly formed HTML.
* `HtmlTagSanitiser` strips or escapes tags in strings, but allows you to specify tags which aren't affected.
* `TinyMceHtmlFormatter` cleans up the HTML output by TinyMCE.
* `HtmlLinkFormatter` [abbreviates URLs into a version more suitable for display](HtmlLinkFormatter.md), and removes links from HTML text.
* `HtmlBlockElementFormatter` parses and formats text as HTML paragraphs.
* `HtmlEncoder` can HTML encode all characters, including those in the lower ASCII character set.

This project is packaged for our private NuGet feed using [NuBuild](https://github.com/bspell1/NuBuild).