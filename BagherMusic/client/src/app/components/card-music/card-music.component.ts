import { Component, OnInit, Input } from '@angular/core';
import { Music } from 'src/app/models/Music';

@Component({
	selector: 'app-card-music',
	templateUrl: './card-music.component.html',
	styleUrls: [ './card-music.component.scss' ]
})
export class CardMusicComponent implements OnInit {
	@Input() music: Music;

	constructor() {}

	ngOnInit(): void {}

	mouseEnteredCard = (e) => {
		e.target.childNodes[0].classList.add('active');
	};

	mouseLeftCard = (e) => {
		e.target.childNodes[0].classList.remove('active');
	};
}
