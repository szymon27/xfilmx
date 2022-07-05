import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Celebritie } from 'src/app/models/celebritie';
import { CelebritiesService } from 'src/app/services/celebrities.service';

@Component({
  selector: 'app-celebrities-list',
  templateUrl: './celebrities-list.component.html',
  styleUrls: ['./celebrities-list.component.css']
})
export class CelebritiesListComponent implements OnInit {
  celebrities: MatTableDataSource<Celebritie>
  @ViewChild('paginator') paginator: MatPaginator;

  constructor(private celebritiesService: CelebritiesService) { 
    this.celebritiesService.get().subscribe(res => {
      this.celebrities = new MatTableDataSource(res);
      this.celebrities.paginator = this.paginator;
      this.celebrities.filterPredicate = (data: Celebritie, filter: string) => {
        const tofilter = String(data.name+data.surname).trim().toLowerCase();
        const filterr = filter.replace(/\s/g, "").toLowerCase()
        console.log(tofilter)
        console.log(filterr)
        return tofilter.includes(filter.replace(/\s/g, "").toLowerCase())
      }
    })
  }

  ngOnInit(): void {
  }


  getImageSrc(celebritie: Celebritie): any {
    if(celebritie.picture != null)
      return 'data:image/png;base64,' + celebritie.picture;
    return null;
  }

  search(e: any): void{
    this.celebrities.filter = (e as HTMLInputElement).value.toLowerCase();
  }
}
