import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class SearchService {
	private query: string;

	constructor(private http: HttpClient) {}

	setQuery(q: string) {
		this.query = q;
	}

	getSearchResultsForMusic() {
		return this.http.get(
			'http://localhost:5000/api/search/music?query=kanye west&pageIndex=0'
		);
	}
}
