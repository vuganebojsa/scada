import { Component, OnInit } from '@angular/core';
import { TagsService } from 'src/app/services/tags.service';
import {Tag} from '../../models/Tags'
@Component({
  selector: 'app-tag-management',
  templateUrl: './tag-management.component.html',
  styleUrls: ['./tag-management.component.css']
})
export class TagManagementComponent implements OnInit{
  hasLoaded: boolean = false;
  tags:Tag[];
  showAo=false;
  showDo=false;
  showAi=false;
  showDi=false;
  
  ngOnInit(): void {
    
    // load with websocket usage
    this.tagService.createdState$.subscribe({
      next:(res) =>{
        this.getTags();
      }
    })
    //this.getTags();

  }
  getTags():void{

    this.tagService.getTags().subscribe({
      next:(res) =>{this.tags = res['$values'];this.hasLoaded=true;},
      error:(err) =>{}
    })
  }

  showForm(type:string):void{
    if(type=='ao'){
      this.showAo = true;
      this.showAi = false;
      this.showDi = false;
      this.showDo = false;
    }else if(type=='ai'){
      this.showAo = false;
      this.showAi = true;
      this.showDi = false;
      this.showDo = false;
    }else if(type=='do'){
      this.showAo = false;
      this.showAi = false;
      this.showDi = false;
      this.showDo = true;
    }else{
      this.showAo = false;
      this.showAi = false;
      this.showDi = true;
      this.showDo = false;
    }
  }
  constructor(private tagService: TagsService){

  }

}
