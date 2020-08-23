// Standard Library
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

// Internal
using BagherEngine.Models;

namespace BagherEngine.Utils
{
    public class FileHandler
    {
        public static List<Document> GetDocumentsFromFolder(string folderPath)
        {
            var files = Directory.GetFiles(folderPath);
            return files.Select(f => new Document(Path.GetFileName(f), GetFileContent(f))).ToList();
        }

        public static string GetFileContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
