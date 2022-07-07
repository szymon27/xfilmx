import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Genre } from 'src/app/models/genre';
import { GenresService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-genres-list',
  templateUrl: './genres-list.component.html',
  styleUrls: ['./genres-list.component.css']
})
export class GenresListComponent implements OnInit {
  genres: MatTableDataSource<Genre>;
  @ViewChild('paginator') paginator: MatPaginator;
  searchTxt: string = "";

  constructor(private genresService: GenresService, private router: Router) {
    this.genresService.get().subscribe(res => {
      this.genres = new MatTableDataSource(res);
      this.genres.paginator = this.paginator;
      this.genres.filterPredicate = (data: Genre, filter: string) => {
        return data.name.includes(filter);
      }
    });
  }

  ngOnInit(): void {
  }

  
  addGenre(): void {
    this.router.navigate(['genres/add']);
  }

  editGenre(genreId: number): void {
    this.router.navigate(['genres/' + genreId]);
  }

  deleteGenre(genreId: number): void {
    this.genresService.delete(genreId).subscribe(res => {
      if(res) {
        this.genresService.get().subscribe(r => {
          this.genres = new MatTableDataSource(r);
          this.genres.paginator = this.paginator;
          this.searchTxt = "";
          this.genres.filterPredicate = (data: Genre, filter: string) => {
            return data.name.includes(filter);
          }
        });
      }
    })
  }
  
  search(e: any): void {
    this.genres.filter = (e as HTMLInputElement).value.toLowerCase();
  }
}
