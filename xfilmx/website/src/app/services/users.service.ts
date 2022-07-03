import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PostUser } from '../models/post-user';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private url: string = 'http://localhost:1234/Users';
  
  constructor(private httpClient: HttpClient) { }

  public post(dto: PostUser): Observable<User> {
    return this.httpClient.post<User>(this.url, dto);
  }
}
