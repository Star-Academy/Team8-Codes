using System.Collections.Generic;

namespace BagherMusic.Models
{
	public class MusicNonGeneric
	{
		public MusicNonGeneric() {}

		public MusicNonGeneric(int id, string title, string releaseDate, int primaryArtistId, string primaryArtistName, List<int> featuredArtistIds, List<string> featuredArtistNames, string coverThumbnailUrl, string coverImageUrl, string spotifyUrl, string youtubeUrl, string lyricsUrl, string lyrics)
		{
			// General
			Id = id;
			Title = title;
			ReleaseDate = releaseDate;

			// Artists
			PrimaryArtistId = primaryArtistId;
			PrimaryArtistName = primaryArtistName;
			FeaturedArtistIds = featuredArtistIds;
			FeaturedArtistNames = featuredArtistNames;

			// Cover Arts
			CoverThumbnailUrl = coverThumbnailUrl;
			CoverImageUrl = coverImageUrl;

			// External Links
			SpotifyUrl = spotifyUrl;
			YoutubeUrl = youtubeUrl;

			// Lyrics
			LyricsUrl = lyricsUrl;
			Lyrics = lyrics;
		}

		// General
		public int Id { get; set; }
		public string Title { get; set; }
		public string ReleaseDate { get; set; }

		// Artists
		public int PrimaryArtistId { get; set; }
		public string PrimaryArtistName { get; set; }
		public List<int> FeaturedArtistIds { get; set; }
		public List<string> FeaturedArtistNames { get; set; }

		// Cover Arts
		public string CoverThumbnailUrl { get; set; }
		public string CoverImageUrl { get; set; }

		// External Links
		public string SpotifyUrl { get; set; }
		public string YoutubeUrl { get; set; }

		// Lyrics
		public string LyricsUrl { get; set; }
		public string Lyrics { get; set; }
	}
}
