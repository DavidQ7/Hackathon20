import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/Services/user.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { User } from 'src/Models/User';
import { Router } from '@angular/router';
import { AuthService } from 'src/Services/auth.service';
import { GameService } from 'src/Services/game.service';
import { Game } from 'src/Models/Game';
import { NewLyricsAttempt } from 'src/Models/NewAttemptLyrics';
import { Attempt } from 'src/Models/Attempt';
import { WrongAttempt } from 'src/Models/WrongAttempt';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.sass']
})
export class GameComponent implements OnInit {

  unsubscribe = new Subject();
  user: User;
  game: Game;
  lyrics = '';
  currentAttempt: Attempt;
  listAttempts: Attempt[];

  constructor(private router: Router, private authService: AuthService, private userService: UserService,
              private gameService: GameService) { }

  ngOnInit() {
    this.userService.Get()
    .pipe(takeUntil(this.unsubscribe))
    .subscribe(user => { this.user = user; }, error => {
      this.router.navigate(['/about']);
    });
  }

  newGame() {
    this.gameService.newGame()
    .pipe(takeUntil(this.unsubscribe))
    .subscribe(game => {this.game = game; }, error => console.log(error));
  }

  endGame() {
    if (this.game === undefined) {
      return;
    }
    this.gameService.endGame(this.game.id)
    .pipe(takeUntil(this.unsubscribe))
    .subscribe(game => {this.game = game; }, error => console.log(error));
  }

  findSound() {
    const attempt: NewLyricsAttempt = {
      gameId: this.game.id,
      lyrics: this.lyrics
    };
    this.gameService.newAttempt(attempt)
    .pipe(takeUntil(this.unsubscribe))
    .subscribe(att => { this.currentAttempt = att; }, error => console.log(error));
  }

  rightAnswer() {
    this.gameService.rightAnswer(this.currentAttempt.id)
    .pipe(takeUntil(this.unsubscribe))
    .subscribe(game => {this.game = game; }, error => console.log(error));
  }
  wrongAnswer() {
    const attempt: WrongAttempt = {
      id: this.currentAttempt.id,
      gameId: this.game.id,
      lyrics: this.lyrics
    };
    this.gameService.wrongAnswer(attempt)
    .pipe(takeUntil(this.unsubscribe))
    .subscribe(att => { this.currentAttempt = att; }, error => console.log(error));
  }
  exit() {
    this.authService.SignOut();
  }
}
