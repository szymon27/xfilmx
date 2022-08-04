import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import jwtDecode from 'jwt-decode';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'XFILMX';
  constructor(private jwtHelper: JwtHelperService, private router: Router) {}

  isUserAuthenticated(): boolean {
    const token: string = localStorage.getItem("jwt");
    if(token && !this.jwtHelper.isTokenExpired(token))
      return true;
    return false;
  }
  
  hasRole(roles: string[]): boolean {
    const token: string = localStorage.getItem("jwt");   
    if(token && !this.jwtHelper.isTokenExpired(token)) {
      const role: string = jwtDecode(localStorage.getItem("jwt"))['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      let access: boolean = false;
      roles.forEach(r => {
        if(r == role)
          access = true;
      });
      return access;
    }
    return false;
  }

  account() {
    this.router.navigate(["account"]);
  }

  logout() {
    localStorage.removeItem("jwt");
    this.router.navigate(["login"]);
  }
}
