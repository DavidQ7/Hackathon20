import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/Services/auth.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.svg',
  styleUrls: ['./logout.component.sass']
})
export class LogoutComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }
  exit() {
    this.authService.SignOut();
  }
}
