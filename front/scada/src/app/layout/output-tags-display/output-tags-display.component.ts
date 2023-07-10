import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OutTagsDTO, Tag } from 'src/app/models/Tags';
import { TagsService } from 'src/app/services/tags.service';

@Component({
  selector: 'app-output-tags-display',
  templateUrl: './output-tags-display.component.html',
  styleUrls: ['./output-tags-display.component.css']
})
export class OutputTagsDisplayComponent implements OnInit{

  ngOnInit(): void {

    this.getOutTags();

  }
  public constructor(private router: Router, private tagService: TagsService){

  }
  hasLoaded: boolean = false;
  tags:OutTagsDTO[];


  private getOutTags() {
    this.tagService.getOutputTags().subscribe({
      next: (res) => {
        this.tags = res['$values'];
        this.hasLoaded = true;
      },
      error: (err) => {
      }
    });
  }

  deleteTag(tag: OutTagsDTO):void{
    this.tagService.deleteOutTag(tag.id, tag.type).subscribe({
      next:(res) =>{
        if(res===true){
        alert('Successfully deleted tag: ' + tag.tagName);
        this.getOutTags();
        }
      },
      error:(err) =>{

      }
    })
  }

  changeValue(tag: OutTagsDTO,value:number ): void{
    if (tag.type == "DigitalOutput"){
      if (value!=0 && value!=1){
        alert("Digital output tags must have values 0 or 1!")
        this.getOutTags();
        return;
      }
    }
    this.tagService.changeOutTagValue(tag.id, tag.type, value).subscribe({
      next:(res) =>{
        alert("Succesfully changed output tag value!")
        this.getOutTags();
      },
      error:(err) =>{

      }
    })
  }
}
