// Standard Library
using System;
using System.Collections.Generic;

// Nuget Packages
using Moq;

using Xunit;

// Internal
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Structures;
using GoogleSharp.Src.Utils;

namespace Tests.Src.Core.Engine
{
    public class GoogleInvertedIndexTests : IDisposable
    {
        public static GoogleInvertedIndex sampleInvertedIndex;
        private Mock<FileHandler> mockedFileHandler;

        public GoogleInvertedIndexTests()
        {
            mockedFileHandler = new Mock<FileHandler>();
            mockedFileHandler.Setup(index => index.GetFileTokens("path/doc1.txt"))
                .Returns(
                    new HashSet<Token>
                    {
                        new Token("first"),
                        new Token("second"),
                        new Token("third")
                    }
                );
            mockedFileHandler.Setup(index => index.GetFileTokens("path/doc2.txt"))
                .Returns(
                    new HashSet<Token>
                    {
                        new Token("hello"),
                        new Token("world"),
                    }
                );
            mockedFileHandler.Setup(index => index.GetFileTokens("path/doc3.txt"))
                .Returns(
                    new HashSet<Token>
                    {
                        new Token("first"),
                        new Token("third"),
                        new Token("secon"),
                        new Token("secoond"),
                        new Token("firts")
                    }
                );
            sampleInvertedIndex = new GoogleInvertedIndex(
                new List<Document>
                {
                    new Document("doc1.txt", "path/doc1.txt"),
                    new Document("doc2.txt", "path/doc2.txt"),
                    new Document("doc3.txt", "path/doc3.txt")
                },
                mockedFileHandler.Object
            );
        }

        public void Dispose()
        {
            sampleInvertedIndex = null;
        }

        [Fact]
        public void Constructor_Seed_Success()
        {
            var expected = new Dictionary<Token, HashSet<Document>>
                {
                    {
                    new Token("first"),
                    new HashSet<Document>
                    {
                    new Document("doc1.txt", "path/doc1.txt"),
                    new Document("doc3.txt", "path/doc3.txt")
                    }
                    },
                    {
                    new Token("second"),
                    new HashSet<Document>
                    {
                    new Document("doc1.txt", "path/doc1.txt")
                    }
                    },
                    {
                    new Token("third"),
                    new HashSet<Document>
                    {
                    new Document("doc1.txt", "path/doc1.txt"),
                    new Document("doc3.txt", "path/doc3.txt")
                    }
                    },
                    {
                    new Token("hello"),
                    new HashSet<Document>
                    {
                    new Document("doc2.txt", "path/doc2.txt")
                    }
                    },
                    {
                    new Token("world"),
                    new HashSet<Document>
                    {
                    new Document("doc2.txt", "path/doc2.txt")
                    }
                    },
                    {
                    new Token("secon"),
                    new HashSet<Document>
                    {
                    new Document("doc3.txt", "path/doc3.txt")
                    }
                    },
                    {
                    new Token("secoond"),
                    new HashSet<Document>
                    {
                    new Document("doc3.txt", "path/doc3.txt")
                    }
                    },
                    {
                    new Token("firts"),
                    new HashSet<Document>
                    {
                    new Document("doc3.txt", "path/doc3.txt")
                    }
                    }
                };
            var actual = sampleInvertedIndex.Index;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDocumentsOfToken_Seed_Success()
        {
            var expected = new HashSet<Document>
            {
                new Document("doc1.txt", "path/doc1.txt"),
                new Document("doc3.txt", "path/doc3.txt"),
            };
            var actual = sampleInvertedIndex.GetDocumentsOfToken(new Token("first"));

            Assert.Equal(expected, actual);
        }
    }
}
