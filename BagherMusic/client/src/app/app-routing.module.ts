import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from './components/landing/landing.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';

const routes: Routes = [
	{ path: '', component: LandingComponent },
	{ path: 'search-results', component: SearchResultsComponent }
];

@NgModule({
	imports: [ RouterModule.forRoot(routes) ],
	exports: [ RouterModule ]
})
export class AppRoutingModule {}
