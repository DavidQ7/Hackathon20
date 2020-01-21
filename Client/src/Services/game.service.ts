import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Game } from 'src/Models/Game';
import { environment } from 'src/environments/environment';
import { NewLyricsAttempt } from 'src/Models/NewAttemptLyrics';
import { Attempt } from 'src/Models/Attempt';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private httpClient: HttpClient) {}

  newGame() {
    return this.httpClient.get<Game>(`${environment.API + '/api/game/new'}`);
  }
  endGame(id: number) {
    return this.httpClient.get<Game>(`${environment.API + '/api/game/'}` + `${id}`);
  }
  newAttempt(attempt: NewLyricsAttempt) {
    return this.httpClient.post<Attempt>(`${environment.API + '/api/attempt'}`, attempt);
  }
}
