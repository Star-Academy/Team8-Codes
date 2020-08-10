using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Query;
using GoogleSharp.Src.Core.Structures;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Tests.Src.Core.Query
{
    public class OrTermsTests
    {
        [Fact]
        public void Constructor_OnlyOrs_Success()
        {
            var expected = new List<Token>{
                new Token("first"),
                new Token("second2"),
                new Token("3rd")
            };
            var actual = new OrTerms("+first +second2 +3rd").Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_NoOrs_Success()
        {
            var expected = new List<Token>();
            var actual = new OrTerms("-first second2 -3rd").Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_SomeOrs_Success()
        {
            var expected = new List<Token>{
                new Token("first"),
                new Token("4th"),
                new Token("5th"),
            };
            var actual = new OrTerms("+first second2 -3rd +4th +5th").Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetResults_SingleTokenIndex_Success()
        {
            var mockedInvertedIndex = new Mock<IInvertedIndex>();
            mockedInvertedIndex.Setup(index => index.GetDocumentsOfToken(new Token("first")))
            .Returns(
                new HashSet<Document>{
                    new Document("doc1.txt", "simple/path"),
                    new Document("doc2.txt", "simple/path"),
                    new Document("doc3.txt", "simple/path"),
                }
            );

            var expected = new HashSet<Document>{
                new Document("doc1.txt", "simple/path"),
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path"),
            };

            var objectUnderTest = new OrTerms("+first");
            var actual = objectUnderTest.GetResults(mockedInvertedIndex.Object);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetResults_MultiTokenIndex_Success()
        {
            var mockedInvertedIndex = new Mock<IInvertedIndex>();
            mockedInvertedIndex.Setup(index => index.GetDocumentsOfToken(new Token("first")))
            .Returns(
                new HashSet<Document>{
                    new Document("doc1.txt", "simple/path"),
                }
            );
            mockedInvertedIndex.Setup(index => index.GetDocumentsOfToken(new Token("second")))
            .Returns(
                new HashSet<Document>{
                    new Document("doc2.txt", "simple/path"),
                }
            );
            var expected = new HashSet<Document>{
                new Document("doc1.txt", "simple/path"),
                new Document("doc2.txt", "simple/path")
            };

            var objectUnderTest = new OrTerms("+first +second -third");
            var actual = objectUnderTest.GetResults(mockedInvertedIndex.Object);

            Assert.Equal(expected, actual);
        }
    }
}