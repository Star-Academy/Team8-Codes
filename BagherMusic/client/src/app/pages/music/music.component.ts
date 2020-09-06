import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { faMusic } from '@fortawesome/free-solid-svg-icons';
import { faSpotify } from '@fortawesome/free-brands-svg-icons';
import { faYoutube } from '@fortawesome/free-brands-svg-icons';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { SearchService } from 'src/app/services/search.service';
import { Music } from 'src/app/models/Music';
import { Artist } from 'src/app/models/Artist';

@Component({
	selector: 'app-music',
	templateUrl: './music.component.html',
	styleUrls: [ './music.component.scss' ]
})
export class MusicComponent implements OnInit {
	private id;
	music: Music;
	primaryArtist: Artist;
	featuredArtists: Array<Artist>;

	faSearch = faSearch;
	faMusic = faMusic;
	faSpotify = faSpotify;
	faYoutube = faYoutube;

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
		this.loadMusic();
	}

	loadMusic() {
		this.searchService.getMusic(this.id).subscribe(
			(res: Music) => {
				this.music = res;

				this.searchService
					.getArtist(this.music.primaryArtistId)
					.subscribe(
						(res: Artist) => {
							this.primaryArtist = res;
						},
						(err) => console.log(err)
					);

				this.featuredArtists = [];
				for (let id of this.music.featuredArtistIds)
					this.searchService.getArtist(id).subscribe(
						(res: Artist) => {
							this.featuredArtists.push(res);
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
}
