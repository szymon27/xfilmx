import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PutCelebritie } from 'src/app/models/put-celebritie';
import { CelebritiesService } from 'src/app/services/celebrities.service';

@Component({
  selector: 'app-celebritie-form',
  templateUrl: './celebritie-form.component.html',
  styleUrls: ['./celebritie-form.component.css']
})
export class CelebritieFormComponent implements OnInit {
  celebritie: PutCelebritie = {
    name: "",
    surname: "",
    dateOfBirth: null,
    placeOfBirth: ""
  }
  imageSrc:any = null;
  file: File = null;
  celebritieId: number;

  constructor(private celebritiesService: CelebritiesService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(p => {
      this.celebritieId = p['id'];
      this.celebritiesService.getById(this.celebritieId).subscribe(res => {
        this.celebritie= res;
        if(this.celebritie == null)
          this.router.navigate(['/news']);
        if(res.picture.length > 0)
          this.imageSrc = 'data:image/png;base64,' + res.picture;
      });
    });
   }
  ngOnInit(): void { }

  editCelebritie(): void {
    this.celebritiesService.put(this.celebritieId, this.celebritie).subscribe();
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
    this.celebritiesService.changePicture(this.celebritieId, this.file).subscribe();
  }

  onDeletePicture(): void {
    this.celebritiesService.deletePicture(this.celebritieId).subscribe(res => {
      if(res) {
        this.imageSrc = null;
        this.file = null;
      }
    });
  }
  parseDate(dateString: any): Date {
    if (dateString) {
        return new Date(dateString);
    }
    return null;
  }
}
