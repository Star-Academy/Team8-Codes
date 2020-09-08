import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { faSun } from '@fortawesome/free-solid-svg-icons';
import { faMoon } from '@fortawesome/free-solid-svg-icons';

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
