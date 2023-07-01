import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/security/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{

  ngOnInit(): void {
    this.authenticationService.userState$.subscribe((state) =>{
      if(state === null || state === undefined || state === false)
        this.loggedIn = false;
      else
        this.loggedIn = true;
    });
  }
  loggedIn:boolean = false;
  constructor(private authenticationService: AuthenticationService){

  }
  logout():void{
    this.authenticationService.logout();

  }
}
