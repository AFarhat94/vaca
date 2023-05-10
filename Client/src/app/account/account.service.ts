import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../shared/models/user';
import { environment } from 'src/environments/environment';
import { ReplaySubject, map, of } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  apiUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User | null>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  loadCurrentUser(token: string | null)
  {
    if (token)
    {
      this.currentUserSource.next(null);
      return of(null);
    }

    let headers = new HttpHeaders();
    headers = headers.set('content-Type', "application/json");
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get<User>(this.apiUrl + 'account', { headers }).pipe(
      map(user => {
        if (user)
        {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
          return user;
        }
        else
        {
          return null;
        }  
      })
    );
  }

  logIn(value: any)
  {
    let headers = new HttpHeaders();
    headers = headers.set('content-Type', "application/json");

    return this.http.post<User>(this.apiUrl + 'account/login' ,value ,{ headers })
      .pipe(
        map(user => {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        })
      );
  }

  logout()
  {
    localStorage.removeItem('token');
    this.router.navigateByUrl('/account/login');
    this.currentUserSource.next(null);
  }
}
