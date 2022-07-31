import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Country } from 'src/app/models/country';
import { Genre } from 'src/app/models/genre';
import { Production } from 'src/app/models/production';
import { CountriesService } from 'src/app/services/countries.service';
import { GenresService } from 'src/app/services/genres.service';
import { ProductionsService } from 'src/app/services/productions.service';

@Component({
  selector: 'app-films-list',
  templateUrl: './films-list.component.html',
  styleUrls: ['./films-list.component.css']
})
export class FilmsListComponent implements OnInit {
  seriesFromApi: Production[];
  seriesToTable: Production[];
  series: MatTableDataSource<Production>;
  genres: Genre[] = [];
  countries: Country[] = []

  filterGenres: Genre[] = []
  filterCountries: Country[] = []

  beginDate: Date = null;

  films: MatTableDataSource<Production>;
  @ViewChild('paginator') paginator: MatPaginator;
  searchTxt: string = "";

  constructor(private productionsService: ProductionsService, private router: Router, private genresService:GenresService, private countriesService:CountriesService) {
    this.productionsService.getFilms().subscribe(res => {
      this.films = new MatTableDataSource(res);
      this.films.paginator = this.paginator;
      this.films.filterPredicate = (data: Production, filter: string) => {
        return data.title.includes(filter);
      }
      this.genresService.get().subscribe(res=>{
        this.genres = res;
      })

      this.countriesService.get().subscribe(res=>{
        this.countries = res;
      })
    });
  }

  ngOnInit(): void {
  }

  filterChange(): void{
    
  }
  addProduction(): void {
    this.router.navigate(['/productions/add']);
  }

  search(e: any): void {
    this.films.filter = (e as HTMLInputElement).value.toLowerCase();
  }

  getImageSrc(production: Production): any {
    if(production.picture != null)
      return 'data:image/png;base64,' + production.picture;
    return null;
  }

  showFilm(productionId: number): void{
    this.router.navigate(['productions/' + productionId])
  }
  editFilm(productionId:number): void{
    this.router.navigate(['productions/' + productionId + '/edit'])
  }
  deleteFilm(productionId:number): void{
    this.productionsService.delete(productionId).subscribe(res =>{
      if(res){
        this.productionsService.getFilms().subscribe(r => {
          this.films = new MatTableDataSource(r);
          this.films.paginator = this.paginator;
          this.searchTxt = "";
          this.films.filterPredicate = (data: Production, filter: string) => {
            return data.title.includes(filter);
          }
        })
      }
    })
  }
  
  onGenreChange(e: any):void{
    this.filterGenres = e.value
    this.filterChange()
  }

  onCountryChange(e: any): void{
    this.filterCountries = e.value
    this.filterChange()
  }

  onSortChange(e:any):void{
    switch(e.value){
      
    }
  }
}
