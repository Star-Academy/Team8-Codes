namespace BagherMusic.Models
{
	public class Artist : IEntity<int>
	{
		public Artist(int id, string name)
		{
			Id = id;
			Name = name;
		}

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
		public int Id { get; set; }
		public string Name { get; set; }

		// Images
		public string ThumbnailUrl { get; set; }
		public string ImageUrl { get; set; }

		// External Links
		public string TwitterName { get; set; }
		public string InstagramName { get; set; }
	}
}
