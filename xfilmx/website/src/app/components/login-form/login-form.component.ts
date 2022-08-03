import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { Authorization } from 'src/app/models/authorization';
import { AuthorizationService } from 'src/app/services/authorization.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  invalidLogin = false;
  login: string = "";
  password: string = "";

  constructor(private authorizationService: AuthorizationService, private router: Router) { }

  ngOnInit(): void {}

  signIn(form: NgForm): void {
    const authorization: Authorization = {
      login: this.login,
      password: this.password
    };
    this.authorizationService.login(authorization).subscribe(response =>{
      const token = (<any>response).token;
      localStorage.setItem("jwt", token);
      console.log(jwtDecode(localStorage.getItem("jwt")));
      this.invalidLogin = false;
      this.router.navigate(["/news"]);
    }, err => {
      this.invalidLogin = true;
    });
  }

  signUp(): void {
    this.router.navigate(["/register"]);
  }
}
