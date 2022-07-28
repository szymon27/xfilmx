import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Production } from 'src/app/models/production';
import { ProductionsService } from 'src/app/services/productions.service';

@Component({
  selector: 'app-films-list',
  templateUrl: './films-list.component.html',
  styleUrls: ['./films-list.component.css']
})
export class FilmsListComponent implements OnInit {
  films: MatTableDataSource<Production>;
  @ViewChild('paginator') paginator: MatPaginator;
  searchTxt: string = "";

  constructor(private productionsService: ProductionsService, private router: Router) {
    this.productionsService.get().subscribe(res => {
      this.films = new MatTableDataSource(res);
      this.films.paginator = this.paginator;
      this.films.filterPredicate = (data: Production, filter: string) => {
        return data.title.includes(filter);
      }
    });
  }

  ngOnInit(): void {
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
        this.productionsService.get().subscribe(r => {
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
}
