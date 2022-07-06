import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Country } from 'src/app/models/country';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-new-country-form',
  templateUrl: './new-country-form.component.html',
  styleUrls: ['./new-country-form.component.css']
})
export class NewCountryFormComponent implements OnInit {
  countryName: string = "";
  countryAlreadyExists: boolean = false;

  constructor(private countriesService: CountriesService, private router: Router) { }

  ngOnInit(): void {
  }

  addCountry(): void {
    this.countriesService.post(this.countryName).subscribe(res => {
      if(res != null) {
        this.countryAlreadyExists = false;
        this.router.navigate(['/countries']);
      }
      else 
      this.countryAlreadyExists = true;
    });
  }

  cancel(): void {
    this.router.navigate(['/countries']);
  }
}
