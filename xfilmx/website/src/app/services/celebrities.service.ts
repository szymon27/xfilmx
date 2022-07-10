import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Celebritie } from '../models/celebritie';
import { PostCelebritie } from '../models/post-celebritie';
import { PutCelebritie } from '../models/put-celebritie';

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

  public put(celebritieId: number, dto: PutCelebritie): Observable<Celebritie>{
    return this.httpClient.put<Celebritie>(this.url + '/' + celebritieId, dto, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
   })
  } 

  public delete(celebritieId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/' + celebritieId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public changePicture(celebritieId: number, file: File): Observable<boolean> {
    const formData: FormData = new FormData();
    formData.append('Picture', file);
    return this.httpClient.put<boolean>(this.url + '/changePicture/' + celebritieId, formData);
  }

  public deletePicture(celebritieId: number) : Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/deletePicture/' + celebritieId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }
}
