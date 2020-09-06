import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { faMusic } from '@fortawesome/free-solid-svg-icons';
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

	faSearch = faSearch;
	faMusic = faMusic;
	faChevronLeft = faChevronLeft;
	faChevronRight = faChevronRight;

	artists: Array<Artist>;
	musics: Array<Music>;

	artistsPageIndex: number;
	musicsPageIndex: number;

	@ViewChild('searchBox') searchBoxElement: ElementRef;
	@ViewChild('searchInput') searchInputElement: ElementRef;
	@ViewChild('artistsContainer') artistsContainerElement: ElementRef;
	@ViewChild('musicsContainer') musicsContainerElement: ElementRef;
	@ViewChild('artistsScrollLeft') artistsScrollLeftElement: ElementRef;
	@ViewChild('musicsScrollLeft') musicsScrollLeftElement: ElementRef;
	searchIconClass = 'text-fade';

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

	focusedOnInput(e) {
		this.searchBoxElement.nativeElement.classList.add('shadow-gentle');
		this.searchIconClass = 'text-bright';
	}

	blurredInput(e) {
		this.searchBoxElement.nativeElement.classList.remove('shadow-gentle');

		if (!this.searchInputElement.nativeElement.value)
			this.searchIconClass = 'text-fade';
	}

	searchListener(e) {
		e.preventDefault();

		const query = this.searchInputElement.nativeElement.value;

		if (!query) return;

		this.router.navigate([ 'search-results', query ]);
	}

	clickedOnMusicCard = (e, id) => {
		this.router.navigate([ 'music', id ]);
	};

	mouseEnteredCard = (e) => {
		e.target.childNodes[0].classList.add('active');
	};

	mouseLeftCard = (e) => {
		e.target.childNodes[0].classList.remove('active');
	};

	scrollLeft = (e, container) => {
		if (container === 'musics') {
			this.musicsContainerElement.nativeElement.scrollLeft -= 330;

			if (this.musicsContainerElement.nativeElement.scrollLeft <= 0)
				this.musicsScrollLeftElement.nativeElement.classList.add(
					'hide'
				);
		} else if (container === 'artists') {
			this.artistsContainerElement.nativeElement.scrollLeft -= 330;

			if (this.artistsContainerElement.nativeElement.scrollLeft <= 0)
				this.artistsScrollLeftElement.nativeElement.classList.add(
					'hide'
				);
		}
	};

	scrollRight = (e, container) => {
		if (container === 'musics') {
			this.musicsContainerElement.nativeElement.scrollLeft += 330;
			this.musicsScrollLeftElement.nativeElement.classList.remove('hide');

			console.log(this.musics.length);
			console.log(this.musicsContainerElement.nativeElement.scrollRight);
			console.log(this.musicsContainerElement);

			if (this.musicsContainerElement.nativeElement.scrollRight < 330) {
				this.loadMusics();
			}
		} else if (container === 'artists') {
			this.artistsContainerElement.nativeElement.scrollLeft += 330;

			if (this.artistsContainerElement.nativeElement.scrollRight < 330)
				this.artistsScrollLeftElement.nativeElement.classList.remove(
					'hide'
				);
			else this.loadArtists();
		}
	};
}
