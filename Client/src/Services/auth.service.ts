import { Injectable, NgZone } from '@angular/core';
import { Subject } from 'rxjs';
import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';
import { UserService } from './user.service';
import { PhotoService } from './photo.service';
import * as firebase from 'firebase';
import { User } from 'src/Models/User';
import { takeUntil } from 'rxjs/operators';
import { isNull, isUndefined } from 'util';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  token: string;
  userData: any; // Save logged in user data
  unsubscribe = new Subject();

  constructor(
    private afAuth: AngularFireAuth,
    private ngZone: NgZone,
    private router: Router,
    private userService: UserService,
    private photoService: PhotoService
  ) {
    this.afAuth.idToken.subscribe(token => {
      this.token = token;
      localStorage.setItem('idKey', this.token);
    });
    this.afAuth.authState.subscribe(user => {
      if (user) {
        this.userData = user;
        const dbuser: User = {
          name: this.userData.displayName,
          email: this.userData.email,
          photo: this.userData.photoURL
        };
        localStorage.setItem('user', JSON.stringify(dbuser));
        JSON.parse(localStorage.getItem('user'));
      } else {
        localStorage.setItem('user', null);
        JSON.parse(localStorage.getItem('user'));
      }
    });
  }

  GoogleAuth() {
    return this.AuthLogin(new firebase.auth.GoogleAuthProvider());
  }

  AuthLogin(provider) {
    return this.afAuth.auth
      .signInWithPopup(provider)
      .then(result => {
        this.ngZone.run(() => {
          if (result.user) {
            this.userData = result.user;
            const user: User = {
              name: this.userData.displayName,
              email: this.userData.email,
              photo: this.userData.photoURL
            };
            this.photoService.GetPhoto(user.photo).then(base64 => {
              user.photo = base64 as string;
              this.userService
                .Get()
                .pipe(takeUntil(this.unsubscribe))
                .subscribe(
                  x => {
                    if (!isUndefined(x) && !isNull(x)) {
                      this.router.navigate(['']);
                    } else {
                      this.userService
                        .CreateUser(user)
                        .pipe(takeUntil(this.unsubscribe))
                        .subscribe(newuser => {
                          if (!isUndefined(newuser) && !isNull(newuser)) {
                            this.router.navigate(['']);
                          }
                        });
                    }
                  },
                  error => console.log(error)
                );
            });
          }
        });
      })
      .catch(error => {
        window.alert(error);
      });
  }

  SignOut() {
    return this.afAuth.auth.signOut().then(() => {
      localStorage.removeItem('user');
      localStorage.removeItem('idKey');
      this.router.navigate(['/about']);
    });
  }

  get isLoggedIn(): boolean {
    const user = JSON.parse(localStorage.getItem('user'));
    return (user !== null && user.emailVerified !== false) ? true : false;
  }
}
