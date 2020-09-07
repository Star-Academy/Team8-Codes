// Standard
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BagherMusic.Models
{
	public class Music : IEntity<int>
	{
		public Music() {}

		public Music(int id, string title, string releaseDate, int primaryArtistId, string primaryArtistName, List<int> featuredArtistIds, List<string> featuredArtistNames, string coverThumbnailUrl, string coverImageUrl, string spotifyUrl, string youtubeUrl, string lyricsUrl, string lyrics)
		{
			InitializeMetadata(id, title, releaseDate);
			InitializeArtists(primaryArtistId, primaryArtistName, featuredArtistIds, featuredArtistNames);
			InitializeCoverArt(coverThumbnailUrl, coverImageUrl);
			InitializeExternalLinks(spotifyUrl, youtubeUrl);
			InitializeLyrics(lyricsUrl, lyrics);
		}

		private void InitializeMetadata(int id, string title, string releaseDate)
		{
			Id = id;
			Title = title;
			ReleaseDate = releaseDate;
		}

		private void InitializeArtists(int primaryArtistId, string primaryArtistName, List<int> featuredArtistIds, List<string> featuredArtistNames)
		{
			PrimaryArtistId = primaryArtistId;
			PrimaryArtistName = primaryArtistName;
			FeaturedArtistIds = featuredArtistIds;
			FeaturedArtistNames = featuredArtistNames;
		}

		private void InitializeCoverArt(string coverThumbnailUrl, string coverImageUrl)
		{
			CoverThumbnailUrl = coverThumbnailUrl;
			CoverImageUrl = coverImageUrl;
		}

		private void InitializeExternalLinks(string spotifyUrl, string youtubeUrl)
		{
			SpotifyUrl = spotifyUrl;
			YoutubeUrl = youtubeUrl;
		}

		private void InitializeLyrics(string lyricsUrl, string lyrics)
		{
			LyricsUrl = lyricsUrl;
			Lyrics = lyrics;
		}

		// General
		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("releaseDate")]
		public string ReleaseDate { get; set; }

		// Artists
		[JsonPropertyName("primaryArtistId")]
		public int PrimaryArtistId { get; set; }

		[JsonPropertyName("primaryArtistName")]
		public string PrimaryArtistName { get; set; }

		[JsonPropertyName("featuredArtistIds")]
		public List<int> FeaturedArtistIds { get; set; }

		[JsonPropertyName("featuredArtistNames")]
		public List<string> FeaturedArtistNames { get; set; }

		// Cover Arts
		[JsonPropertyName("coverThumbnailUrl")]
		public string CoverThumbnailUrl { get; set; }

		[JsonPropertyName("coverImageUrl")]
		public string CoverImageUrl { get; set; }

		// External Links
		[JsonPropertyName("spotifyUrl")]
		public string SpotifyUrl { get; set; }

		[JsonPropertyName("youtubeUrl")]
		public string YoutubeUrl { get; set; }

		// Lyrics
		[JsonPropertyName("lyricsUrl")]
		public string LyricsUrl { get; set; }

		[JsonPropertyName("lyrics")]
		public string Lyrics { get; set; }
	}
}
