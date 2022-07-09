import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  news: News = {
    newsId: -1,
    userId: -1,
    title: "",
    description: "",
    date: null,
    picture: null
  };

  constructor(private newsService: NewsService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(p => {
      this.newsService.getById(p['id']).subscribe(res => {
        this.news= res;
        if(this.news == null)
          this.router.navigate(['/news']);
      });
    });
  }

  ngOnInit(): void {
  }

  getImageSrc(): any {
    if(this.news.picture != null)
      return 'data:image/png;base64,' + this.news.picture;
    return null;
  }
}
