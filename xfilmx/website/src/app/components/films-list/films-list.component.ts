import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Country } from 'src/app/models/country';
import { Filter } from 'src/app/models/filter';
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
  genres: Genre[] = [];
  countries: Country[] = []
  year: number = -1;
  films: MatTableDataSource<Production>;
  @ViewChild('paginator') paginator: MatPaginator;
  searchTxt: string = "";

  genresFilter: Genre[] = [];
  countriesFilter: Country[] = [];

  filterFunction() {
    let filter = (data: Production, filter: string) => {
      let nameCheck: boolean = data.title.toLowerCase().includes(this.searchTxt);
      let genreCheck: boolean = (this.genresFilter.length == 0) ? true : false;
      for(let i = 0; i < this.genresFilter.length; i++) {
        for(let j = 0; j < data.genres.length; j++) {
          if(this.genresFilter[i].name.toLowerCase() == data.genres[j].toLowerCase()) {
            genreCheck = true;
          }
        }
      }
      let countryCheck: boolean = (this.countriesFilter.length == 0) ? true : false;
      for(let i = 0; i < this.countriesFilter.length; i++) {
        for(let j = 0; j < data.countries.length; j++) {
          if(this.countriesFilter[i].name.toLowerCase() == data.countries[j].toLowerCase()) {
            countryCheck = true;
          }
        }
      }
      let yearCheck: boolean = (this.year == -1) ? true : ((this.year == new Date(data.beginDate).getFullYear()) ? true : false);
      return nameCheck && genreCheck && countryCheck && yearCheck;
    }
    return filter;
  }

  applyFilter(filter: string) {
    this.films.filter = filter;
  }

  constructor(private productionsService: ProductionsService, private router: Router, private genresService:GenresService, private countriesService:CountriesService) {
    this.productionsService.getFilms().subscribe(res => {
      this.films = new MatTableDataSource(res);
      this.films.paginator = this.paginator;
      this.films.filterPredicate = this.filterFunction();
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

  addProduction(): void {
    this.router.navigate(['/productions/add']);
  }

  onYearChange(e: any): void {
    if(e.target.value == "") this.year = -1;
    else this.year = e.target.value;
    const filterObj: Filter = {
      filter: this.searchTxt,
      countries: this.countriesFilter,
      genres: this.genresFilter,
      year: this.year
    };
    this.applyFilter(JSON.stringify(filterObj));
  }

  search(): void {
    const filterObj: Filter = {
      filter: this.searchTxt,
      countries: this.countriesFilter,
      genres: this.genresFilter,
      year: this.year
    };
    this.applyFilter(JSON.stringify(filterObj));
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
          this.countriesFilter = [];
          this.genresFilter = [];
          this.films.filterPredicate = this.filterFunction();
        })
      }
    })
  }
  
  onGenreChange(e: any):void{
    this.genresFilter = e.value;
    const filterObj: Filter = {
      filter: this.searchTxt,
      countries: this.countriesFilter,
      genres: this.genresFilter,
      year: this.year
    };
    this.applyFilter(JSON.stringify(filterObj));
  }

  onCountryChange(e: any): void{
    this.countriesFilter = e.value;
    const filterObj: Filter = {
      filter: this.searchTxt,
      countries: this.countriesFilter,
      genres: this.genresFilter,
      year: this.year
    };
    this.applyFilter(JSON.stringify(filterObj));
  }

  onSortChange(e:any):void{
    switch(e.value) {
      case 1: { //a-z
        this.films = new MatTableDataSource(this.films.data.sort((a, b) => a.title.localeCompare(b.title)));
        break;
      }
      case 2: { //z-a
        this.films = new MatTableDataSource(this.films.data.sort((a, b) => -1 * a.title.localeCompare(b.title)));
        break;
      }
      case 3: { //date asc
        this.films = new MatTableDataSource(this.films.data.sort((a, b) => new Date(a.beginDate).getTime() - new Date(b.beginDate).getTime()));
        break;
      }
      case 4: { //date desc
        this.films = new MatTableDataSource(this.films.data.sort((a, b) => -1 * (new Date(a.beginDate).getTime() - new Date(b.beginDate).getTime())));
        break;
      }
      case 5: { //most rates
        this.films = new MatTableDataSource(this.films.data.sort((a, b) => -1 * (a.rateCount - b.rateCount)));
        break;
      }
      case 6: { //best rate
        this.films = new MatTableDataSource(this.films.data.sort((a, b) => -1 * (a.rate - b.rate)));
        break;
      }
      default: {
        this.films = new MatTableDataSource(this.films.data.sort((a, b) => a.title.localeCompare(b.title)));
        break;
      }
    }
    this.films.paginator = this.paginator;
    this.films.filterPredicate = this.filterFunction();
    const filterObj: Filter = {
      filter: this.searchTxt,
      countries: this.countriesFilter,
      genres: this.genresFilter,
      year: this.year
    };
    this.applyFilter(JSON.stringify(filterObj));
  }
}
