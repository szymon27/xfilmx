import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Genre } from 'src/app/models/genre';
import { GenresService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-genre-form',
  templateUrl: './genre-form.component.html',
  styleUrls: ['./genre-form.component.css']
})
export class GenreFormComponent implements OnInit {
  genre: Genre = {
    genreId: -1,
    name: ""
  };
  genreAlreadyExists: boolean = false;

  constructor(private genresService: GenresService, private router: Router, private activatedRoute: ActivatedRoute) { 
    this.activatedRoute.params.subscribe(p => {
      this.genresService.getById(p['id']).subscribe(res => {
        this.genre = res;
        if(this.genre == null)
          this.router.navigate(['/genres']);
      });
    });
  }

  ngOnInit(): void {
  }

  cancel(): void {
    this.router.navigate(['/genres']);
  }

  editGenre(): void {
    this.genresService.put(this.genre.genreId, this.genre.name).subscribe(res => {
      if(res != null) {
        this.genreAlreadyExists = false;
        this.router.navigate(['/genres']);
      }
      else 
        this.genreAlreadyExists = true;
    });
  }
}
