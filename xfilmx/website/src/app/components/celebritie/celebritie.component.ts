import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Celebritie } from 'src/app/models/celebritie';
import { Production } from 'src/app/models/production';
import { CelebritiesService } from 'src/app/services/celebrities.service';

@Component({
  selector: 'app-celebritie',
  templateUrl: './celebritie.component.html',
  styleUrls: ['./celebritie.component.css']
})
export class CelebritieComponent implements OnInit {
  celebritie: Celebritie = {
    id: -1,
    name: "",
    surname: "",
    dateOfBirth: null,
    placeOfBirth: "",
    picture: null    
  }
  actorIn: Production[] = [];
  directorIn: Production[] = [];
  screenwriterIn: Production[] = [];

  constructor(private celebritiesService: CelebritiesService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(p => {
      this.celebritiesService.getById(p['id']).subscribe(res => {
        this.celebritie= res;
        if(this.celebritie == null)
          this.router.navigate(['/celebrities']);

          this.celebritiesService.ActorIn(this.celebritie.id).subscribe(res=>{
            console.log(res);
            this.actorIn = res;
          })
          this.celebritiesService.DirectorIn(this.celebritie.id).subscribe(res=>{
            this.directorIn = res;
          })
          this.celebritiesService.ScreenwriterIn(this.celebritie.id).subscribe(res=>{
            this.screenwriterIn = res;
          })
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

  getProductionImage(production: Production): any{
      return 'data:image/png;base64,' + production.picture;
  }
}
