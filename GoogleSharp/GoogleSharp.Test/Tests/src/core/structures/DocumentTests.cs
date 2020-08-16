// Standard Library
using System;

// Nuget Packages
using Xunit;

// Internal
using GoogleSharp.Src.Core.Structures;

namespace Tests.Src.Core.Structures {
    public class DocumentTests {
        [Fact]
        public void Constructor_Normal_Success() {
            var sampleDocument = new Document("doc.txt", "path/doc.txt");
            sampleDocument.Id = "newId.txt";
            sampleDocument.Path = "newPath/newId.txt";
            var expected = new Document("newId.txt", "newPath/newId.txt");

            Assert.Equal(expected, sampleDocument);
        }

        [Fact]
        public void ToString_Normal_Success() {
            var sampleDocument = new Document("doc.txt", "path/doc.txt");
            var actual = sampleDocument.ToString();
            var expected = "Document(doc.txt)";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_Castable_True() {
            var sampleDocument1 = new Document("doc.txt", "path/doc.txt");
            var sampleDocument2 = new Document("doc.txt", "samplePath/doc.txt");

            Assert.True(sampleDocument1.Equals(sampleDocument2));
        }

        [Fact]
        public void Equals_Castable_False() {
            var sampleDocument1 = new Document("doc.txt", "path/doc.txt");
            var sampleDocument2 = new Document("doc2.txt", "path/doc.txt");

            Assert.False(sampleDocument1.Equals(sampleDocument2));
        }

        [Fact]
        public void Equals_Uncastable_False() {
            var sampleDocument = new Document("doc.txt", "path/doc.txt");
            var sampleToken = "Hello";

            Assert.False(sampleDocument.Equals(sampleToken));
        }
    }
}
