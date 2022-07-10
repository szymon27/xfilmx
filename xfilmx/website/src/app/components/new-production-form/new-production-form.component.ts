import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PostProduction } from 'src/app/models/post-production';
import { ProductionsService } from 'src/app/services/productions.service';

@Component({
  selector: 'app-new-production-form',
  templateUrl: './new-production-form.component.html',
  styleUrls: ['./new-production-form.component.css']
})
export class NewProductionFormComponent implements OnInit {
  production: PostProduction = {
    isSerie: false,
    title: "",
    beginDate: null,
    endDate: null,
    duration: 0,
    description: ""
  };

  constructor(private productionsService: ProductionsService, private router: Router) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.router.navigate(['/films']);
  }

  createProduction(): void {
    if(!this.production.isSerie)
      this.production.endDate = null;
    this.productionsService.post(this.production).subscribe(res => {
      if(res != null)
        this.router.navigate(['/films']);
    });
  }
}
