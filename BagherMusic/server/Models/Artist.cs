// Standard
using System.Text.Json.Serialization;

namespace BagherMusic.Models
{
	public class Artist : IEntity<int>
	{
		public Artist() {}

		public Artist(int id, string name, string thumbnailUrl, string imageUrl, string twitterName, string instagramName)
		{
			InitializeMetaData(id, name);
			InitializeImages(thumbnailUrl, imageUrl);
			InitializeExternalLinks(twitterName, instagramName);
		}

		private void InitializeMetaData(int id, string name)
		{
			Id = id;
			Name = name;
		}

		private void InitializeImages(string thumbnailUrl, string imageUrl)
		{
			ThumbnailUrl = thumbnailUrl;
			ImageUrl = imageUrl;
		}

		private void InitializeExternalLinks(string twitterName, string instagramName)
		{
			TwitterName = twitterName;
			InstagramName = instagramName;
		}

		// General
		[JsonPropertyName("name")]
		public string Name { get; set; }

		// Images
		[JsonPropertyName("thumbnailUrl")]
		public string ThumbnailUrl { get; set; }

		[JsonPropertyName("imageUrl")]
		public string ImageUrl { get; set; }

		// External Links
		[JsonPropertyName("twitterName")]
		public string TwitterName { get; set; }

		[JsonPropertyName("instagramName")]
		public string InstagramName { get; set; }
	}
}
