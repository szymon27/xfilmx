import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from 'src/app/models/country';
import { Genre } from 'src/app/models/genre';
import { ProductionCelebrities } from 'src/app/models/production-celebrities';
import { PutProduction } from 'src/app/models/put-production';
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

  imageSrc:any = null;
  file: File = null;
  productionId: number;
  countries: [Country, boolean][] = [];
  genres: [Genre, boolean][] = [];
  productionCelebrities: MatTableDataSource<ProductionCelebrities>;
  searchTxt: string;

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
    })
  }

  ngOnInit(): void {
    
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
}
