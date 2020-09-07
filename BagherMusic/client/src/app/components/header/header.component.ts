import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: [ './header.component.scss' ],
	host: { class: 'shadow-narrow' }
})
export class HeaderComponent implements OnInit {
	constructor() {}

	ngOnInit(): void {}
}
