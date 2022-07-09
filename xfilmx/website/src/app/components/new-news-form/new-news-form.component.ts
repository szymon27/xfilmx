import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import jwtDecode from 'jwt-decode';
import { PostNews } from 'src/app/models/post-news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-new-news-form',
  templateUrl: './new-news-form.component.html',
  styleUrls: ['./new-news-form.component.css']
})
export class NewNewsFormComponent implements OnInit {
  news: PostNews = {
    userId: -1,
    title: "",
    description: ""
  };

  constructor(private newsService: NewsService, private router: Router, private jwtHelperService: JwtHelperService) {
    const token = localStorage.getItem("jwt");
    if(token && !this.jwtHelperService.isTokenExpired(token)) {
      this.news.userId = jwtDecode(localStorage.getItem("jwt"))['userId'];
    }
    else
      this.router.navigate(['/news']);
   }

  ngOnInit(): void {
  }

  cancel(): void {
    this.router.navigate(['/news']);
  }

  createNews(): void {
    this.newsService.post(this.news).subscribe(res => {
      this.router.navigate(['/news']);
    });
  }
}
