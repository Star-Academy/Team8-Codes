// Standard Library
using System.Collections.Generic;

// Internal
using GoogleSharp.Src.Core.Structures;
using GoogleSharp.Src.Utils;


namespace GoogleSharp.Src.Core.Engine
{
    public class GoogleInvertedIndex : IInvertedIndex
    {
        public Dictionary<Token, HashSet<Document>> Index { get; set; }

        public GoogleInvertedIndex(List<Document> documents, FileHandler handler)
        {
            this.Index = new Dictionary<Token, HashSet<Document>>();
            this.IndexDocuments(documents, handler);
        }

        private void IndexDocument(Document doc, FileHandler handler)
        {
            foreach (var token in handler.GetFileTokens(doc.Path))
            {
                if (!this.Index.ContainsKey(token))
                    this.Index.Add(token, new HashSet<Document>());
                this.Index[token].Add(doc);
            }
        }

        private void IndexDocuments(List<Document> documents, FileHandler handler)
        {
            foreach (var doc in documents)
                IndexDocument(doc, handler);
        }

        public HashSet<Document> GetDocumentsOfToken(Token token)
        {
            var result = this.Index[token];
            return result == null ? new HashSet<Document>() : result;
        }
    }
}