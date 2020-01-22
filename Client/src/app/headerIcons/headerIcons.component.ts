// tslint:disable: quotemark
import { Component } from "@angular/core";

@Component({
    selector: "app-header-icons",
    templateUrl: "./headerIcons.component.html",
    styleUrls: ["./headerIcons.component.css"]
})
export class HeaderIconsComponent {
    share() {
        window.alert("The product has been shared!");
    }
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/
