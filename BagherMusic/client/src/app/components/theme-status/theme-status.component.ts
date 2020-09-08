import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { faSun, faMoon } from '@fortawesome/free-solid-svg-icons';

@Component({
	selector: 'app-theme-status',
	templateUrl: './theme-status.component.html',
	styleUrls: [ './theme-status.component.scss' ]
})
export class ThemeStatusComponent implements OnInit {
	@Input() theme: string;

	@Output() toggleTheme = new EventEmitter();

	faSun = faSun;
	faMoon = faMoon;

	constructor() {}

	ngOnInit(): void {}

	toggleThemeStatus(e) {
		this.toggleTheme.emit();
	}
}
