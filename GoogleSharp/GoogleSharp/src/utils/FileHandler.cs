using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GoogleSharp.Src.Core.Structures;

namespace GoogleSharp.Src.Utils
{
    public class FileHandler
    {
        public static List<Document> GetDocumentsFromFolder(string folderPath)
        {
            var files = Directory.GetFiles(folderPath);
            return files.Select(f => new Document(f.Substring(f.LastIndexOf('\\') + 1), f)).ToList();
        }

        public static string GetFileContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static HashSet<Token> GetFileTokens(string filePath)
        {
            var fileContent = GetFileContent(filePath);
            var tokens = new HashSet<Token>();
            Regex regex = new Regex(@"[A-Za-z0-9]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            regex.Matches(fileContent)
            .OfType<Match>().ToList().ForEach(match => { tokens.Add(new Token(match.Groups[0].Value)); });

            return tokens;
        }
    }
}