// tslint:disable: quotemark
import { Component, Input, OnInit } from "@angular/core";
import { Subject } from 'rxjs';
import { User } from 'src/Models/User';
import { Router } from '@angular/router';
import { Statistic } from 'src/Models/Statistic';
import { UserService } from 'src/Services/user.service';
import { takeUntil } from 'rxjs/operators';


@Component({
    selector: "app-header",
    templateUrl: "./header.component.html",
    styleUrls: ["./header.component.sass"]
})
export class HeaderComponent implements OnInit {
    history = false;
    user: User;
    unsubscribe = new Subject();
    statistic: Statistic;
    @Input() isLogged: boolean;

    constructor(private router: Router, private userService: UserService) {

    }

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
    change() {
        this.history = !this.history;
    }
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/
