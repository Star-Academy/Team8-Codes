using System;
using Xunit;
using Utils;
using Structures;
using System.Collections.Generic;

namespace GoogleSharp.Test
{
    public class TestFileHandler
    {
        public const string RESOURCE_PATH = "../../../Tests/resources/input";

        [Fact]
        public void TestGetDocumentsFromFolder()
        {
            var expected = new List<Document>();
            expected.Add(new Document("doc1.txt", "dummyPath/doc1.txt"));
            expected.Add(new Document("doc2.txt", "dummyPath/doc2.txt"));
            expected.Add(new Document("doc3.txt", "dummyPath/doc3.txt"));

            var actual = FileHandler.GetDocumentsFromFolder(RESOURCE_PATH);

            Assert.Equal(expected[0].Id, actual[0].Id);
            Assert.Equal(expected[1].Id, actual[1].Id);
            Assert.Equal(expected[2].Id, actual[2].Id);
        }

        [Fact]
        public void TestGetFileTokens()
        {
            var actual = FileHandler.GetFileTokens(RESOURCE_PATH + "/doc1.txt");
            var expected = new HashSet<Token>();
            expected.Add(new Token("first"));
            expected.Add(new Token("second"));
            expected.Add(new Token("thidr"));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetFileContent()
        {
            var actual = FileHandler.GetFileContent(RESOURCE_PATH + "/doc2.txt");
            var expected = "hello world";
            Assert.Equal(expected, actual);
        }
    }
}
