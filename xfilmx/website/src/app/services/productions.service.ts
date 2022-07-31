import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Celebritie } from '../models/celebritie';
import { Comment } from '../models/comment';
import { Country } from '../models/country';
import { Genre } from '../models/genre';
import { NewEpisod } from '../models/new-episod';
import { PostProduction } from '../models/post-production';
import { ProductionPicture } from '../models/post-production-picture';
import { ProductionTrailer } from '../models/post-production-trailer';
import { Production } from '../models/production';
import { ProductionCelebrities } from '../models/production-celebrities';
import { ProductionPictureDto } from '../models/production-picture';
import { ProductionTrailerDto } from '../models/production-trailer';
import { ProductionWatch } from '../models/production-watch';
import { PutProduction } from '../models/put-production';
import { Season } from '../models/season';

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

  public getSeasons(productionId: number): Observable<Season[]>{
    return this.httpClient.get<Season[]>(this.url + '/seasons/' + productionId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public addEpisod(productionId: number, newEpisod: NewEpisod): Observable<boolean>{
    return this.httpClient.post<boolean>(this.url + '/episods/' + productionId, newEpisod, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteEpisod(productionId: number, season: number, episod: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/episods/' + productionId + '/' + season + '/' + episod, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public editEpisod(productionId: number, season: number, episod: number, title: string): Observable<boolean> {
    return this.httpClient.put<boolean>(this.url + '/episods/' + productionId + '/' + season + '/' + episod, JSON.stringify(title), {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteSeason(productionId: number, season: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/seasons/' + productionId + '/' + season, {
        headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public addPicture(productionId: number, file: File): Observable<ProductionPicture>{
    const formData: FormData = new FormData();
    formData.append('Picture', file);
    return this.httpClient.post<ProductionPicture>(this.url + '/pictures/' + productionId, formData);
  }

  public removePicture(pictureId: number): Observable<boolean>{
    return this.httpClient.delete<boolean>(this.url + '/pictures/' + pictureId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    })
  }

  public getGallery(productionId: number): Observable<ProductionPictureDto[]>{
    return this.httpClient.get<ProductionPictureDto[]>(this.url + '/pictures/' + productionId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    })
  }

  public addTrailer(productionId: number, link: string): Observable<ProductionTrailer>{
    return this.httpClient.post<ProductionTrailer>(this.url + '/trailers/' + productionId, JSON.stringify(link), {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteTrailer(trailerId: number): Observable<boolean>{
    return this.httpClient.delete<boolean>(this.url + '/trailers/' + trailerId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    })
  }

  public getTrailers(productionId: number): Observable<ProductionTrailerDto[]>{
    return this.httpClient.get<ProductionTrailerDto[]>(this.url + '/trailers/' + productionId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    })
  }

  public addRate(productionId: number, userId: number, rate: number): Observable<boolean>{
    return this.httpClient.put<boolean>(this.url + '/rates/' + productionId + '/' + userId, JSON.stringify(rate), {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteRate(productionId: number, userId: number): Observable<boolean>{
    return this.httpClient.delete<boolean>(this.url + '/rates/' + productionId + '/' + userId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getRate(productionId: number, userId: number): Observable<number | null>{
    return this.httpClient.get<number | null>(this.url + '/rates/' + productionId + '/' + userId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public addComment(productionId: number, userId: number, comment: string): Observable<Comment>{
    return this.httpClient.put<Comment>(this.url + '/comments/' + productionId + '/' + userId, JSON.stringify(comment), {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteComment(commentId: number): Observable<boolean>{
    return this.httpClient.delete<boolean>(this.url + '/comments/' + commentId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getComments(productionId: number): Observable<Comment[]>{
    return this.httpClient.get<Comment[]>(this.url + '/comments/' + productionId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getToWatchProductions(userId: number): Observable<ProductionWatch[]>{
    return this.httpClient.get<ProductionWatch[]>(this.url + '/toWatchList/' + userId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public getWatchedProductions(userId: number): Observable<ProductionWatch[]>{
    return this.httpClient.get<ProductionWatch[]>(this.url + '/watchedList/' + userId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  //status
  //0 - none
  //1 - watched
  //2 - to watch
  public addProductionToWatch(productionId: number, userId: number, status: number): Observable<boolean>{
    return this.httpClient.put<boolean>(this.url + '/watch/' + productionId + '/' + userId, JSON.stringify(status), {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public deleteProductionFromWatch(productionId: number, userId: number): Observable<boolean>{
    return this.httpClient.delete<boolean>(this.url + '/watch/' + productionId + '/' + userId, {
      headers: new HttpHeaders({"Content-Type":"application/json"
      })
    });
  }

  public GetProductionStatus(productionId: number, userId: number): Observable<number>{
    return this.httpClient.get<number>(this.url + "/status/" + productionId + '/' +  userId, {
      
      headers: new HttpHeaders({"Content-Type":"application/json"
    })
    })
  }
}
