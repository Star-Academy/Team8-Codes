import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { SearchService } from './services/search.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LandingComponent } from './pages/landing/landing.component';
import { SearchResultsComponent } from './pages/search-results/search-results.component';
import { MusicComponent } from './pages/music/music.component';
import { ArtistComponent } from './pages/artist/artist.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { LogoComponent } from './components/logo/logo.component';
import { SearchBoxComponent } from './components/search-box/search-box.component';
import { CardArtistComponent } from './components/card-artist/card-artist.component';
import { CardMusicComponent } from './components/card-music/card-music.component';
import { CardContainerComponent } from './components/card-container/card-container.component';
import { SnackbarComponent } from './components/snackbar/snackbar.component';
import { ThemeStatusComponent } from './components/theme-status/theme-status.component';

@NgModule({
	declarations: [
		AppComponent,
		LandingComponent,
		SearchResultsComponent,
		MusicComponent,
		ArtistComponent,
		HeaderComponent,
		FooterComponent,
		LogoComponent,
		SearchBoxComponent,
		CardArtistComponent,
		CardMusicComponent,
		CardContainerComponent,
		SnackbarComponent,
		ThemeStatusComponent
	],
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
