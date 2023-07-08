import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Tag } from 'src/app/models/Tags';
import { TagsService } from 'src/app/services/tags.service';

@Component({
  selector: 'app-output-tags-display',
  templateUrl: './output-tags-display.component.html',
  styleUrls: ['./output-tags-display.component.css']
})
export class OutputTagsDisplayComponent implements OnInit{

  ngOnInit(): void {

    this.tagService.getOutputTags().subscribe({
      next:(res) =>{
        this.tags = res;
      },
      error:(err) =>{
        
      }
    })

  }
  public constructor(private router: Router, private tagService: TagsService){

  }
  hasLoaded: boolean = false;
  tags:Tag[];


}
