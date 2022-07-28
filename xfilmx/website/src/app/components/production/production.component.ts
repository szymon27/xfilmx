import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Celebritie } from 'src/app/models/celebritie';
import { Production } from 'src/app/models/production';
import { ProductionsService } from 'src/app/services/productions.service';

@Component({
  selector: 'app-production',
  templateUrl: './production.component.html',
  styleUrls: ['./production.component.css']
})
export class ProductionComponent implements OnInit {
  production: Production = {
    isSerie: false,
    productionId: -1,
    title: "",
    description: "",
    beginDate: null,
    endDate: null,
    duration: -1,
    picture: "",
    countries: null,
    genres: null,
    rate: -1,
    rateCount: -1
  }
  actors: [Celebritie,string][] = []
  directors: Celebritie [] = []
  screenwriters: Celebritie[] = []


  constructor(private productionsService: ProductionsService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(p =>{
      this.productionsService.getById(p['id']).subscribe(res =>{
        this.production = res;
        if(this.production == null)
        this.router.navigate(['/productions']);

        this.productionsService.getActors(this.production.productionId).subscribe(res => {    
          this.actors = res;
        })

        this.productionsService.getDirectors(this.production.productionId).subscribe(res => {
          this.directors = res;
        })

        this.productionsService.getScreenwriters(this.production.productionId).subscribe(res => {
          this.screenwriters = res;
        })
      })
    })
  }

  getProductionImage(): any{
    if(this.production.picture != null)
    return 'data:image/png;base64,' + this.production.picture;
    return null;
  }

  getCelebritieImage(celebritie: Celebritie): any{
    if(celebritie.picture != null)
      return 'data:image/png;base64,' + celebritie.picture;
    return null;
  }

  getRoleCelebritie(c: [Celebritie, string]):any{
    return c["item1"].name + " " + c["item1"].surname;
  }

  getRoleId(c: [Celebritie, string]):any{
    return c["item1"].id;
  }
  getRoleName(c: [Celebritie, string]):any{
    return c["item2"];
  }
  getRoleImage(c: [Celebritie, string]):any{
    if(c["item1"].picture != null)
      return 'data:image/png;base64,' + c["item1"].picture;
    return null;
  }
}
