using System;
using Xunit;
using Structures;

namespace GoogleSharp.Test
{
    public class TestToken
    {
        [Fact]
        public void TestBasics()
        {
            var sampleToken = new Token("hello");
            sampleToken.Key = "world";
            var expected = new Token("world");
            Assert.Equal(expected, sampleToken);
        }

        [Fact]
        public void TestNormalization()
        {
            var sampleToken = new Token("hElLO");
            var expected = new Token("hello");
            Assert.Equal(expected, sampleToken);
        }

        [Fact]
        public void TestHashCode()
        {
            var sampleHashCode = new Token("hElLO").GetHashCode();
            var expected = "hello".GetHashCode();
            Assert.Equal(expected, sampleHashCode);
        }

        [Fact]
        public void TestCompareTo()
        {
            // less
            var actual = new Token("A").CompareTo(new Token("B"));
            var expected = -1;
            Assert.Equal(expected, actual);

            // more
            actual = new Token("B").CompareTo(new Token("A"));
            expected = 1;
            Assert.Equal(expected, actual);

            // un-castable
            Assert.Throws<ArgumentException>(() => "SampleString".CompareTo(new Token("B")));
        }

        [Fact]
        public void TestToString()
        {
            var actual = new Token("hello").ToString();
            var expected = "Token(hello)";
            Assert.Equal(expected, actual);
        }
    }
}
