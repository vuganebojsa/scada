import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InTagsDTO } from 'src/app/models/Tags';
import { TagsService } from 'src/app/services/tags.service';

@Component({
  selector: 'app-in-tags-display',
  templateUrl: './in-tags-display.component.html',
  styleUrls: ['./in-tags-display.component.css']
})
export class InTagsDisplayComponent implements OnInit{
  ngOnInit(): void {

    this.getInTags();

  }
  public constructor(private router: Router, private tagService: TagsService){

  }
  hasLoaded: boolean = false;
  tags:InTagsDTO[];


  private getInTags() {
    this.tagService.getInTags().subscribe({
      next: (res) => {
        this.tags = res['$values'];
        this.hasLoaded = true;
      },
      error: (err) => {
      }
    });
  }

  changeScan(tag: InTagsDTO, isOn:boolean): void{

    this.tagService.onOffTagScan(tag.id, tag.type, isOn).subscribe({
      next:(res) =>{
        for(let i =0;i<this.tags.length;i++){
          if(this.tags[i].id == tag.id){
            this.tags[i].isScanOn = isOn;
          }
        }
        //this.getInTags();
      },
      error:(err) =>{

      }
    })
  }

  deleteTag(tag: InTagsDTO):void{
    this.tagService.deleteInTag(tag.id, tag.type).subscribe({
      next:(res) =>{
        if(res===true){
          alert('Successfully deleted tag: ' + tag.tagName);
          this.getInTags();
          }
      },
      error:(err) =>{

      }
    })
  }
}
