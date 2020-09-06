export interface Music {
	id?: number;
	title?: string;
	releaseDate?: string;
	primaryArtistId?: number;
	primaryArtistName?: string;
	featuredArtistIds?: Array<number>;
	featuredArtistNames?: Array<string>;
	coverThumbnailUrl?: string;
	coverImageUrl?: string;
	spotifyUrl?: string;
	youtubeUrl?: string;
	lyricsUrl?: string;
	lyrics?: string;
}
