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
  selector: 'app-series-list',
  templateUrl: './series-list.component.html',
  styleUrls: ['./series-list.component.css']
})
export class SeriesListComponent implements OnInit {
  series: MatTableDataSource<Production>;
  genres: Genre[] = [];
  countries: Country[] = []
  @ViewChild('paginator') paginator: MatPaginator;
  searchTxt: string = "";
  year: number = -1;
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
    this.series.filter = filter;
  }

  constructor(private productionsService: ProductionsService, private router: Router, private genresService:GenresService, private countriesService:CountriesService) {
    this.productionsService.getSeries().subscribe(res => {
      this.series = new MatTableDataSource(res);
      this.series.paginator = this.paginator;
      this.series.filterPredicate = this.filterFunction();

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

  addProduction(): void {
    this.router.navigate(['/productions/add']);
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

  showSeries(productionId: number): void{
    this.router.navigate(['productions/' + productionId])
  }
  editSeries(productionId:number): void{
    this.router.navigate(['productions/' + productionId + '/edit'])
  }
  deleteSeries(productionId:number): void{
    this.productionsService.delete(productionId).subscribe(res =>{
      if(res){
        this.productionsService.getSeries().subscribe(r => {
          this.series = new MatTableDataSource(r);
          this.series.paginator = this.paginator;
          this.searchTxt = "";
          this.countriesFilter = [];
          this.genresFilter = [];
          this.series.filterPredicate = this.filterFunction();
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
        this.series = new MatTableDataSource(this.series.data.sort((a, b) => a.title.localeCompare(b.title)));
        break;
      }
      case 2: { //z-a
        this.series = new MatTableDataSource(this.series.data.sort((a, b) => -1 * a.title.localeCompare(b.title)));
        break;
      }
      case 3: { //date asc
        this.series = new MatTableDataSource(this.series.data.sort((a, b) => new Date(a.beginDate).getTime() - new Date(b.beginDate).getTime()));
        break;
      }
      case 4: { //date desc
        this.series = new MatTableDataSource(this.series.data.sort((a, b) => -1 * (new Date(a.beginDate).getTime() - new Date(b.beginDate).getTime())));
        break;
      }
      case 5: { //most rates
        this.series = new MatTableDataSource(this.series.data.sort((a, b) => -1 * (a.rateCount - b.rateCount)));
        break;
      }
      case 6: { //best rate
        this.series = new MatTableDataSource(this.series.data.sort((a, b) => -1 * (a.rate - b.rate)));
        break;
      }
      default: {
        this.series = new MatTableDataSource(this.series.data.sort((a, b) => a.title.localeCompare(b.title)));
        break;
      }
    }
    this.series.paginator = this.paginator;
    this.series.filterPredicate = this.filterFunction();
    const filterObj: Filter = {
      filter: this.searchTxt,
      countries: this.countriesFilter,
      genres: this.genresFilter,
      year: this.year
    };
    this.applyFilter(JSON.stringify(filterObj));
  }
}
