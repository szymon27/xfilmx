import { Routes } from "@angular/router";
import { AccountComponent } from "./components/account/account.component";
import { CelebritiesListComponent } from "./components/celebrities-list/celebrities-list.component";
import { FilmsListComponent } from "./components/films-list/films-list.component";
import { LoginFormComponent } from "./components/login-form/login-form.component";
import { MyXfilmxComponent } from "./components/my-xfilmx/my-xfilmx.component";
import { NewsComponent } from "./components/news/news.component";
import { RegisterFormComponent } from "./components/register-form/register-form.component";
import { SeriesListComponent } from "./components/series-list/series-list.component";
import { UsersListComponent } from "./components/users-list/users-list.component";
import { AuthorizationGuard } from "./guards/authorization.guard";
import { RoleGuard } from "./guards/role.guard";

export const APP_ROUTES: Routes = [
    {path: 'login', component: LoginFormComponent},
    {path: 'register', component: RegisterFormComponent},
    {path: 'account', component: AccountComponent},
    {path: 'news', component: NewsComponent},
    {path: 'celebrities', component: CelebritiesListComponent},
    {path: 'films', component: FilmsListComponent},
    {path: 'series', component: SeriesListComponent},
    {path: 'myxfilmx', component: MyXfilmxComponent},
    {path: 'users', component: UsersListComponent},
    {path: '', redirectTo: 'login', pathMatch: 'full'}
];