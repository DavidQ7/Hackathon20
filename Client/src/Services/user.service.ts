import { Injectable } from '@angular/core';
import { User } from 'src/Models/User';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private httpClient: HttpClient) { }

  public Get() {
    return this.httpClient.get<User>(`${environment.API + '/api/user'}`);
  }
  public GetUpdates() {
    return this.httpClient.get(`${environment.API + '/api/user/update'}`);
  }
  public CreateUser(user: User) {
    return this.httpClient.post<User>(`${environment.API + '/api/user'}`, user, this.httpOptions);
  }
}
