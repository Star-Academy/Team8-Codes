import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Music } from '../../models/Music';
import { Artist } from '../../models/Artist';

import { SearchService } from '../../services/search.service';

@Component({
	selector: 'app-search-results',
	templateUrl: './search-results.component.html',
	styleUrls: [ './search-results.component.scss' ]
})
export class SearchResultsComponent implements OnInit {
	artists: Array<Artist>;
	musics: Array<Music>;

	constructor(private router: Router, private searchService: SearchService) {}

	ngOnInit(): void {
		this.searchService
			.getSearchResultsForMusic()
			.subscribe((res) => console.log(res), (err) => console.log(err));
	}
}
