using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Utils
{
    public class JsonHandler<T>
    {
        public static List<T> retrieveModels(string filePath)
        {
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<T>>(text);
            }

            throw new IOException("File not found!");
        }
    }
}