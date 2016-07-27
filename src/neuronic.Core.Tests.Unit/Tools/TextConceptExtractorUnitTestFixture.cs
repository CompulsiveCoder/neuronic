using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace neuronic.Core.Tests.Unit
{
    [TestFixture(Category="Unit")]
    public class TextConceptExtractorUnitTestFixture
    {
        [Test]
        public void ExtractConcepts_General()
        {
            var extractor = new TextConceptExtractor ();
            extractor.MaxConceptLength = 3;

            var text = "aaabbb";

            var concepts = extractor.ExtractConcepts (text);

            Assert.IsTrue (concepts.ContainsKey ("a"));
            Assert.AreEqual (3, concepts["a"]);

            Assert.IsTrue (concepts.ContainsKey ("aa"));
            Assert.AreEqual (2, concepts["aa"]);

            Assert.IsTrue (concepts.ContainsKey ("aaa"));
            Assert.AreEqual (1, concepts["aaa"]);

            Assert.IsTrue (concepts.ContainsKey ("aab"));
            Assert.AreEqual (1, concepts["aab"]);

            Assert.IsTrue (concepts.ContainsKey ("abb"));
            Assert.AreEqual (1, concepts["abb"]);

            Assert.IsTrue (concepts.ContainsKey ("bbb"));
            Assert.AreEqual (1, concepts["bbb"]);

            Assert.IsTrue (concepts.ContainsKey ("bb"));
            Assert.AreEqual (2, concepts["bb"]);

            Assert.IsTrue (concepts.ContainsKey ("b"));
            Assert.AreEqual (3, concepts["b"]);
        }

        [Test]
        public void ExtractConcepts_Length1()
        {
            var extractor = new TextConceptExtractor ();

            var text = "aaabbb";

            var concepts = extractor.ExtractConcepts (text, 1);

            Assert.IsTrue (concepts.ContainsKey ("a"));
            Assert.AreEqual (3, concepts["a"]);

            Assert.IsTrue (concepts.ContainsKey ("b"));
            Assert.AreEqual (3, concepts["b"]);
        }

        [Test]
        public void ExtractConcepts_Length2()
        {
            var extractor = new TextConceptExtractor ();

            var text = "aaabbb";

            var concepts = extractor.ExtractConcepts (text, 2);

            Assert.IsTrue (concepts.ContainsKey ("aa"));
            Assert.AreEqual (2, concepts["aa"]);

            Assert.IsTrue (concepts.ContainsKey ("ab"));
            Assert.AreEqual (1, concepts["ab"]);

            Assert.IsTrue (concepts.ContainsKey ("bb"));
            Assert.AreEqual (2, concepts["bb"]);
        }
    }
}

