import { Component } from '@angular/core';
import { TagReportTimePeriodDTO } from 'src/app/models/Tags';
import { ReportService } from 'src/app/services/report.service';
import {AlarmDTO, AlarmPriorityDTO} from "../../models/Alarm";


@Component({
  selector: 'app-report-alarm-time-period',
  templateUrl: './report-alarm-time-period.component.html',
  styleUrls: ['./report-alarm-time-period.component.css']
})
export class ReportAlarmTimePeriodComponent {
  ngOnInit(): void {
  }

  hasLoaded: boolean = false;
  selectedSort: string = 'Time Asc';
  sortTypes: string[] = ['Time Asc', 'Time Desc'];
  from:Date;
  to:Date;
  alarms:AlarmDTO[];
  constructor(private reportService: ReportService){

  }


  public generateReport(): void{
    if(this.from > this.to) {
      alert('Start date must be before end date.');
      return;
    }
    let sortType = 2;
    if(this.selectedSort == this.sortTypes[1]) sortType = 3;

    this.reportService.getAlarmsInTimePeriod(this.from, this.to, sortType).subscribe({
      next:(result) =>{

        console.log(result)
        this.alarms = result['$values'];
        console.log(this.alarms)

        this.hasLoaded = true;
      },
      error:(err) =>{

      }
    })
  }

}
