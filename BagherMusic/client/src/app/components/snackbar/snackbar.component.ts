import {
	Component,
	OnInit,
	Output,
	EventEmitter,
	ViewChild,
	ElementRef
} from '@angular/core';

@Component({
	selector: 'app-snackbar',
	templateUrl: './snackbar.component.html',
	styleUrls: [ './snackbar.component.scss' ]
})
export class SnackbarComponent implements OnInit {
	@ViewChild('snackbar') snackbar: ElementRef;

	text: string = 'Snackbar!';
	duration: number = 0.0;

	constructor() {}

	ngOnInit(): void {}

	public showSnackbar(text, duration) {
		this.text = text;
		this.duration = duration - 500;
		this.snackbar.nativeElement.classList.remove('hide');

		setTimeout(() => {
			this.snackbar.nativeElement.classList.add('hide');
		}, this.duration);
	}
}
