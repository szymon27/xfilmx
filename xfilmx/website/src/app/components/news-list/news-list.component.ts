import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.css']
})
export class NewsListComponent implements OnInit {
  news: MatTableDataSource<News>;
  searchTxt: string = "";
  @ViewChild('paginator') paginator: MatPaginator;

  constructor(private newsService: NewsService, private router: Router) {
    this.newsService.get().subscribe(res => {
      this.news = new MatTableDataSource(res);
      this.news.paginator = this.paginator;
      this.news.filterPredicate = (data: News, filter: string) => {
        return data.title.includes(filter);
      };
    });
  }

  ngOnInit(): void {}

  getImageSrc(news: News): any {
    if(news.picture != null)
      return 'data:image/png;base64,' + news.picture;
    return null;
  }

  getShortDescription(description: string): string {
    let x: number = 300;
    if(description == null)
      return "";
    if(description.length < x)
      return description;
    else
      return description.substring(0, x) + "...";
    }

  addNews(): void {
    this.router.navigate(['news/add']);
  }

  editNews(newsId: number): void {
    this.router.navigate(['news/' + newsId + '/edit']);
  }

  readNews(newsId: number): void {
    this.router.navigate(['news/' + newsId]);
  }

  deleteNews(newsId: number): void {
    this.newsService.delete(newsId).subscribe(res => {
      if(res) {
        this.newsService.get().subscribe(r => {
          this.news = new MatTableDataSource(r);
          this.news.paginator = this.paginator;
          this.searchTxt = "";
          this.news.filterPredicate = (data: News, filter: string) => {
            return data.title.includes(filter);
          }
        });
      }
    })
  }
}
