import { Component, HostListener } from '@angular/core';

import { faChevronUp } from '@fortawesome/free-solid-svg-icons';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: [ './app.component.scss' ]
})
export class AppComponent {
	showScroll: boolean = false;

	faChevronUp = faChevronUp;

	constructor() {
		// window.addEventListener('scroll', this.checkScrollTop);
	}

	@HostListener('window:scroll', [ '$event' ])
	checkScrollTop(e) {
		if (window.pageYOffset > 400) {
			this.showScroll = true;
		} else {
			this.showScroll = false;
		}
	}

	scrollTop(e) {
		window.scrollTo({ top: 0, behavior: 'smooth' });
	}
}
