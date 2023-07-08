import { Component, OnInit } from '@angular/core';
import {Tag} from '../../models/Tags'
@Component({
  selector: 'app-tag-management',
  templateUrl: './tag-management.component.html',
  styleUrls: ['./tag-management.component.css']
})
export class TagManagementComponent implements OnInit{
  hasLoaded: boolean = false;
  tags:Tag[];

  ngOnInit(): void {
    
    // load with websocket usage
    this.loadDummyData();

  }

  constructor(){

  }

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
