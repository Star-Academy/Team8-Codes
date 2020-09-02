using System.Text.Json.Serialization;

namespace BagherMusic.Models
{
	public class Artist : IEntity<int>
	{
		public Artist() {}

		public Artist(int id, string name, string thumbnailUrl, string imageUrl, string twitterName, string instagramName)
		{
			// General
			Id = id;
			Name = name;

			// Images
			ThumbnailUrl = thumbnailUrl;
			ImageUrl = imageUrl;

			// External Links
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
