import { Component, OnInit, Input } from '@angular/core';
import { Artist } from 'src/app/models/Artist';

@Component({
	selector: 'app-card-artist',
	templateUrl: './card-artist.component.html',
	styleUrls: [ './card-artist.component.scss' ]
})
export class CardArtistComponent implements OnInit {
	@Input() artist: Artist;

	constructor() {}

	ngOnInit(): void {}

	mouseEnteredCard = (e) => {
		e.target.classList.add('shadow-narrow');
	};

	mouseLeftCard = (e) => {
		e.target.classList.remove('shadow-narrow');
	};
}
