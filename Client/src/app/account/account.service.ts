import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../shared/models/user';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  apiUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  logIn(value: any)
  {
    const headers = new HttpHeaders({
      'content-Type': 'application/json'
    });

    return this.http.post<User>(this.apiUrl + 'account/login' ,value ,{ headers })
      .pipe(
        map(user => {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        })
      );
  }
}
