// Standard Library
using System;
using System.Collections.Generic;

// Nuget Packages
using Moq;
using Xunit;

// Internal
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Query;
using GoogleSharp.Src.Core.Structures;

namespace Tests.Src.Core.Engine {
    public class QueryEngineTests : IDisposable {
        public static Mock<IInvertedIndex> mockedInvertedIndex;

        public QueryEngineTests () {
            mockedInvertedIndex = new Mock<IInvertedIndex> ();
            mockedInvertedIndex.Setup (index => index.GetDocumentsOfToken (new Token ("first")))
                .Returns (
                    new HashSet<Document> {
                        new Document ("doc1.txt", "simple/path"),
                        new Document ("doc3.txt", "simple/path")
                    });
            mockedInvertedIndex.Setup (index => index.GetDocumentsOfToken (new Token ("second")))
                .Returns (
                    new HashSet<Document> {
                        new Document ("doc1.txt", "simple/path"),
                    });
            mockedInvertedIndex.Setup (index => index.GetDocumentsOfToken (new Token ("third")))
                .Returns (
                    new HashSet<Document> {
                        new Document ("doc1.txt", "simple/path"),
                        new Document ("doc3.txt", "simple/path"),
                    });
            mockedInvertedIndex.Setup (index => index.GetDocumentsOfToken (new Token ("hello")))
                .Returns (
                    new HashSet<Document> {
                        new Document ("doc2.txt", "simple/path")
                    });
            mockedInvertedIndex.Setup (index => index.GetDocumentsOfToken (new Token ("world")))
                .Returns (
                    new HashSet<Document> {
                        new Document ("doc2.txt", "simple/path")
                    });
        }

        public void Dispose () {
            mockedInvertedIndex = null;
        }

        [Fact]
        public void GetQueryResults_OnlyAndTerms_Success () {
            var queryBuilder = new QueryBuilder ("first third");
            var actual = QueryEngine.GetQueryResults (queryBuilder, mockedInvertedIndex.Object);

            var expected = new HashSet<Document> {
                new Document ("doc1.txt", "simple/path"),
                new Document ("doc3.txt", "simple/path")
            };

            Assert.Equal (expected, actual);
        }

        [Fact]
        public void GetQueryResults_OnlyOrTerms_Success () {
            var queryBuilder = new QueryBuilder ("+first +third");
            var actual = QueryEngine.GetQueryResults (queryBuilder, mockedInvertedIndex.Object);

            var expected = new HashSet<Document> {
                new Document ("doc1.txt", "simple/path"),
                new Document ("doc3.txt", "simple/path")
            };

            Assert.Equal (expected, actual);
        }

        [Fact]
        public void GetQueryResults_OnlyExcTerms_ThrowsException () {
            var queryBuilder = new QueryBuilder ("-first -third");

            Assert.Throws<ArgumentException> (() => QueryEngine.GetQueryResults (queryBuilder, mockedInvertedIndex.Object));
        }

        [Fact]
        public void GetQueryResults_AndOrTerms_Success () {
            var queryBuilder = new QueryBuilder ("first +hello second");
            var actual = QueryEngine.GetQueryResults (queryBuilder, mockedInvertedIndex.Object);

            var expected = new HashSet<Document> {
                new Document ("doc1.txt", "simple/path"),
                new Document ("doc2.txt", "simple/path")
            };

            Assert.Equal (expected, actual);
        }

        [Fact]
        public void GetQueryResults_AndExcTerms_Success () {
            var queryBuilder = new QueryBuilder ("first -second");
            var actual = QueryEngine.GetQueryResults (queryBuilder, mockedInvertedIndex.Object);

            var expected = new HashSet<Document> {
                new Document ("doc3.txt", "simple/path")
            };

            Assert.Equal (expected, actual);
        }

        [Fact]
        public void GetQueryResults_OrExcTerms_Success () {
            var queryBuilder = new QueryBuilder ("+first +hello -second");
            var actual = QueryEngine.GetQueryResults (queryBuilder, mockedInvertedIndex.Object);

            var expected = new HashSet<Document> {
                new Document ("doc2.txt", "simple/path"),
                new Document ("doc3.txt", "simple/path")
            };

            Assert.Equal (expected, actual);
        }

        [Fact]
        public void GetQueryResults_AllTerms_Success () {
            var queryBuilder = new QueryBuilder ("first +hello -second");
            var actual = QueryEngine.GetQueryResults (queryBuilder, mockedInvertedIndex.Object);

            var expected = new HashSet<Document> {
                new Document ("doc2.txt", "simple/path"),
                new Document ("doc3.txt", "simple/path")
            };

            Assert.Equal (expected, actual);
        }
    }
}
