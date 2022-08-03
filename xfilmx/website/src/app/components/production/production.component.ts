import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { Gallery, GalleryItem, ImageItem } from 'ng-gallery';
import { NgxStarsComponent } from 'ngx-stars';
import { Celebritie } from 'src/app/models/celebritie';
import { Comment } from 'src/app/models/comment';
import { Episod } from 'src/app/models/episod';
import { Production } from 'src/app/models/production';
import { ProductionPictureDto } from 'src/app/models/production-picture';
import { Season } from 'src/app/models/season';
import { ProductionsService } from 'src/app/services/productions.service';

@Component({
  selector: 'app-production',
  templateUrl: './production.component.html',
  styleUrls: ['./production.component.css']
})
export class ProductionComponent implements OnInit {

  @ViewChild(NgxStarsComponent)
  starsComponent: NgxStarsComponent;

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
  seasons: Season[] = []
  comments: Comment[] = []
  comment: string;
  photos: ProductionPictureDto[];
  items: GalleryItem[] = []
  status: number;

  galleryId = 'myLightbox'

  constructor(private productionsService: ProductionsService, private router: Router, private activatedRoute: ActivatedRoute, public gallery: Gallery) { }

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

        this.productionsService.getSeasons(this.production.productionId).subscribe(res => {
          this.seasons = res;
        })

        this.productionsService.getComments(this.production.productionId).subscribe(res => {
          this.comments = res;
        })

        this.productionsService.getGallery(this.production.productionId).subscribe(res => {
          this.photos = res
          this.items = this.photos.map(item => {
            return new ImageItem({
              src: 'data:image/png;base64,' + item.picture,              
            });
          });
          const galleryRef = this.gallery.ref(this.galleryId);
          galleryRef.load(this.items);
        })

        this.productionsService.GetProductionStatus(this.production.productionId, jwtDecode(localStorage.getItem("jwt"))['userId']).subscribe(res=>{
          this.status = res;
        })

        this.productionsService.getRate(this.production.productionId, jwtDecode(localStorage.getItem("jwt"))['userId']).subscribe(res=>{
          if(res != null){
            console.log(jwtDecode(localStorage.getItem("jwt"))['userId'])
          this.starsComponent.setRating(res);
          }
          else
          this.starsComponent.setRating(0);
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

  rate(rating: number): void{
    this.productionsService.addRate(this.production.productionId, jwtDecode(localStorage.getItem("jwt"))['userId'], rating).subscribe(res =>{
      if(res == null){
        this.starsComponent.setRating(0);
      }
      else
      this.status = 1;  
    })
  }

  removeRate():void{
    this.productionsService.deleteRate(this.production.productionId, jwtDecode(localStorage.getItem("jwt"))['userId']).subscribe(res=>{
      if(res)
      this.starsComponent.setRating(0);
    })
  }

  SortedSeasonArray(arr: Season[]): Season[] {
    if(arr == null)
      return new Array();
    return arr.sort((a, b) => a.seasonId - b.seasonId);
  }

  SortedEpisodArray(arr: Episod[]): Episod[] {
    if(arr == null)
      return new Array();
    return arr.sort((a, b) => a.episodId - b.episodId);
  }

  addComment(): void{
    this.productionsService.addComment(this.production.productionId, jwtDecode(localStorage.getItem("jwt"))['userId'], this.comment).subscribe(res => {
      if(res != null){
      this.comments.push(res);
      this.comment = "";
      }
    })
  }

  deleteComment(commentId: number): void{
    this.productionsService.deleteComment(commentId).subscribe(res =>{
      if(res)
      this.productionsService.getComments(this.production.productionId).subscribe(res => {
        this.comments = res;
      })
    })
  }

  getGalleryImg(url: string):any{
    return 'data:image/png;base64,' + url;
  }

  onStatusChange(e: number): void{
    console.log(e)
    this.productionsService.addProductionToWatch(this.production.productionId, jwtDecode(localStorage.getItem("jwt"))['userId'], e).subscribe(res => {
      if(res){
      if(e == 0 || e == 2)
        this.starsComponent.setRating(0);
    }
    })
  }
}
