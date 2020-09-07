import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { faTwitter } from '@fortawesome/free-brands-svg-icons';
import { faInstagram } from '@fortawesome/free-brands-svg-icons';

import { SearchService } from '../../services/search.service';
import { Music } from '../../models/Music';
import { Artist } from '../../models/Artist';

@Component({
	selector: 'app-artist',
	templateUrl: './artist.component.html',
	styleUrls: [ './artist.component.scss' ]
})
export class ArtistComponent implements OnInit {
	id;
	artist: Artist;
	musics: Array<Music>;

	faTwitter = faTwitter;
	faInstagram = faInstagram;

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
