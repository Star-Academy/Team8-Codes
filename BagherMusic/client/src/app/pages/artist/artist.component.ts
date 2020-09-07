import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { faMusic } from '@fortawesome/free-solid-svg-icons';
import { faTwitter } from '@fortawesome/free-brands-svg-icons';
import { faInstagram } from '@fortawesome/free-brands-svg-icons';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { SearchService } from '../../services/search.service';
import { Music } from '../../models/Music';
import { Artist } from '../../models/Artist';

@Component({
	selector: 'app-artist',
	templateUrl: './artist.component.html',
	styleUrls: [ './artist.component.scss' ]
})
export class ArtistComponent implements OnInit {
	private id;
	artist: Artist;
	musics: Array<Music>;

	faSearch = faSearch;
	faMusic = faMusic;
	faTwitter = faTwitter;
	faInstagram = faInstagram;

	@ViewChild('searchBox') searchBoxElement: ElementRef;
	@ViewChild('searchInput') searchInputElement: ElementRef;
	searchIconClass = 'text-fade';

	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private searchService: SearchService
	) {
		this.route.paramMap.subscribe((params) => {
			this.id = params.get('id');
			this.init();
		});
	}

	ngOnInit(): void {}

	init() {
		this.loadArtist();
	}

	loadArtist() {
		this.searchService.getArtist(this.id).subscribe(
			(res: Artist) => {
				this.artist = res;

				this.searchService.getMusicsByArtist(this.id).subscribe(
					(res: Array<Music>) => {
						this.musics = res;
					},
					(err) => console.log(err)
				);
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

		console.log(`query: ${query}`);

		if (!query) return;

		console.log('navigating ...');

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
}
