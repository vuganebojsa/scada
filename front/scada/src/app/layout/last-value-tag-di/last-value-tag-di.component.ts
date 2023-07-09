import { Component } from '@angular/core';
import { TagReportTimePeriodDTO } from 'src/app/models/Tags';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-last-value-tag-di',
  templateUrl: './last-value-tag-di.component.html',
  styleUrls: ['./last-value-tag-di.component.css']
})
export class LastValueTagDiComponent {
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
    if(this.from > this.to) {
      alert('Start date must be before end date.');
      return;
    }
    let sortType = 2;
    if(this.selectedSort == this.sortTypes[1]) sortType = 3;

    this.reportService.getLastValueOfDITags(sortType).subscribe({
      next:(result) =>{
        this.tags = result['$values'];
        this.hasLoaded = true;
      },
      error:(err) =>{
        
      }
    })
  }
}
