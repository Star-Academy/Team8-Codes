// Standard Library
using System.Collections.Generic;

// Internal
using GoogleSharp.Src.Core.Structures;
using GoogleSharp.Src.Utils;

namespace GoogleSharp.Src.Core.Engine {
    public class GoogleInvertedIndex : IInvertedIndex {
        public readonly Dictionary<Token, HashSet<Document>> Index;

        public GoogleInvertedIndex (List<Document> documents, FileHandler handler) {
            Index = new Dictionary<Token, HashSet<Document>> ();
            IndexDocuments (documents, handler);
        }

        public HashSet<Document> GetDocumentsOfToken (Token token) {
            var result = Index[token];
            return result ?? new HashSet<Document> ();
        }

        private void IndexDocument (Document doc, FileHandler handler) {
            foreach (var token in handler.GetFileTokens (doc.Path)) {
                if (!Index.ContainsKey (token))
                    Index.Add (token, new HashSet<Document> ());
                Index[token].Add (doc);
            }
        }

        private void IndexDocuments (List<Document> documents, FileHandler handler) {
            foreach (var doc in documents)
                IndexDocument (doc, handler);
        }
    }
}
