import { Component, OnInit } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { ProductionWatch } from 'src/app/models/production-watch';
import { ProductionsService } from 'src/app/services/productions.service';

@Component({
  selector: 'app-my-xfilmx',
  templateUrl: './my-xfilmx.component.html',
  styleUrls: ['./my-xfilmx.component.css']
})
export class MyXfilmxComponent implements OnInit {

  toWatch: ProductionWatch[] = [];
  watched: ProductionWatch[] = [];

  constructor(private productionsService: ProductionsService) { }

  ngOnInit(): void {
    this.productionsService.getToWatchProductions(jwtDecode(localStorage.getItem("jwt"))['userId']).subscribe(res =>{
      this.toWatch=res
    })
    this.productionsService.getWatchedProductions(jwtDecode(localStorage.getItem("jwt"))['userId']).subscribe(res =>{
      this.watched=res
    })
  }

}
