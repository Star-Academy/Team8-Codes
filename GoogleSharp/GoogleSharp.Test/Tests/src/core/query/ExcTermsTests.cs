// Standard Library
using System.Collections.Generic;

// Nuget Packages
using Moq;

using Xunit;

// Internal
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Query;
using GoogleSharp.Src.Core.Structures;

namespace Tests.Src.Core.Query
{
    public class ExcTermsTests
    {
        [Fact]
        public void Constructor_OnlyExcs_Success()
        {
            var expected = new List<Token>
            {
                new Token("first"),
                new Token("second2"),
                new Token("3rd")
            };
            var actual = new ExcTerms("-fiRst -seCond2 -3Rd").Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_NoExcs_Success()
        {
            var expected = new List<Token>();
            var actual = new ExcTerms("first secOnd2 +3rd").Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_SomeOrs_Success()
        {
            var expected = new List<Token>
            {
                new Token("first"),
                new Token("4th"),
                new Token("5th"),
            };
            var actual = new ExcTerms("-first second2 +3rd -4th -5th").Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetResults_SingleTokenIndex_Success()
        {
            var mockedInvertedIndex = new Mock<IInvertedIndex>();
            mockedInvertedIndex.Setup(index => index.GetDocumentsOfToken(new Token("first")))
                .Returns(
                    new HashSet<Document>
                    {
                        new Document("doc1.txt", "simple/path"),
                        new Document("doc2.txt", "simple/path"),
                        new Document("doc3.txt", "simple/path"),
                    }
                );

            var expected = new HashSet<Document>
            {
                new Document("doc1.txt", "simple/path"),
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path"),
            };

            var objectUnderTest = new ExcTerms("-first");
            var actual = objectUnderTest.GetResults(mockedInvertedIndex.Object);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetResults_MultiTokenIndex_Success()
        {
            var mockedInvertedIndex = new Mock<IInvertedIndex>();
            mockedInvertedIndex.Setup(index => index.GetDocumentsOfToken(new Token("first")))
                .Returns(
                    new HashSet<Document>
                    {
                        new Document("doc1.txt", "simple/path"),
                    }
                );
            mockedInvertedIndex.Setup(index => index.GetDocumentsOfToken(new Token("second")))
                .Returns(
                    new HashSet<Document>
                    {
                        new Document("doc2.txt", "simple/path"),
                    }
                );
            var expected = new HashSet<Document>
            {
                new Document("doc1.txt", "simple/path"),
                new Document("doc2.txt", "simple/path")
            };

            var objectUnderTest = new ExcTerms("-first -second +third");
            var actual = objectUnderTest.GetResults(mockedInvertedIndex.Object);

            Assert.Equal(expected, actual);
        }
    }
}
