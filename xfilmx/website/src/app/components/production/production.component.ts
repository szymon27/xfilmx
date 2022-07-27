import { Component, OnInit } from '@angular/core';
import { Production } from 'src/app/models/production';

@Component({
  selector: 'app-production',
  templateUrl: './production.component.html',
  styleUrls: ['./production.component.css']
})
export class ProductionComponent implements OnInit {
  celebritie: Production = {
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
  constructor() { }

  ngOnInit(): void {
  }

}
