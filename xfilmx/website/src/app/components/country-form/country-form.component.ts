import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from 'src/app/models/country';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-country-form',
  templateUrl: './country-form.component.html',
  styleUrls: ['./country-form.component.css']
})
export class CountryFormComponent implements OnInit {
  country: Country;
  countryAlreadyExists: boolean = false;

  constructor(private countriesService: CountriesService, private router: Router, private activatedRoute: ActivatedRoute) { 
    this.activatedRoute.params.subscribe(p => {
      this.countriesService.getById(p['id']).subscribe(res => {
        this.country = res;
        if(this.country == null)
          this.router.navigate(['/countries']);
      });
    });
  }

  ngOnInit(): void {
  }

  cancel(): void {
    this.router.navigate(['/countries']);
  }

  editCountry(): void {
    this.countriesService.put(this.country.countryId, this.country.name).subscribe(res => {
      if(res != null) {
        this.countryAlreadyExists = false;
        this.router.navigate(['/countries']);
      }
      else 
        this.countryAlreadyExists = true;
    });
  }
}
