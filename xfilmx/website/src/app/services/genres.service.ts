import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Genre } from '../models/genre';

@Injectable({
  providedIn: 'root'
})
export class GenresService {
  private url: string = 'http://localhost:1234/Genres'

  constructor(private httpClient: HttpClient) { }

  public getById(genreId: number): Observable<Genre> {
    return this.httpClient.get<Genre>(this.url + '/' + genreId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public get(): Observable<Genre[]> {
    return this.httpClient.get<Genre[]>(this.url, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public post(name: string): Observable<Genre> {
    return this.httpClient.post<Genre>(this.url, JSON.stringify(name), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public put(genreId: number, name: string): Observable<Genre> {
    return this.httpClient.put<Genre>(this.url + '/' + genreId, JSON.stringify(name), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public delete(genreId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/' + genreId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }
}
