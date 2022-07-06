import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Country } from '../models/country';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {
  private url: string = 'http://localhost:1234/Countries';

  constructor(private httpClient: HttpClient) { }

  public getById(countryId: number): Observable<Country> {
    return this.httpClient.get<Country>(this.url + '/' + countryId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public get(): Observable<Country[]> {
    return this.httpClient.get<Country[]>(this.url, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public post(name: string): Observable<Country> {
    return this.httpClient.post<Country>(this.url, JSON.stringify(name), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public put(countryId: number, name: string): Observable<Country> {
    return this.httpClient.put<Country>(this.url + '/' + countryId, JSON.stringify(name), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public delete(countryId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/' + countryId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }
}
