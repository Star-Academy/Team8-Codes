import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { SearchService } from './services/search.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LandingComponent } from './components/landing/landing.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';

@NgModule({
	declarations: [ AppComponent, LandingComponent, SearchResultsComponent ],
	imports: [
		BrowserModule,
		AppRoutingModule,
		BrowserAnimationsModule,
		HttpClientModule,
		FontAwesomeModule
	],
	providers: [ SearchService ],
	bootstrap: [ AppComponent ]
})
export class AppModule {}
