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
import { Statistic } from 'src/Models/Statistic';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.sass']
})
export class MainComponent implements OnInit {

  user: User;
  unsubscribe = new Subject();
  statistic: Statistic;

  constructor(private userService: UserService, private router: Router, private gameService: GameService
    ,         private authService: AuthService) { }

  ngOnInit() {
    this.userService.Get()
    .pipe(takeUntil(this.unsubscribe))
    .subscribe(user => { this.user = user; }, error => {
      this.router.navigate(['/about']);
    });
    this.userService.GetStat()
    .pipe(takeUntil(this.unsubscribe))
    .subscribe(x => this.statistic = x, error => console.log(error));
  }
  newGame() {
    this.gameService.newGame()
    .pipe(takeUntil(this.unsubscribe))
    .subscribe(game => { console.log(game); }, error => console.log(error));
  }
  exit() {
    this.authService.SignOut();
  }
}
