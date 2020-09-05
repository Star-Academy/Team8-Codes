export interface Music {
	id?: number;
	title?: string;
	ReleaseDate?: string;
	PrimaryArtistId?: number;
	PrimaryArtistName?: string;
	FeaturedArtistIds?: Array<number>;
	FeaturedArtistNames?: Array<string>;
	CoverThumbnailUrl?: string;
	CoverImageUrl?: string;
	SpotifyUrl?: string;
	YoutubeUrl?: string;
	LyricsUrl?: string;
	Lyrics?: string;
}
