import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { PostCelebritie } from 'src/app/models/post-celebritie';
import { CelebritiesService } from 'src/app/services/celebrities.service';

@Component({
  selector: 'app-new-celebritie-form',
  templateUrl: './new-celebritie-form.component.html',
  styleUrls: ['./new-celebritie-form.component.css']
})
export class NewCelebritieFormComponent implements OnInit {
  celebritie: PostCelebritie = {
    name: "",
    surname: "",
    dateOfBirth: null,
    placeOfBirth: ""
  }

  constructor(private celebritiesService: CelebritiesService, private router: Router) {
   }

  ngOnInit(): void {
  }
  cancel(): void{
    this.router.navigate(['/celebrities'])
  }
  createCelebritie():void{
    this.celebritiesService.post(this.celebritie).subscribe(res=>{
      this.router.navigate(['/celebrities'])
    })
  }
}
