import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/Services/user.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { Statistic } from 'src/Models/Statistic';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.svg',
  styleUrls: ['./history.component.sass']
})
export class HistoryComponent implements OnInit {

  history = false;
  statistic: Statistic;
  unsubscribe = new Subject();
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.GetStat()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(x => this.statistic = x, error => console.log(error));
  }

}
