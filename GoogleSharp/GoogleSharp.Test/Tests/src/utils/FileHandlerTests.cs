// Standard Library
using System;
using System.Collections.Generic;

// Nuget Packages
using Xunit;

// Internal
using GoogleSharp.Src.Core.Structures;
using GoogleSharp.Src.Utils;

namespace Tests.Src.Utils {
    public class FileHandlerTests : IDisposable {
        private const string ResourcePath = "../../../Tests/resources/input";
        private FileHandler sampleHandler;

        public FileHandlerTests () {
            sampleHandler = new FileHandler ();
        }

        public void Dispose () {
            sampleHandler = null;
        }

        [Fact]
        public void GetDocumentsFromFolder_Normal_Success () {
            var expected = new List<Document> {
                new Document ("doc1.txt", "dummyPath/doc1.txt"),
                new Document ("doc2.txt", "dummyPath/doc2.txt"),
                new Document ("doc3.txt", "dummyPath/doc3.txt")
            };

            var actual = sampleHandler.GetDocumentsFromFolder (ResourcePath);

            Assert.Equal (expected[0].Id, actual[0].Id);
            Assert.Equal (expected[1].Id, actual[1].Id);
            Assert.Equal (expected[2].Id, actual[2].Id);
        }

        [Fact]
        public void GetFileTokens_Normal_Success () {
            var expected = new HashSet<Token> {
                new Token ("first"),
                new Token ("second"),
                new Token ("third")
            };

            var actual = sampleHandler.GetFileTokens (ResourcePath + "/doc1.txt");

            Assert.Equal (expected, actual);
        }

        [Fact]
        public void GetFileContent_Normal_Success () {
            var expected = "hello world";
            var actual = sampleHandler.GetFileContent (ResourcePath + "/doc2.txt");
            Assert.Equal (expected, actual);
        }
    }
}
