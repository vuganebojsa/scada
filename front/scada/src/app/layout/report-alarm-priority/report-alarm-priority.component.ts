import { Component, OnInit } from '@angular/core';
import { AlarmPriorityDTO } from 'src/app/models/Alarm';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-report-alarm-priority',
  templateUrl: './report-alarm-priority.component.html',
  styleUrls: ['./report-alarm-priority.component.css']
})
export class ReportAlarmPriorityComponent implements OnInit{
  
  ngOnInit(): void {
    this.priorities = ["Time Asc", "Time Desc"];
  }

  hasLoaded: boolean = false;
  alarms:AlarmPriorityDTO[];
  selectedPriority:string = 'Time Asc';
  priorities: string[];

  priorityNumbers: number[] = [1, 2, 3];
  selectedPriorityNumber: number = 1;
  constructor(private reportService: ReportService){

  }

  public generateReport(): void{
    let sortType = 2;
    if(this.selectedPriority == this.priorities[1]) sortType = 3;

    this.reportService.getReportsByPriority(sortType, this.selectedPriorityNumber).subscribe({
      next:(result) =>{
        this.alarms = result['$values'];
        this.hasLoaded = true;
      },
      error:(err) =>{
        
      }
    })
  }
}
