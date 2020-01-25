import { Component, OnInit } from '@angular/core';
import { User } from 'src/Models/User';
import { UserService } from 'src/Services/user.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.sass']
})
export class AvatarComponent implements OnInit {
  user: User;
  unsubscribe = new Subject();
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.userService
      .Get()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(
        user => {
          this.user = user;
        },
        error => {
          this.router.navigate(['/about']);
        }
      );
  }

}
