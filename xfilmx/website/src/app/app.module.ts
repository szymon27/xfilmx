import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { APP_ROUTES } from './app-routing';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { JwtModule } from '@auth0/angular-jwt';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { NewsComponent } from './components/news/news.component';
import { MyXfilmxComponent } from './components/my-xfilmx/my-xfilmx.component';
import { AccountComponent } from './components/account/account.component';
import { NewsListComponent } from './components/news-list/news-list.component';
import { FilmsListComponent } from './components/films-list/films-list.component';
import { SeriesListComponent } from './components/series-list/series-list.component';
import { FilmComponent } from './components/film/film.component';
import { CelebritiesListComponent } from './components/celebrities-list/celebrities-list.component';
import { CelebritieComponent } from './components/celebritie/celebritie.component';
import { SeriesComponent } from './components/series/series.component';
import { UsersListComponent } from './components/users-list/users-list.component';
import { MatRadioModule } from '@angular/material/radio';
import { GenresListComponent } from './components/genres-list/genres-list.component';
import { CountriesListComponent } from './components/countries-list/countries-list.component';
import { NewGenreFormComponent } from './components/new-genre-form/new-genre-form.component';
import { GenreFormComponent } from './components/genre-form/genre-form.component';
import { CountryFormComponent } from './components/country-form/country-form.component';
import { NewCountryFormComponent } from './components/new-country-form/new-country-form.component';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    RegisterFormComponent,
    NewsComponent,
    MyXfilmxComponent,
    AccountComponent,
    NewsListComponent,
    FilmsListComponent,
    SeriesListComponent,
    FilmComponent,
    CelebritiesListComponent,
    CelebritieComponent,
    SeriesComponent,
    UsersListComponent,
    GenresListComponent,
    CountriesListComponent,
    NewGenreFormComponent,
    GenreFormComponent,
    CountryFormComponent,
    NewCountryFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(APP_ROUTES),
    BrowserAnimationsModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:1234"]
      }
    }),
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatIconModule,
    MatRadioModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }