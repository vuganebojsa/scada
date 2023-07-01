import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';

@Injectable()
export class Interceptor implements HttpInterceptor {

  constructor(private router: Router, private authenticationService: AuthenticationService){}
  intercept(
    request: HttpRequest<any>, 
    next: HttpHandler
    ): Observable<HttpEvent<any>> {
      const accessToken: any = localStorage.getItem('user');
    const decodedItem = JSON.parse(accessToken);

    if (request.headers.get('skip')) return next.handle(request);
    if (accessToken) {
      const cloned = request.clone({
        headers: request.headers.set('Authorization', decodedItem)
      });

      return next.handle(cloned).pipe(
        tap(() =>{},
          (error:any) =>{
            if (error instanceof HttpErrorResponse && error.error.status === 401) {
              // Logout logic here
              
              alert('Your Session has expired. Please log in again.');
              this.authenticationService.logout();
              this.router.navigate(['/login']);
            }
          }
        )
      );
    } else {
      return next.handle(request).pipe(
        tap(() =>{},
          (error:any) =>{
            if (error instanceof HttpErrorResponse && error.error.status === 401) {
              // Logout logic here
              alert('Your Session has expired. Please log in again.');
              this.authenticationService.logout();
              this.router.navigate(['/login']);
            }
          }
        )
      );
    }
      
  }
}