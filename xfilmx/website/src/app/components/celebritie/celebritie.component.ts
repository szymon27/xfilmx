import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Celebritie } from 'src/app/models/celebritie';
import { CelebritiesService } from 'src/app/services/celebrities.service';

@Component({
  selector: 'app-celebritie',
  templateUrl: './celebritie.component.html',
  styleUrls: ['./celebritie.component.css']
})
export class CelebritieComponent implements OnInit {
  celebritie: Celebritie = {
    celebritieId: -1,
    name: "",
    surname: "",
    dateOfBirth: null,
    placeOfBirth: "",
    picture: null    
  }
  constructor(private celebritiesService: CelebritiesService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(p => {
      this.celebritiesService.getById(p['id']).subscribe(res => {
        this.celebritie= res;
        if(this.celebritie == null)
          this.router.navigate(['/news']);
      });
    });
  }

  ngOnInit(): void {
  }

  getImageSrc(): any {
    if(this.celebritie.picture != null)
      return 'data:image/png;base64,' + this.celebritie.picture;
    return null;
  }
}
