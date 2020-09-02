// Standard Library
using System;

namespace BagherMusic.Models
{
	public class Token : IEntity<string>
	{
		private string id;

		public Token(string id)
		{
			Id = id;
		}

		public new string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = Normalize(value);
			}
		}

		public override string ToString()
		{
			return $"Token({Id})";
		}

		private static string Normalize(string key)
		{
			string normalized = key;
			normalized = normalized.ToLower();
			return normalized;
		}
	}
}
