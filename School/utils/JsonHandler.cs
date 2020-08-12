using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Utils
{
    public class JsonHandler<T>
    {
        public static List<T> RetrieveModels(string filePath)
        {
            if (!File.Exists(filePath))
                throw new IOException("File not found!");

            var text = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(text);
        }
    }
}