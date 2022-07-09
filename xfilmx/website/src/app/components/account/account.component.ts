import { Component, OnInit } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { ChangePassword } from 'src/app/models/change-password';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  changePassword: ChangePassword = {
    oldPassword: "",
    newPassword: ""
  };

  imageSrc: any = null;
  file: File = null;

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    const token: string = localStorage.getItem("jwt");
    let userId: number = jwtDecode(localStorage.getItem("jwt"))['userId'];
    this.usersService.getById(userId).subscribe(res => {
      if(res.picture.length > 0)
        this.imageSrc = 'data:image/png;base64,' + res.picture;
    });
  }

  onChangePassword(): void {
    const token: string = localStorage.getItem("jwt");
    let userId: number = jwtDecode(localStorage.getItem("jwt"))['userId'];
    this.usersService.changePassword(userId, this.changePassword).subscribe(res => {
      console.log("password changed: " + res);
    })
  }

  handleNewPicture(e: any): void {
    this.file = (e.target as HTMLInputElement).files.item(0);
    if(this.file != null) {
      let reader: FileReader = new FileReader();
      reader.readAsDataURL(this.file);
      reader.onload = (event: any) => {
        this.imageSrc = reader.result;
      };      
    }
    else {
      this.imageSrc = null;
      this.file = null;
    }
  }

  onChangePicture(): void {
    const token: string = localStorage.getItem("jwt");
    let userId: number = jwtDecode(localStorage.getItem("jwt"))['userId'];

    console.log(userId);
    this.usersService.changePicture(userId, this.file).subscribe();
  }

  onDeletePicture(): void {
    const token: string = localStorage.getItem("jwt");
    let userId: number = jwtDecode(localStorage.getItem("jwt"))['userId'];
    this.usersService.deletePicture(userId).subscribe(res => {
      if(res) {
        this.imageSrc = null;
        this.file = null;
      }
    });
  }
}
