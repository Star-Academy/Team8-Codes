import { Component, OnInit } from '@angular/core';

import { faSearch } from '@fortawesome/free-solid-svg-icons';

@Component({
	selector: 'app-landing',
	templateUrl: './landing.component.html',
	styleUrls: [ './landing.component.scss' ]
})
export class LandingComponent implements OnInit {
	faSearch = faSearch;

	constructor() {}

	ngOnInit(): void {}

	search(e) {
		console.log('Search ... ');
	}
}
