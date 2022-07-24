import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { throwToolbarMixedModesError } from '@angular/material/toolbar';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from 'src/app/models/country';
import { Episod } from 'src/app/models/episod';
import { Genre } from 'src/app/models/genre';
import { NewEpisod } from 'src/app/models/new-episod';
import { ProductionTrailer } from 'src/app/models/post-production-trailer';
import { ProductionCelebrities } from 'src/app/models/production-celebrities';
import { ProductionTrailerDto } from 'src/app/models/production-trailer';
import { PutProduction } from 'src/app/models/put-production';
import { Season } from 'src/app/models/season';
import { CelebritiesService } from 'src/app/services/celebrities.service';
import { CountriesService } from 'src/app/services/countries.service';
import { GenresService } from 'src/app/services/genres.service';
import { ProductionsService } from 'src/app/services/productions.service';

@Component({
  selector: 'app-production-form',
  templateUrl: './production-form.component.html',
  styleUrls: ['./production-form.component.css']
})

export class ProductionFormComponent implements OnInit {
  production: PutProduction = {
    isSerie: false,
    title: "",
    beginDate: null,
    endDate: null,
    duration: 0,
    description: ""
  }

  season: number = 1;
  episod: number = 1;
  title: string = "";

  imageSrc:any = null;
  file: File = null;
  productionId: number;
  countries: [Country, boolean][] = [];
  genres: [Genre, boolean][] = [];
  productionCelebrities: MatTableDataSource<ProductionCelebrities>;
  seasons: Season[];
  searchTxt: string;
  productionTrailers: ProductionTrailerDto[] = [];
  trailer: string;

  constructor(private productionsService: ProductionsService, private countriesService: CountriesService,
     private genresService: GenresService, private celebritiesService: CelebritiesService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(p => {
      this.productionId = p['id'];
      this.productionsService.getById(this.productionId).subscribe(res => {
        this.production = res;
        if(this.production == null)
          this.router.navigate(['/films']);
        if(res.picture.length > 0)
          this.imageSrc = 'data:image/png;base64,' + res.picture;
      });
    });

    this.countriesService.get().subscribe(res=> {
      let i=0;
      res.forEach(element => {
        this.countries[i++] = [element, false]; 
      });
    });

    this.productionsService.getCountries(this.productionId).subscribe(res =>{
      res.forEach(c =>{
        this.countries.forEach(cc =>{
          if(cc[0].countryId == c.countryId)
          cc[1] = true;
        })
      })
    })

    this.genresService.get().subscribe(res=> {
      let i=0;
      res.forEach(element => {
        this.genres[i++] = [element, false];        
      });
    });

    this.productionsService.getGenres(this.productionId).subscribe(res =>{
      res.forEach(g =>{
        this.genres.forEach(gg =>{
          if(gg[0].genreId == g.genreId)
          gg[1] = true;
        })
      })
    });

    this.productionsService.getCelebrities(this.productionId).subscribe(res => {
      this.productionCelebrities = new MatTableDataSource(res);
    });

    this.productionsService.getSeasons(this.productionId).subscribe(res => {
      this.seasons = res;
      console.log(res);
    });

    this.productionsService.getTrailers(this.productionId).subscribe(res => {
      console.log(res)
      this.productionTrailers = res;
    })
  }

  ngOnInit(): void {
    
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

  addSeason(): void {
    const newEpisod: NewEpisod = {
      season: this.season,
      episod: this.episod,
      title: this.title,
    };
    this.productionsService.addEpisod(this.productionId, newEpisod).subscribe(res => {
      if (res) {        
        this.seasons.push({
          seasonId: this.season,
           episods: [
            {
              episodId: this.episod,
              title: this.title
            }
           ]
        });
      }
      else{
        alert("season exist");
      }
    });
  }

  deleteEpisod(season:number, episod:number): void {
    this.productionsService.deleteEpisod(this.productionId, season, episod).subscribe(res =>{
      if(res) {
        this.seasons.forEach(s => {
          if(s.seasonId == season) {
            const arr:Episod[] = s.episods.filter((element) => {
              return element.episodId != episod;
            });
            s.episods = arr;
          }
        });
      }
      else {
        alert("cannot delete episod");
      }
    });
  }

  addEpisod(season: number, episod: any, title: any): void {
    const newEpisod: NewEpisod = {
      season: season,
      episod: parseInt((episod as HTMLInputElement).value),
      title: (title as HTMLInputElement).value
    };
    this.productionsService.addEpisod(this.productionId, newEpisod).subscribe(res => {
      if (res) {        
        let s: Season = null;
        this.seasons.forEach(x => {
          if (x.seasonId == season) {
            x.episods.push({
              episodId: newEpisod.episod,
              title: newEpisod.title
            });
          } 
        });

      }
      else{
        alert("episod exist");
      }
    });
  }

  deleteSeason(seasonId): void {
    this.productionsService.deleteSeason(this.productionId, seasonId).subscribe(res =>{
      if(res) {
        const arr: Season[] = this.seasons.filter((element) => {
          return element.seasonId != seasonId;
        });
        this.seasons = arr;
      }
      else {
        alert("cannot delete season");
      }
    });
  }

  editProduction(): void {
    this.productionsService.put(this.productionId, this.production).subscribe();
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
    this.productionsService.changePicture(this.productionId, this.file).subscribe();
  }

  onDeletePicture(): void {
    this.productionsService.deletePicture(this.productionId).subscribe(res => {
      if(res) {
        this.imageSrc = null;
        this.file = null;
      }
    });
  }

  cancel(): void {
    if(this.production == null || !this.production.isSerie)
    this.router.navigate(['/films'])
    else
    this.router.navigate(['/series'])
  }

  changeCountry(countryId : number, e:any):void{
    if(e)
    this.productionsService.addCountry(this.productionId, countryId).subscribe()
    else
    this.productionsService.deleteCountry(this.productionId, countryId).subscribe()
  }

  changeGanre(genreId : number, e:any):void{
    if(e)
    this.productionsService.addGenre(this.productionId, genreId).subscribe()
    else
    this.productionsService.deleteGenre(this.productionId, genreId).subscribe()
  }

  changeScreenwriter(celebritieId : number, e:any):void{
    if(e.checked)
    this.productionsService.addScreenwriter(this.productionId, celebritieId).subscribe()
    else
    this.productionsService.deleteScreenwriter(this.productionId, celebritieId).subscribe()
  }

  changeDirector(celebritieId : number, e:any):void{
    if(e.checked)
    this.productionsService.addDirector(this.productionId, celebritieId).subscribe()
    else
    this.productionsService.deleteDirector(this.productionId, celebritieId).subscribe()
  }

  changeActor(celebritieId : number, character: string, e:any):void{
    console.log(character);
    if(e.checked)
    this.productionsService.addActor(this.productionId, celebritieId, character).subscribe()
    else
    this.productionsService.deleteActor(this.productionId, celebritieId).subscribe()
  }

  deleteTrailer(trailerId: number): void{
    console.log(trailerId);
    this.productionsService.deleteTrailer(trailerId).subscribe(res =>{
      if(res) {
        const arr: ProductionTrailerDto[] = this.productionTrailers.filter((element) => {
          return element.id != trailerId;
        });
        console.log(arr)
        this.productionTrailers = arr;
      }
      else {
        alert("cannot delete trailer");
      }
    });
  }

  addTrailer(): void{    
      this.productionsService.addTrailer(this.productionId, this.trailer).subscribe(res =>{
        if(res != null){
          console.log(res)
        this.productionTrailers.push({id: res.productionTrailerId, link: res.link})
        console.log(this.productionTrailers)
        }
        else
        alert("cannot add trailer")
      })
  }

}
