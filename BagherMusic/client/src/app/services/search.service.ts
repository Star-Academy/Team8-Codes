import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class SearchService {
	private query: string = 'kanye';

	constructor(private http: HttpClient) {}

	setQuery(q: string) {
		this.query = q;
	}

	getSearchResultsForArtists(pageIndex: number) {
		return this.http.get(
			`http://localhost:5000/api/search/artist?query=
			${this.query}&pageIndex=${pageIndex}`
		);
	}

	getSearchResultsForMusics(pageIndex: number) {
		return this.http.get(
			`http://localhost:5000/api/search/music?query=
			${this.query}&pageIndex=${pageIndex}`
		);
	}
}
