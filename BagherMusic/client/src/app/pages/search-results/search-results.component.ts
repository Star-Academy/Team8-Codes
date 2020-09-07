import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

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

	artistsCompletelyLoaded: boolean;
	musicsCompletelyLoaded: boolean;

	constructor(
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
		this.artistsCompletelyLoaded = false;
		this.musicsCompletelyLoaded = false;

		this.artistsPageIndex = 0;
		this.musicsPageIndex = 0;

		this.artists = [];
		this.musics = [];

		this.loadArtists();
		this.loadMusics();
	}

	loadMusics() {
		if (!this.musicsCompletelyLoaded)
			this.searchService
				.getSearchResultsForMusics(this.query, this.musicsPageIndex)
				.subscribe(
					(res: ResultSet<Music>) => {
						if (res.count > 0) {
							this.musics = [ ...this.musics, ...res.hits ];
							this.musicsPageIndex++;
						} else {
							this.musicsCompletelyLoaded = true;
						}
					},
					(err) => console.log(err)
				);
	}

	loadArtists() {
		if (!this.artistsCompletelyLoaded)
			this.searchService
				.getSearchResultsForArtists(this.query, this.artistsPageIndex)
				.subscribe(
					(res: ResultSet<Artist>) => {
						if (res.count > 0) {
							this.artists = [ ...this.artists, ...res.hits ];
							this.artistsPageIndex++;
						} else {
							this.artistsCompletelyLoaded = true;
						}
					},
					(err) => console.log(err)
				);
	}

	getArtistCards(e) {
		const interval = setInterval(() => {
			if (!this.artistsCompletelyLoaded && !this.overflowing(e.cards))
				this.loadArtists();
			else clearInterval(interval);
		}, 1000);
	}

	getMusicCards(e) {
		const interval = setInterval(() => {
			if (!this.musicsCompletelyLoaded && !this.overflowing(e.cards))
				this.loadMusics();
			else clearInterval(interval);
		}, 1000);
	}

	overflowing(element: Element): boolean {
		return (
			element.clientWidth < element.scrollWidth ||
			element.clientHeight < element.scrollHeight
		);
	}
}
