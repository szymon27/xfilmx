import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatInput } from '@angular/material/input';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Country } from 'src/app/models/country';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-countries-list',
  templateUrl: './countries-list.component.html',
  styleUrls: ['./countries-list.component.css']
})
export class CountriesListComponent implements OnInit {
  countries: MatTableDataSource<Country>;
  @ViewChild('paginator') paginator: MatPaginator;
  searchTxt: string = "";

  constructor(private countriesService: CountriesService, private router: Router) {
    this.countriesService.get().subscribe(res => {
      this.countries = new MatTableDataSource(res);
      this.countries.paginator = this.paginator;
      this.countries.filterPredicate = (data: Country, filter: string) => {
        return data.name.includes(filter);
      }
    });
  }

  ngOnInit(): void {
  }

  addCountry(): void {
    this.router.navigate(['countries/add']);
  }

  editCountry(countryId: number): void {
    this.router.navigate(['countries/' + countryId]);
  }

  deleteCountry(countryId: number): void {
    this.countriesService.delete(countryId).subscribe(res => {
      if(res) {
        this.countriesService.get().subscribe(r => {
          this.countries = new MatTableDataSource(r);
          this.countries.paginator = this.paginator;
          this.searchTxt = "";
          this.countries.filterPredicate = (data: Country, filter: string) => {
            return data.name.includes(filter);
          }
        });
      }
    })
  }
  
  search(e: any): void {
    this.countries.filter = (e as HTMLInputElement).value.toLowerCase();
  }
}
