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

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.sass']
})
export class MainComponent implements OnInit {

  unsubscribe = new Subject();
  user: User;
  game: Game;
  lyrics = '';
  currentAttempt: Attempt;


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

  }
  exit() {
    this.authService.SignOut();
  }
}
