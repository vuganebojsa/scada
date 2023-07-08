import { Component, OnInit } from '@angular/core';
import { TagReportTimePeriodDTO } from 'src/app/models/Tags';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-tag-values-time-period',
  templateUrl: './tag-values-time-period.component.html',
  styleUrls: ['./tag-values-time-period.component.css']
})
export class TagValuesTimePeriodComponent implements OnInit{
  ngOnInit(): void {
  }

  hasLoaded: boolean = false;
  selectedSort: string = 'Time Asc';
  sortTypes: string[] = ['Time Asc', 'Time Desc'];
  from:Date;
  to:Date;
  tags:TagReportTimePeriodDTO[];
  constructor(private reportService: ReportService){

  }

  public generateReport(): void{
    let sortType = 2;
    if(this.selectedSort == this.sortTypes[1]) sortType = 3;

    this.reportService.getTagsInTimePeriod(this.from, this.to, sortType).subscribe({
      next:(result) =>{
        this.tags = result['$values'];
        this.hasLoaded = true;
      },
      error:(err) =>{
        
      }
    })
  }
}
