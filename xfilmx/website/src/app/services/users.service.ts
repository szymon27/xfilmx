import { BooleanInput } from '@angular/cdk/coercion';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChangePassword } from '../models/change-password';
import { PostUser } from '../models/post-user';
import { User } from '../models/user';
import { UserType } from '../models/user-type';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private url: string = 'http://localhost:1234/Users';
  
  constructor(private httpClient: HttpClient) { }

  public getById(userId: number): Observable<User> {
    return this.httpClient.get<User>(this.url + '/' + userId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public get(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.url, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public post(dto: PostUser): Observable<User> {
    return this.httpClient.post<User>(this.url, dto, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public changePassword(userId: number, dto: ChangePassword): Observable<boolean> {
    return this.httpClient.put<boolean>(this.url + '/changePassword/' + userId, dto, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public changeType(userId: number, type: UserType): Observable<boolean> {
    return this.httpClient.put<boolean>(this.url + '/changeType/' + userId, type, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public changePicture(userId: number, file: File): Observable<boolean> {
    const formData: FormData = new FormData();
    formData.append('Picture', file);
    return this.httpClient.put<boolean>(this.url + '/changePicture/' + userId, formData);
  }

  public deletePicture(userId: number) : Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/deletePicture/' + userId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }
}
