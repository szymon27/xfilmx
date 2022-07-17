import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Celebritie } from '../models/celebritie';
import { Country } from '../models/country';
import { Genre } from '../models/genre';
import { PostProduction } from '../models/post-production';
import { Production } from '../models/production';
import { ProductionCelebrities } from '../models/production-celebrities';
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

  public getGenres(productionId: number): Observable<Genre[]> {
    return this.httpClient.get<Genre[]>(this.url + '/genres/' + productionId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public addGenre(productionId: number, genreId: number): Observable<boolean> {
    return this.httpClient.put<boolean>(this.url + '/genres/' + productionId, JSON.stringify(genreId), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteGenre(productionId: number, genreId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/genres/' + productionId + '/' + genreId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getScreenwriters(productionId: number): Observable<Celebritie[]> {
    return this.httpClient.get<Celebritie[]>(this.url + '/screenwriters/' + productionId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public addScreenwriter(productionId: number, celebritieId: number): Observable<boolean> {
    return this.httpClient.put<boolean>(this.url + '/screenwriters/' + productionId, JSON.stringify(celebritieId), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteScreenwriter(productionId: number, celebritieId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/screenwriters/' + productionId + '/' + celebritieId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getDirectors(productionId: number): Observable<Celebritie[]> {
    return this.httpClient.get<Celebritie[]>(this.url + '/directors/' + productionId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public addDirector(productionId: number, celebritieId: number): Observable<boolean> {
    return this.httpClient.put<boolean>(this.url + '/directors/' + productionId, JSON.stringify(celebritieId), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteDirector(productionId: number, celebritieId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/directors/' + productionId + '/' + celebritieId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getActors(productionId: number): Observable<[Celebritie, string][]> {
    return this.httpClient.get<[Celebritie, string][]>(this.url + '/actors/' + productionId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public addActor(productionId: number, celebritieId: number, character: string): Observable<boolean> {
    return this.httpClient.put<boolean>(this.url + '/actors/' + productionId + '/' + celebritieId, JSON.stringify(character), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteActor(productionId: number, celebritieId: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/actors/' + productionId + '/' + celebritieId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getCelebrities(productionId: number): Observable<ProductionCelebrities[]> {
    return this.httpClient.get<ProductionCelebrities[]>(this.url + '/celebrities/' + productionId, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }
}
