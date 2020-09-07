import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { Router } from '@angular/router';

import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { faMusic } from '@fortawesome/free-solid-svg-icons';

@Component({
	selector: 'app-search-box',
	templateUrl: './search-box.component.html',
	styleUrls: [ './search-box.component.scss' ]
})
export class SearchBoxComponent implements OnInit {
	@Input() width;
	@Input() height;

	@ViewChild('searchBox') searchBoxElement: ElementRef;
	@ViewChild('searchInput') searchInputElement: ElementRef;
	searchIconClass = 'text-fade';

	faSearch = faSearch;
	faMusic = faMusic;

	constructor(private router: Router) {}

	ngOnInit(): void {}

	focusedOnInput(e) {
		this.searchBoxElement.nativeElement.classList.add('shadow-gentle');
		this.searchBoxElement.nativeElement.classList.remove('border-thin');
		this.searchIconClass = 'text-bright';
	}

	blurredInput(e) {
		this.searchBoxElement.nativeElement.classList.remove('shadow-gentle');
		this.searchBoxElement.nativeElement.classList.add('border-thin');

		if (!this.searchInputElement.nativeElement.value)
			this.searchIconClass = 'text-fade';
	}

	searchListener(e) {
		e.preventDefault();

		const query = this.searchInputElement.nativeElement.value;

		if (!query) return;

		this.searchInputElement.nativeElement.value = '';
		this.searchInputElement.nativeElement.blur();

		this.router.navigate([ 'search-results', query ]);
	}
}
