import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Authorization } from '../models/authorization';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  private url: string = 'http://localhost:1234/Authorization';
  
  constructor(private httpClient: HttpClient) { }

  public login(dto: Authorization): Observable<any> {
    return this.httpClient.post(this.url, dto, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }
}
