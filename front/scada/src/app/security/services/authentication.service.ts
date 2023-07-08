import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import {environment} from 'src/app/environment/environment';
import {JwtHelperService} from '@auth0/angular-jwt'
import {Token} from '../../models/Token'
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  user$ = new BehaviorSubject(null);
  userState$ = this.user$.asObservable();

  constructor(private http:HttpClient, private router: Router) {
    this.user$.next(this.getRole());
   }

   login(email: string, password: string): Observable<any> {
    return this.http.post<any>(environment.apiHost + 'api/User/login', 
    { "username":email, "password":password });
  }
  

  logout(){
    localStorage.removeItem('user');
    this.setUser();
    this.router.navigate(['login']);

  }
  isLoggedIn(): boolean{
    return localStorage.getItem('user') != null;
  }


  getRole():any{
    if(this.isLoggedIn()){
      const accessToken: string | null = localStorage.getItem('user');
      const helper = new JwtHelperService();
      if(accessToken != null){
        const role = helper.decodeToken(accessToken).role[0].authority;
        return role;
      }
      return null;
      
    }
    return null;
  }

  setUser(): void{
    this.user$.next(this.getRole());
  }
}
