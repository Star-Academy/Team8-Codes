using Xunit;
using System;
using System.Collections.Generic;
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Structures;
using GoogleSharp.Src.Utils;
using Moq;


namespace Tests.Src.Core.Engine
{

    public class GoogleInvertedIndexTests : IDisposable
    {
        public const string ResourceFolderPath = "../../../Tests/resources/input";
        public static GoogleInvertedIndex sampleInvertedIndex;

        public GoogleInvertedIndexTests()
        {
            sampleInvertedIndex = new GoogleInvertedIndex(
                FileHandler.GetDocumentsFromFolder(ResourceFolderPath)
            );
        }

        public void Dispose()
        {
            sampleInvertedIndex = null;
        }

        [Fact]
        public void Constructor_Seed_Success()
        {
            var expected = new Dictionary<Token, HashSet<Document>>(){
                { new Token("first") , new HashSet<Document>{
                    new Document("doc1.txt", "simple/path"),
                    new Document("doc3.txt", "simple/path"),
                } },
                { new Token("second") , new HashSet<Document>{
                    new Document("doc1.txt", "simple/path"),
                } },
                { new Token("third") , new HashSet<Document>{
                    new Document("doc1.txt", "simple/path"),
                    new Document("doc3.txt", "simple/path"),
                } },
                { new Token("hello") , new HashSet<Document>{
                    new Document("doc2.txt", "simple/path"),
                } },
                { new Token("world") , new HashSet<Document>{
                    new Document("doc2.txt", "simple/path"),
                } },
                { new Token("secon") , new HashSet<Document>{
                    new Document("doc3.txt", "simple/path"),
                } },
                { new Token("secoond") , new HashSet<Document>{
                    new Document("doc3.txt", "simple/path"),
                } },
                { new Token("firts") , new HashSet<Document>{
                    new Document("doc3.txt", "simple/path"),
                } }
            };
            var actual = sampleInvertedIndex.Index;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDocumentsOfToken_Seed_Success()
        {
            var expected = new HashSet<Document>{
                new Document("doc1.txt", "simple/path"),
                new Document("doc3.txt", "simple/path"),
            };
            var actual = sampleInvertedIndex.GetDocumentsOfToken(new Token("first"));

            Assert.Equal(expected, actual);
        }
    }

}