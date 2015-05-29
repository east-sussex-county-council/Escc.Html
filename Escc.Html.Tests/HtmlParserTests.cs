using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Escc.Html.Tests
{
    [TestFixture]
    public class HtmlParserTests
    {
        [Test]
        public void ParseUnquotedAttribute()
        {
            IHtmlParser parser = new HtmlParser();
            var attributes = new Dictionary<string, string>();

            parser.ParseAttributes(" class=test", attributes);

            Assert.AreEqual(1, attributes.Count);
            Assert.AreEqual("class", attributes.Keys.First());
            Assert.AreEqual("test", attributes.Values.First());
        }
    }
}
