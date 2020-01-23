import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ResponseSearch } from 'src/Models/Deezer/ResponseSearch';
import { map } from 'rxjs/operators';
import { ResponseSound } from 'src/Models/Deezer/ResponseSound';

@Injectable({
  providedIn: 'root'
})
export class DeezerService {
  httpOptions = {
    headers: new HttpHeaders({
      'x-rapidapi-host': 'deezerdevs-deezer.p.rapidapi.com',
      'x-rapidapi-key': '8afa69b90bmsh9e2d15d879d0566p1e0fd8jsn69e68698b9c1'
    })
  };
  api = 'https://cors-anywhere.herokuapp.com/http://api.deezer.com/';

  constructor(private httpClient: HttpClient) {}

  searchByTrackName(name: string) {
    return this.httpClient
      .get(
        `https://deezerdevs-deezer.p.rapidapi.com/search/track?q=${name}`, this.httpOptions)
        .pipe(map((response: any) =>  response.data));
  }
}
