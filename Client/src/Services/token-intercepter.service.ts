import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TokenIntercepterService {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = (localStorage.getItem('idKey'));
    if (token) {
        req = req.clone({setHeaders: {Authorization: `Bearer ${token}`}});
    }
    return next.handle(req);
}
}
