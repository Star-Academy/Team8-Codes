import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class SearchService {
	constructor(private http: HttpClient) {}

	getSearchResultsForArtists(query: string, pageIndex: number) {
		return this.http.get(
			`http://localhost:5000/api/search/artist?query=
			${query}&pageIndex=${pageIndex}`
		);
	}

	getSearchResultsForMusics(query: string, pageIndex: number) {
		return this.http.get(
			`http://localhost:5000/api/search/music?query=
			${query}&pageIndex=${pageIndex}`
		);
	}

	getMusic(id: number) {
		return this.http.get(`http://localhost:5000/api/music/${id}`);
	}

	getArtist(id: number) {
		return this.http.get(`http://localhost:5000/api/artist/${id}`);
	}

	getArtistMusics(id: number) {
		return this.http.get(`http://localhost:5000/api/artist/musics/${id}`);
	}
}
