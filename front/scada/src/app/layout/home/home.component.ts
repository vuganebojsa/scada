import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/security/services/authentication.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  ngOnInit(): void {
    if(!this.authenticationService.isLoggedIn()){
      this.router.navigate(['/login']);
    }
  }
  public constructor(private router: Router, private authenticationService:AuthenticationService){

  }
}
