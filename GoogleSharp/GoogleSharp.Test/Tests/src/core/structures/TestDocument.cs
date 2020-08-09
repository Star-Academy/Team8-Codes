using System;
using Xunit;

namespace GoogleSharp.Test
{
    public class TestDocument
    {
        public void TestBasics()
        {
            Assert.True(false);
        }

        [Fact]
        public void TestToString()
        {
            var actual = "";
            var expected = "Document(doc1.txt)";
            Assert.Equal(expected, actual);
        }
    }
}
