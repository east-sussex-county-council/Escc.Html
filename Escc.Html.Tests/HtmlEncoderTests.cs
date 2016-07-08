using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Escc.Html.Tests
{
    [TestFixture]
    class HtmlEncoderTests
    {
        [Test]
        public void EncodesAllTypicalCharactersInUrl()
        {
            var charactersToEncode = "http://user:password@abcdefgh.ijk/lmnop?qrs=tuvwxyz#0123456789";

            var encoder = new HtmlEncoder();
            var result = encoder.HtmlEncodeEveryCharacter(charactersToEncode);

            Assert.AreEqual("&#104;&#116;&#116;&#112;&#58;&#47;&#47;&#117;&#115;&#101;&#114;&#58;&#112;&#97;&#115;&#115;&#119;&#111;&#114;&#100;&#64;&#97;&#98;&#99;&#100;&#101;&#102;&#103;&#104;&#46;&#105;&#106;&#107;&#47;&#108;&#109;&#110;&#111;&#112;&#63;&#113;&#114;&#115;&#61;&#116;&#117;&#118;&#119;&#120;&#121;&#122;&#35;&#48;&#49;&#50;&#51;&#52;&#53;&#54;&#55;&#56;&#57;", result);
        }
    }
}
