import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PostUser } from 'src/app/models/post-user';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  userAlreadyExists: boolean = false;
  user: PostUser = {
    username: "",
    password: "",
  };

  constructor(private usersService: UsersService,
    private router: Router) { }

  ngOnInit(): void {
  }

  signUp(): void {
    this.usersService.post(this.user).subscribe(res => {
        if(res != null) { 
    
          this.userAlreadyExists = false;
          this.router.navigate(['/login']);
        }
        else
          this.userAlreadyExists = true;
      });
  }

  signIn(): void {
    this.router.navigate(['/login']);
  }
}
