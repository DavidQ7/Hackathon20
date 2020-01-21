import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/Services/user.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { User } from 'src/Models/User';
import { Router } from '@angular/router';
import { AuthService } from 'src/Services/auth.service';
import { GameService } from 'src/Services/game.service';
import { Game } from 'src/Models/Game';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.sass']
})
export class MainComponent implements OnInit {

  unsubscribe = new Subject();
  user: User;
  game: Game;

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

  exit() {
    this.authService.SignOut();
  }
}
