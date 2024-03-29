import { Routes } from "@angular/router";
import { CelebritieFormComponent } from "./components/celebritie-form/celebritie-form.component";
import { AccountComponent } from "./components/account/account.component";
import { CelebritieComponent } from "./components/celebritie/celebritie.component";
import { CelebritiesListComponent } from "./components/celebrities-list/celebrities-list.component";
import { CountriesListComponent } from "./components/countries-list/countries-list.component";
import { CountryFormComponent } from "./components/country-form/country-form.component";
import { FilmsListComponent } from "./components/films-list/films-list.component";
import { GenreFormComponent } from "./components/genre-form/genre-form.component";
import { GenresListComponent } from "./components/genres-list/genres-list.component";
import { LoginFormComponent } from "./components/login-form/login-form.component";
import { MyXfilmxComponent } from "./components/my-xfilmx/my-xfilmx.component";
import { NewCelebritieFormComponent } from "./components/new-celebritie-form/new-celebritie-form.component";
import { NewCountryFormComponent } from "./components/new-country-form/new-country-form.component";
import { NewGenreFormComponent } from "./components/new-genre-form/new-genre-form.component";
import { NewNewsFormComponent } from "./components/new-news-form/new-news-form.component";
import { NewsFormComponent } from "./components/news-form/news-form.component";
import { NewsListComponent } from "./components/news-list/news-list.component";
import { NewsComponent } from "./components/news/news.component";
import { RegisterFormComponent } from "./components/register-form/register-form.component";
import { SeriesListComponent } from "./components/series-list/series-list.component";
import { UsersListComponent } from "./components/users-list/users-list.component";
import { AuthorizationGuard } from "./guards/authorization.guard";
import { RoleGuard } from "./guards/role.guard";
import { NewProductionFormComponent } from "./components/new-production-form/new-production-form.component";
import { ProductionFormComponent } from "./components/production-form/production-form.component";
import { ProductionComponent } from "./components/production/production.component";
import { AccessDeniedComponent } from "./components/access-denied/access-denied.component";

export const APP_ROUTES: Routes = [
    {path: 'accessdenied', component: AccessDeniedComponent},
    {path: 'login', component: LoginFormComponent},
    {path: 'register', component: RegisterFormComponent},
    {path: 'account', component: AccountComponent, canActivate: [AuthorizationGuard]},
    {path: 'news', component: NewsListComponent},
    {path: 'news/add', component: NewNewsFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: 'news/:id', component: NewsComponent},
    {path: 'news/:id/edit', component: NewsFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: 'celebrities', component: CelebritiesListComponent},
    {path: 'celebrities/add', component: NewCelebritieFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: 'celebrities/:id', component: CelebritieComponent},
    {path: 'celebrities/:id/edit', component: CelebritieFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: 'productions/add', component: NewProductionFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: 'productions/:id/edit', component: ProductionFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: 'films', component: FilmsListComponent},
    {path: 'productions/:id', component: ProductionComponent},
    {path: 'series', component: SeriesListComponent},
    {path: 'myxfilmx', component: MyXfilmxComponent, canActivate: [AuthorizationGuard]},
    {path: 'users', component: UsersListComponent, canActivate: [RoleGuard], data: {roles: ['Admin']}},
    {path: 'countries', component: CountriesListComponent},
    {path: 'countries/add', component: NewCountryFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: 'countries/:id', component: CountryFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: 'genres', component: GenresListComponent},
    {path: 'genres/add', component: NewGenreFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: 'genres/:id', component: GenreFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: '', redirectTo: 'news', pathMatch: 'full'}
];