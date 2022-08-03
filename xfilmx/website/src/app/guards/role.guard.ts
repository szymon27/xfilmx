import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import jwtDecode from 'jwt-decode';
import { iif, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  constructor(private jwtHelperService: JwtHelperService,
    private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    let access: boolean = false;
    const token = localStorage.getItem("jwt");
    if(token && !this.jwtHelperService.isTokenExpired(token)) {
      const role: string = jwtDecode(localStorage.getItem("jwt"))['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      const roles: string[] = route.data['roles'];
      roles.forEach(r => {
        if (r == role)
          access = true;
      });
      if(!access)    
        this.router.navigate(["accessdenied"]);
      return access;
    }
    else {
      this.router.navigate(["login"]);
      return false;
    }
  }
}
