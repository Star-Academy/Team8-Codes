using System;
using Xunit;
using Structures;

namespace GoogleSharp.Test
{
    public class TestDocument
    {
        [Fact]
        public void TestBasics()
        {
            var sampleDocument = new Document("doc.txt", "path/doc.txt");
            sampleDocument.Id = "newId.txt";
            sampleDocument.Path = "newPath/newId.txt";
            var expected = new Document("newId.txt", "newPath/newId.txt");
            Assert.Equal(expected, sampleDocument);
        }

        [Fact]
        public void TestToString()
        {
            var sampleDocument = new Document("doc.txt", "path/doc.txt");
            String actual = sampleDocument.ToString();
            var expected = "Document(doc.txt)";
            Assert.Equal(expected, actual);
        }
    }
}
