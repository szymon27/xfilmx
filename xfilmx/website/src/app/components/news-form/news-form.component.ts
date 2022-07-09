import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PutNews } from 'src/app/models/put-news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-news-form',
  templateUrl: './news-form.component.html',
  styleUrls: ['./news-form.component.css']
})
export class NewsFormComponent implements OnInit {
  news: PutNews = {
    title: "",
    description: ""
  };
  imageSrc: any = null;
  file: File = null;
  newsId: number;

  constructor(private newsService: NewsService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe(p => {
      this.newsId = p['id'];
      this.newsService.getById(this.newsId).subscribe(res => {
        this.news= res;
        if(this.news == null)
          this.router.navigate(['/news']);
        if(res.picture.length > 0)
          this.imageSrc = 'data:image/png;base64,' + res.picture;
      });
    });
   }

  ngOnInit(): void {
  }

  editNews(): void {
    this.newsService.put(this.newsId, this.news).subscribe();
  }

  handleNewPicture(e: any): void {
    this.file = (e.target as HTMLInputElement).files.item(0);
    if(this.file != null) {
      let reader: FileReader = new FileReader();
      reader.readAsDataURL(this.file);
      reader.onload = (event: any) => {
        this.imageSrc = reader.result;
      };      
    }
    else {
      this.imageSrc = null;
      this.file = null;
    }
  }

  onChangePicture(): void {
    const token: string = localStorage.getItem("jwt");
    this.newsService.changePicture(this.newsId, this.file).subscribe();
  }

  onDeletePicture(): void {
    this.newsService.deletePicture(this.newsId).subscribe(res => {
      if(res) {
        this.imageSrc = null;
        this.file = null;
      }
    });
  }
}
