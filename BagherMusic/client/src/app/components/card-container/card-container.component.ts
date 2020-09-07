import { Component, OnInit, Input } from '@angular/core';

@Component({
	selector: 'app-card-container',
	templateUrl: './card-container.component.html',
	styleUrls: [ './card-container.component.scss' ]
})
export class CardContainerComponent implements OnInit {
	@Input() label: string;
	@Input() height: string;
	@Input() onEndAction: CallableFunction;

	constructor() {
		// this.onEndAction();
	}

	ngOnInit(): void {}

	// scrollLeft = (e, container) => {
	// 	if (container === 'musics') {
	// 		this.musicsContainerElement.nativeElement.scrollLeft -= 330;

	// 		if (this.musicsContainerElement.nativeElement.scrollLeft <= 0)
	// 			this.musicsScrollLeftElement.nativeElement.classList.add(
	// 				'hide'
	// 			);
	// 	} else if (container === 'artists') {
	// 		this.artistsContainerElement.nativeElement.scrollLeft -= 330;

	// 		if (this.artistsContainerElement.nativeElement.scrollLeft <= 0)
	// 			this.artistsScrollLeftElement.nativeElement.classList.add(
	// 				'hide'
	// 			);
	// 	}
	// };

	// scrollRight = (e, container) => {
	// 	if (container === 'musics') {
	// 		this.musicsContainerElement.nativeElement.scrollLeft += 330;
	// 		this.musicsScrollLeftElement.nativeElement.classList.remove('hide');

	// 		console.log(this.musics.length);
	// 		console.log(this.musicsContainerElement.nativeElement.scrollRight);
	// 		console.log(this.musicsContainerElement);

	// 		if (this.musicsContainerElement.nativeElement.scrollRight < 330) {
	// 			this.loadMusics();
	// 		}
	// 	} else if (container === 'artists') {
	// 		this.artistsContainerElement.nativeElement.scrollLeft += 330;

	// 		if (this.artistsContainerElement.nativeElement.scrollRight < 330)
	// 			this.artistsScrollLeftElement.nativeElement.classList.remove(
	// 				'hide'
	// 			);
	// 		else this.loadArtists();
	// 	}
	// };
}
