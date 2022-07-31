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
  selector: 'app-series-list',
  templateUrl: './series-list.component.html',
  styleUrls: ['./series-list.component.css']
})
export class SeriesListComponent implements OnInit {

  seriesFromApi: Production[];
  seriesToTable: Production[];
  series: MatTableDataSource<Production>;
  genres: Genre[] = [];
  countries: Country[] = []

  filterGenres: Genre[] = []
  filterCountries: Country[] = []

  beginDate: Date = null;

  @ViewChild('paginator') paginator: MatPaginator;
  searchTxt: string = "";

  constructor(private productionsService: ProductionsService, private router: Router, private genresService:GenresService, private countriesService:CountriesService) {
    this.productionsService.getSeries().subscribe(res => {
      this.seriesFromApi = res;
      this.series = new MatTableDataSource(this.seriesFromApi);
      this.series.paginator = this.paginator;
      this.series.filterPredicate = (data: Production, filter: string) => {
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
    this.series.filter = (e as HTMLInputElement).value.toLowerCase();
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
          this.series.filterPredicate = (data: Production, filter: string) => {
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
