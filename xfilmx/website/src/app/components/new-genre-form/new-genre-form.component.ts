import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GenresService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-new-genre-form',
  templateUrl: './new-genre-form.component.html',
  styleUrls: ['./new-genre-form.component.css']
})
export class NewGenreFormComponent implements OnInit {
  genreName: string = "";
  genreAlreadyExists: boolean = false;

  constructor(private genresService: GenresService, private router: Router) { }

  ngOnInit(): void {
  }

  addGenre(): void {
    this.genresService.post(this.genreName).subscribe(res => {
      if(res != null) {
        this.genreAlreadyExists = false;
        this.router.navigate(['/genres']);
      }
      else 
        this.genreAlreadyExists = true;
    });
  }

  cancel(): void {
    this.router.navigate(['/genres']);
  }
}
