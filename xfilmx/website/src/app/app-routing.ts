import { Routes } from "@angular/router";
import { LoginFormComponent } from "./components/login-form/login-form.component";
import { RegisterFormComponent } from "./components/register-form/register-form.component";
import { AuthorizationGuard } from "./guards/authorization.guard";
import { RoleGuard } from "./guards/role.guard";

export const APP_ROUTES: Routes = [
    {path: 'login', component: LoginFormComponent},
    {path: 'register', component: RegisterFormComponent, canActivate: [RoleGuard], data: {roles: ['Employee', 'Admin']}},
    {path: '', redirectTo: 'login', pathMatch: 'full'}
];