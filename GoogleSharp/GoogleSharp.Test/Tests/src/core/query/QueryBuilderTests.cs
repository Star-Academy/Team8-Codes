// Standard Library
using System.Collections.Generic;

// Nuget Packages
using Xunit;

// Internal
using GoogleSharp.Src.Core.Query;
using GoogleSharp.Src.Core.Structures;

namespace Tests.Src.Core.Query
{
    public class QueryBuilderTests
    {
        [Fact]
        public void Constructor_OnlyOrTerms_Success()
        {
            var queryBuilder = new QueryBuilder("+first +second +third");
            var expected = new List<Token> { new Token("first"), new Token("second"), new Token("third") };
            var actual = queryBuilder.Ors.Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_OnlyAndTerms_Success()
        {
            var queryBuilder = new QueryBuilder("first second third");
            var expected = new List<Token> { new Token("first"), new Token("second"), new Token("third") };
            var actual = queryBuilder.Ands.Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_OnlyExcTerms_Success()
        {
            var queryBuilder = new QueryBuilder("-first -second -third");
            var expected = new List<Token> { new Token("first"), new Token("second"), new Token("third") };
            var actual = queryBuilder.Excs.Tokens;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_AndOr_Success()
        {
            var queryBuilder = new QueryBuilder("first +second third");

            var expectedAndTerms = new List<Token> { new Token("first"), new Token("third") };
            var expectedOrTerms = new List<Token> { new Token("second") };

            var actualAndTerms = queryBuilder.Ands.Tokens;
            var actualOrTerms = queryBuilder.Ors.Tokens;

            Assert.Equal(expectedAndTerms, actualAndTerms);
            Assert.Equal(expectedOrTerms, actualOrTerms);
        }

        [Fact]
        public void Constructor_AndExc_Success()
        {
            var queryBuilder = new QueryBuilder("first -second third");

            var expectedAndTerms = new List<Token> { new Token("first"), new Token("third") };
            var expectedExcTerms = new List<Token> { new Token("second") };

            var actualAndTerms = queryBuilder.Ands.Tokens;
            var actualExcTerms = queryBuilder.Excs.Tokens;

            Assert.Equal(expectedAndTerms, actualAndTerms);
            Assert.Equal(expectedExcTerms, actualExcTerms);
        }

        [Fact]
        public void Constructor_OrExc_Success()
        {
            var queryBuilder = new QueryBuilder("+first -second +third");

            var expectedOrTerms = new List<Token> { new Token("first"), new Token("third") };
            var expectedExcTerms = new List<Token> { new Token("second") };

            var actualOrTerms = queryBuilder.Ors.Tokens;
            var actualExcTerms = queryBuilder.Excs.Tokens;

            Assert.Equal(expectedOrTerms, actualOrTerms);
            Assert.Equal(expectedExcTerms, actualExcTerms);
        }

        [Fact]
        public void Constructor_All_Success()
        {
            var queryBuilder = new QueryBuilder("first +second -third");

            var expectedAndTerms = new List<Token> { new Token("first") };
            var expectedOrTerms = new List<Token> { new Token("second") };
            var expectedExcTerms = new List<Token> { new Token("third") };

            var actualAndTerms = queryBuilder.Ands.Tokens;
            var actualOrTerms = queryBuilder.Ors.Tokens;
            var actualExcTerms = queryBuilder.Excs.Tokens;

            Assert.Equal(expectedAndTerms, actualAndTerms);
            Assert.Equal(expectedOrTerms, actualOrTerms);
            Assert.Equal(expectedExcTerms, actualExcTerms);
        }
    }
}
