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
    public class AndTermsTests
    {
        [Fact]
        public void Constructor_OnlyAnds_Success()
        {
            var expected = new List<Token>{
                new Token("first"),
                new Token("second2"),
                new Token("3rd")
            };
            var actual = new AndTerms("first second2 3rd").Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_NoAnds_Success()
        {
            var expected = new List<Token>();
            var actual = new AndTerms("-first +second2 -3rd").Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_SomeAnds_Success()
        {
            var expected = new List<Token>{
                new Token("first"),
                new Token("4th"),
                new Token("5th"),
            };
            var actual = new AndTerms("first +second2 -3rd 4th 5th").Tokens;

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

            var objectUnderTest = new AndTerms("first");
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
                    new Document("doc2.txt", "simple/path"),
                    new Document("doc3.txt", "simple/path"),
                }
            );
            mockedInvertedIndex.Setup(index => index.GetDocumentsOfToken(new Token("second")))
            .Returns(
                new HashSet<Document>{
                    new Document("doc2.txt", "simple/path"),
                    new Document("doc3.txt", "simple/path"),
                }
            );
            var expected = new HashSet<Document>{
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            };

            var objectUnderTest = new AndTerms("first second -third");
            var actual = objectUnderTest.GetResults(mockedInvertedIndex.Object);

            Assert.Equal(expected, actual);
        }
    }
}