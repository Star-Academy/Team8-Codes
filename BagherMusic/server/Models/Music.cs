using System.Collections.Generic;

namespace BagherMusic.Models
{
	public class Music : IEntity<int>
	{
		public Music(int id, List<int> artistsIds, List<string> artistNames, string lyrics,
			string coverUrl, string title, string trackUrl, string releaseDate)
		{
			Id = id;
			ArtistsIds = artistsIds;
			ArtistNames = artistNames;
			Lyrics = lyrics;
			CoverUrl = coverUrl;
			Title = title;
			TrackUrl = trackUrl;
			ReleaseDate = releaseDate;
		}

		public Music(int id, string title)
		{
			Id = id;
			Title = title;
		}

		public int Id { get; set; }
		public List<int> ArtistsIds { get; set; }
		public List<string> ArtistNames { get; set; }
		public string Lyrics { get; set; }
		public string CoverUrl { get; set; }
		public string Title { get; set; }
		public string TrackUrl { get; set; }
		public string ReleaseDate { get; set; }
	}
}
