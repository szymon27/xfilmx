import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Celebritie } from '../models/celebritie';
import { PostCelebritie } from '../models/post-celebritie';

@Injectable({
  providedIn: 'root'
})
export class CelebritiesService {
private url: string = 'http://localhost:1234/Celebrities'
  
  constructor(private httpClient: HttpClient) { }

  public getById(celebritieId: number): Observable<Celebritie>{
    return this.httpClient.get<Celebritie>(this.url + '/' + celebritieId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public get(): Observable<Celebritie[]>{
    return this.httpClient.get<Celebritie[]>(this.url, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public post(dto: PostCelebritie): Observable<Celebritie>{
    return this.httpClient.post<Celebritie>(this.url, dto, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    })
  }

  public put(dto: Celebritie): Observable<Celebritie>{
    return this.httpClient.put<Celebritie>(this.url, dto, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
   })
  } 
}
