// tslint:disable: quotemark
import { Component, Input } from "@angular/core";
// import "./history.svg";

@Component({
    selector: "app-header-icons",
    templateUrl: "./headerIcons.component.html",
    styleUrls: ["./headerIcons.component.sass"]
})
export class HeaderIconsComponent {
    @Input() logged: boolean;
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/
