import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Tag } from 'src/app/models/Tags';
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
    this.loadDummyData();

  }
  public constructor(private router: Router, private authenticationService:AuthenticationService){

  }
  hasLoaded: boolean = false;
  tags:Tag[];




  private loadDummyData() {
    this.tags = [];
    let a1: Tag = {
      tagName:"Struja",
      description:"Merenje struje",
      ioAddress:"",
      currentValue:5
    };
    this.tags.push(a1);
    let a2: Tag = {
      tagName:"Napon",
      description:"Merenje Napona",
      ioAddress:"",
      currentValue:30
    };
    this.tags.push(a2);
    this.hasLoaded = true;
  }
}
