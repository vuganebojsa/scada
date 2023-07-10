import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { Tag } from 'src/app/models/Tags';
import { AuthenticationService } from 'src/app/security/services/authentication.service';
import { TagsService } from 'src/app/services/tags.service';

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
    this.initWebSocket();
    this.getTrendingTags();
  }
  public constructor(private router: Router,private tagService: TagsService, private authenticationService:AuthenticationService){

  }

  initWebSocket() {

    let connection = new HubConnectionBuilder()
      .withUrl('https://localhost:7253/hubs/inputTags')
      .withAutomaticReconnect()
      .build();

    connection.on('ReceiveMessage', (from: string, body: string) => {
      console.log('Dobio message');
      this.getTrendingTags();
    });

    connection.start();


  }
  hasLoaded: boolean = false;
  tags:Tag[] = [];




  private getTrendingTags() {
   this.tagService.getTrendingTags().subscribe({
    next:(res) =>{
      this.tags = res['$values'];
      this.hasLoaded = true;
    }
   })
  }
}
