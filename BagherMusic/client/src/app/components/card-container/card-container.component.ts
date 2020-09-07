import {
	Component,
	OnInit,
	Input,
	Output,
	EventEmitter,
	ViewChild,
	ElementRef,
	AfterViewInit
} from '@angular/core';

@Component({
	selector: 'app-card-container',
	templateUrl: './card-container.component.html',
	styleUrls: [ './card-container.component.scss' ]
})
export class CardContainerComponent implements OnInit, AfterViewInit {
	@Input() label: string;
	@Input() height: string;

	@Output() getCards = new EventEmitter();
	@Output() scrolledToEnd = new EventEmitter();

	@ViewChild('cards') cardsElement: ElementRef;

	constructor() {}

	ngOnInit(): void {}

	ngAfterViewInit(): void {
		this.getCards.emit({ cards: this.cardsElement.nativeElement });
	}

	scrollHandler(e: Event) {
		const element = e.target as Element;

		if (element.scrollWidth - element.scrollLeft === element.clientWidth)
			this.scrolledToEnd.emit();
	}
}
