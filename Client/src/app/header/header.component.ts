// tslint:disable: quotemark
import { Component, Input } from "@angular/core";
import { Statistic } from 'src/Models/Statistic';

@Component({
    selector: "app-header",
    templateUrl: "./header.component.html",
    styleUrls: ["./header.component.sass"]
})
export class HeaderComponent {
    statistic: Statistic;
    history = false;
    @Input() isLogged: boolean;
    share() {
        window.alert("The product has been shared!");
    }
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/
