import { Injectable } from '@angular/core';
import { CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';;

@Injectable({
  providedIn: 'root'
})
export class AuthorizationGuard implements CanActivate {
  constructor(private jwtHelperService: JwtHelperService,
    private router: Router) {}

  canActivate(): boolean {
    const token = localStorage.getItem("jwt");
    if(token && !this.jwtHelperService.isTokenExpired(token))
      return true;
    this.router.navigate(["login"]);
    return false;
  }
  
}
