import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './components/landing/landing.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { MusicComponent } from './pages/music/music.component';

const routes: Routes = [
	{ path: '', component: LandingComponent },
	{ path: 'search-results/:query', component: SearchResultsComponent },
	{ path: 'music/:id', component: MusicComponent }
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })
	],
	exports: [ RouterModule ]
})
export class AppRoutingModule {}
