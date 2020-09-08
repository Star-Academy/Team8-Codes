import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { faSpotify } from '@fortawesome/free-brands-svg-icons';
import { faYoutube } from '@fortawesome/free-brands-svg-icons';
import { faCaretRight } from '@fortawesome/free-solid-svg-icons';
import { faCaretDown } from '@fortawesome/free-solid-svg-icons';

import { SearchService } from '../../services/search.service';
import { Music } from '../../models/Music';
import { Artist } from '../../models/Artist';

@Component({
	selector: 'app-music',
	templateUrl: './music.component.html',
	styleUrls: [ './music.component.scss' ]
})
export class MusicComponent implements OnInit {
	id: number;
	music: Music;
	primaryArtist: Artist;
	featuredArtists: Array<Artist>;

	showLyrics: boolean = false;

	faSpotify = faSpotify;
	faYoutube = faYoutube;
	faCaretRight = faCaretRight;
	faCaretDown = faCaretDown;

	constructor(
		private route: ActivatedRoute,
		private searchService: SearchService
	) {
		this.route.paramMap.subscribe((params) => {
			this.id = +params.get('id');
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

	toggleLyricsFoldingStatus(e) {
		this.showLyrics = !this.showLyrics;
	}
}
