// Standard Library
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

// Internal
using GoogleSharp.Src.Core.Structures;

namespace GoogleSharp.Src.Utils {
    public class FileHandler {
        private static readonly Regex Pattern = new Regex (@"[A-Za-z0-9]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public List<Document> GetDocumentsFromFolder (string folderPath) {
            var files = Directory.GetFiles (folderPath);
            return files.Select (f => new Document (f.Substring (f.LastIndexOf ('\\') + 1), f)).ToList ();
        }

        public string GetFileContent (string filePath) {
            return File.ReadAllText (filePath);
        }

        public virtual HashSet<Token> GetFileTokens (string filePath) {
            var fileContent = GetFileContent (filePath);
            var tokens = new HashSet<Token> ();

            foreach (var match in Pattern.Matches (fileContent).OfType<Match> ())
                tokens.Add (new Token (match.Groups[0].Value));

            return tokens;
        }
    }
}
