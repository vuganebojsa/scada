import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-display-report',
  templateUrl: './display-report.component.html',
  styleUrls: ['./display-report.component.css']
})
export class DisplayReportComponent implements OnInit{

  
  reports:string[];
  selectedReport:string = '';

  ngOnInit(): void {


    this.initializeReports();
  }

  private initializeReports() {
    this.reports = [
      'Alarms in certain time period',
      'Alarms with certain priority',
      'Tag values in certain time period',
      'Last value of all AI tags',
      'Last value of all DI tags',
      'All values of tags with certain ID'
    ];
  }
}
