import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Auth
import { AngularFireModule } from '@angular/fire';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { AngularFirestoreModule } from '@angular/fire/firestore';
import { environment } from '../environments/environment';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LandingComponent } from './landing/landing.component';
import { MainComponent } from './main/main.component';
import { HeaderComponent } from './header/header.component';
import { HeaderIconsComponent } from './headerIcons/headerIcons.component';
import { HistoryComponent } from './history/history.component';
import { AvatarComponent } from './avatar/avatar.component';
import { LogoutComponent } from './logout/logout.component';

import { TokenIntercepterService } from 'src/Services/token-intercepter.service';

import { FormsModule } from '@angular/forms';
import { GameComponent } from './game/game.component';
import { NgxSpinnersModule } from 'ngx-spinners';

@NgModule({
  declarations: [
    AppComponent,
    LandingComponent,
    MainComponent,
    HeaderComponent,
    HeaderIconsComponent,
    HistoryComponent,
    AvatarComponent,
    LogoutComponent,
    GameComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFireAuthModule,
    AngularFirestoreModule,
    HttpClientModule,
    FormsModule,
    NgxSpinnersModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenIntercepterService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
