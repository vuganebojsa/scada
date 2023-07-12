import { Component } from '@angular/core';
import {AlarmDTO} from "../../models/Alarm";
import {ReportService} from "../../services/report.service";
import {TagsService} from "../../services/tags.service";
import {TagReportTimePeriodDTO} from "../../models/Tags";

@Component({
  selector: 'app-report-all-values-of-tag-with-id',
  templateUrl: './report-all-values-of-tag-with-id.component.html',
  styleUrls: ['./report-all-values-of-tag-with-id.component.css']
})
export class ReportAllValuesOfTagWithIdComponent {

  ngOnInit(): void {
  }

  tagId:number
  hasLoaded: boolean = false;
  tagValues:TagReportTimePeriodDTO[];
  constructor(private reportService: ReportService){
    this.tagId = 1
  }


  public generateReport(): void{
    console.log(this.tagId)
    this.reportService.getTagValues(this.tagId).subscribe({
      next:(result) =>{

        console.log(result)
        this.tagValues = result['$values'];
        console.log(this.tagValues)

        this.hasLoaded = true;
      },
      error:(err) =>{

      }
    })
  }
}
