import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Artist } from 'src/app/models/Artist';

@Component({
	selector: 'app-card-artist',
	templateUrl: './card-artist.component.html',
	styleUrls: [ './card-artist.component.scss' ]
})
export class CardArtistComponent implements OnInit {
	@Input() artist: Artist;

	constructor(private router: Router) {}

	ngOnInit(): void {}

	clickedOnCard = (e) => {
		this.router.navigate([ 'artist', this.artist.id ]);
	};
}
