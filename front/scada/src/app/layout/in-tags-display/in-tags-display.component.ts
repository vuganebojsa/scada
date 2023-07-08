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

}
