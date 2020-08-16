// Standard Library
using System;

// Nuget Packages
using Xunit;

// Internal
using GoogleSharp.Src.Core.Structures;

namespace Tests.Src.Core.Structures {
    public class TokenTests {
        [Fact]
        public void Constructor_Normal_Success() {
            var sampleToken = new Token("hello");
            sampleToken.Key = "world";
            var expected = new Token("world");
            Assert.Equal(expected, sampleToken);
        }

        [Fact]
        public void Normalize_UpperCase_Success() {
            var sampleToken = new Token("hElLO");
            var expected = new Token("hello");
            Assert.Equal(expected, sampleToken);
        }

        [Fact]
        public void GetHashCode_Normal_Success() {
            var sampleHashCode = new Token("hello").GetHashCode();
            var expected = "hello".GetHashCode();
            Assert.Equal(expected, sampleHashCode);
        }

        [Theory]
        [InlineData("A", "B")]
        [InlineData("aaaa", "aab")]
        [InlineData("abc", "az")]
        public void CompareTo_Less_Success(string stringA, string stringB) {
            var actual = new Token(stringA).CompareTo(new Token(stringB));
            var expected = -1;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("B", "A")]
        [InlineData("aab", "aaaa")]
        [InlineData("az", "abc")]
        public void CompareTo_More_Success(string stringA, string stringB) {
            var actual = new Token(stringA).CompareTo(new Token(stringB));
            var expected = 1;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("sampleString")]
        [InlineData(123)]
        public void CompareTo_UnCastable_Success(object obj) {
            Assert.Throws<ArgumentException>(() => new Token("sampleToken").CompareTo(obj));
        }

        [Fact]
        public void ToString_Normal_Success() {
            var actual = new Token("hello").ToString();
            var expected = "Token(hello)";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_True_Success() {
            var first = new Token("hello");
            var second = new Token("HeLlO");

            Assert.True(first.Equals(second));
        }

        [Fact]
        public void Equals_False_Success() {
            var first = new Token("hello");
            var second = new Token("HLlO");

            Assert.False(first.Equals(second));
        }
    }
}
