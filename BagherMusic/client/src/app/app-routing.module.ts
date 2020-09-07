import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { SearchResultsComponent } from './pages/search-results/search-results.component';
import { MusicComponent } from './pages/music/music.component';
import { ArtistComponent } from './pages/artist/artist.component';

const routes: Routes = [
	{ path: '', component: LandingComponent },
	{ path: 'search-results/:query', component: SearchResultsComponent },
	{ path: 'music/:id', component: MusicComponent },
	{ path: 'artist/:id', component: ArtistComponent }
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })
	],
	exports: [ RouterModule ]
})
export class AppRoutingModule {}
