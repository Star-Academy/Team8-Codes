import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { faChevronLeft } from '@fortawesome/free-solid-svg-icons';
import { faChevronRight } from '@fortawesome/free-solid-svg-icons';

import { ResultSet } from '../../models/ResultSet';
import { Music } from '../../models/Music';
import { Artist } from '../../models/Artist';

import { SearchService } from '../../services/search.service';

@Component({
	selector: 'app-search-results',
	templateUrl: './search-results.component.html',
	styleUrls: [ './search-results.component.scss' ]
})
export class SearchResultsComponent implements OnInit {
	query: string;

	faChevronLeft = faChevronLeft;
	faChevronRight = faChevronRight;

	artists: Array<Artist>;
	musics: Array<Music>;

	artistsPageIndex: number;
	musicsPageIndex: number;

	@ViewChild('artistsContainer') artistsContainerElement: ElementRef;
	@ViewChild('musicsContainer') musicsContainerElement: ElementRef;
	@ViewChild('artistsScrollLeft') artistsScrollLeftElement: ElementRef;
	@ViewChild('musicsScrollLeft') musicsScrollLeftElement: ElementRef;

	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private searchService: SearchService
	) {}

	ngOnInit(): void {
		this.route.paramMap.subscribe((params) => {
			this.query = params.get('query');
			this.init();
		});
	}

	init() {
		this.artistsPageIndex = 0;
		this.musicsPageIndex = 0;

		this.artists = [];
		this.musics = [];

		this.loadArtists();
		this.loadMusics();
	}

	loadMusics() {
		this.searchService
			.getSearchResultsForMusics(this.query, this.musicsPageIndex)
			.subscribe(
				(res: ResultSet<Music>) => {
					this.musics = [ ...this.musics, ...res.hits ];
					this.musicsPageIndex++;
				},
				(err) => console.log(err)
			);
	}

	loadArtists() {
		this.searchService
			.getSearchResultsForArtists(this.query, this.artistsPageIndex)
			.subscribe(
				(res: ResultSet<Artist>) => {
					this.artists = [ ...this.artists, ...res.hits ];
					this.artistsPageIndex++;
				},
				(err) => console.log(err)
			);
	}
}
