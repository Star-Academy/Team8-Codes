// Standard Library
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using BagherMusic.Models;

namespace BagherEngine.Utils
{
	public class FileHandler
	{
		public static List<G> GetEntitiesFromFolder<T, G>(string folderPath)
		where T : IComparable
		where G : IEntity<T>
		{
			var files = Directory.GetFiles(folderPath);
			return files.Select(f => JsonSerializer.Deserialize<G>(GetFileContent(f))).ToList();
		}

		public static string GetFileContent(string filePath)
		{
			return File.ReadAllText(filePath);
		}
	}
}
