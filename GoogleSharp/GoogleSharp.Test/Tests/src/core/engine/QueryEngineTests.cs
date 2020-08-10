using System;
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Query;
using GoogleSharp.Src.Utils;
using Xunit;
using GoogleSharp.Src.Core.Structures;
using System.Collections.Generic;

namespace Tests.Src.Core.Engine
{
    public class QueryEngineTests : IDisposable
    {
        public static GoogleInvertedIndex sampleInvertedIndex;

        public QueryEngineTests()
        {
            sampleInvertedIndex = new GoogleInvertedIndex(
                FileHandler.GetDocumentsFromFolder("../../../Tests/resources/input")
            );
        }

        public void Dispose()
        {
            sampleInvertedIndex = null;
        }

        [Fact]
        public void GetQueryResults_OnlyAndTerms_Success()
        {
            var queryBuilder = new QueryBuilder("first third");
            var actual = QueryEngine.GetQueryResults(queryBuilder, sampleInvertedIndex);

            var expected = new HashSet<Document> {
                new Document("doc1.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetQueryResults_OnlyOrTerms_Success()
        {
            var queryBuilder = new QueryBuilder("+first +third");
            var actual = QueryEngine.GetQueryResults(queryBuilder, sampleInvertedIndex);

            var expected = new HashSet<Document> {
                new Document("doc1.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetQueryResults_OnlyExcTerms_ThrowsException()
        {
            var queryBuilder = new QueryBuilder("-first -third");

            Assert.Throws<ArgumentException>(() => QueryEngine.GetQueryResults(queryBuilder, sampleInvertedIndex));
        }

        [Fact]
        public void GetQueryResults_AndOrTerms_Success()
        {
            var queryBuilder = new QueryBuilder("first +hello second");
            var actual = QueryEngine.GetQueryResults(queryBuilder, sampleInvertedIndex);

            var expected = new HashSet<Document> {
                new Document("doc1.txt", "simple/path"),
                new Document("doc2.txt", "simple/path")
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetQueryResults_AndExcTerms_Success()
        {
            var queryBuilder = new QueryBuilder("first -second");
            var actual = QueryEngine.GetQueryResults(queryBuilder, sampleInvertedIndex);

            var expected = new HashSet<Document> {
                new Document("doc3.txt", "simple/path")
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetQueryResults_OrExcTerms_Success()
        {
            var queryBuilder = new QueryBuilder("+first +hello -second");
            var actual = QueryEngine.GetQueryResults(queryBuilder, sampleInvertedIndex);

            var expected = new HashSet<Document> {
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetQueryResults_AllTerms_Success()
        {
            var queryBuilder = new QueryBuilder("first +hello -second");
            var actual = QueryEngine.GetQueryResults(queryBuilder, sampleInvertedIndex);

            var expected = new HashSet<Document> {
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            };

            Assert.Equal(expected, actual);
        }
    }
}