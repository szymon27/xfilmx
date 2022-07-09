import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { News } from '../models/news';
import { PostNews } from '../models/post-news';
import { PutNews } from '../models/put-news';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  private url: string = 'http://localhost:1234/News';

  constructor(private httpClient: HttpClient) { }

  public getById(newsId: number): Observable<News> {
    return this.httpClient.get<News>(this.url + '/' + newsId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public get(): Observable<News[]> {
    return this.httpClient.get<News[]>(this.url, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public post(dto: PostNews): Observable<News> {
    return this.httpClient.post<News>(this.url, dto, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

    public put(newsId: number, dto: PutNews): Observable<News> {
    return this.httpClient.put<News>(this.url + '/' + newsId, dto, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public delete(newsId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/' + newsId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public changePicture(newsId: number, file: File): Observable<boolean> {
    const formData: FormData = new FormData();
    formData.append('Picture', file);
    return this.httpClient.put<boolean>(this.url + '/changePicture/' + newsId, formData);
  }

  public deletePicture(newsId: number) : Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/deletePicture/' + newsId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }
}
