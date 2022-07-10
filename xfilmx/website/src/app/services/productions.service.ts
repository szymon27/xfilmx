import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Country } from '../models/country';
import { PostProduction } from '../models/post-production';
import { Production } from '../models/production';
import { PutProduction } from '../models/put-production';

@Injectable({
  providedIn: 'root'
})
export class ProductionsService {
  private url: string = 'http://localhost:1234/Productions';

  constructor(private httpClient: HttpClient) { }

  public getById(productionId: number): Observable<Production> {
    return this.httpClient.get<Production>(this.url + '/' + productionId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public get(): Observable<Production[]> {
    return this.httpClient.get<Production[]>(this.url, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getFilms(): Observable<Production[]> {
    return this.httpClient.get<Production[]>(this.url + '/films', {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getSeries(): Observable<Production[]> {
    return this.httpClient.get<Production[]>(this.url + '/series', {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public post(dto: PostProduction): Observable<Production> {
    return this.httpClient.post<Production>(this.url, dto, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public put(productionId: number, dto: PutProduction): Observable<Production> {
    return this.httpClient.put<Production>(this.url + '/' + productionId, dto, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public changePicture(productionId: number, file: File): Observable<boolean> {
    const formData: FormData = new FormData();
    formData.append('Picture', file);
    return this.httpClient.put<boolean>(this.url + '/changePicture/' + productionId, formData);
  }

  public deletePicture(productionId: number) : Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/deletePicture/' + productionId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public delete(productionId: number) : Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/' + productionId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getCountries(productionId: number): Observable<Country[]> {
    return this.httpClient.get<Country[]>(this.url + '/countries/' + productionId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public addCountry(productionId: number, countryId: number): Observable<boolean> {
    return this.httpClient.put<boolean>(this.url + '/countries/' + productionId, JSON.stringify(countryId), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteCountry(productionId: number, countryId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/countries/' + productionId + '/' + countryId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }
}
