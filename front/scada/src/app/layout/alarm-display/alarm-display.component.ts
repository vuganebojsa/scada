
import {Component, OnInit} from '@angular/core';
import { Alarm } from 'src/app/models/Alarm';
import { AlarmsService } from 'src/app/services/alarms.service';

@Component({
  selector: 'app-alarm-display',
  templateUrl: './alarm-display.component.html',
  styleUrls: ['./alarm-display.component.css']
})
export class AlarmDisplayComponent implements OnInit{

  hasLoaded: boolean = false;
  alarms:Alarm[] = [];
  createdSelected = false;
  ngOnInit(): void {
    
    // load with websocket usage
    this.alarmService.createdState$.subscribe({
      next:(result) =>{
        this.createdSelected = false;
        this.getAlarms();
      }
    })

  }

  constructor(private alarmService: AlarmsService){

  }

  getAlarms():void {
    this.alarmService.getAllAlarms().subscribe({
      next:(res) =>{
        this.alarms = res['$values'];
        this.hasLoaded = true;
      },
      error:(err) =>{

      }
    });
  }

  createAlarm():void{
    this.createdSelected = !this.createdSelected;
  }

  deleteAlarm(alarm: Alarm):void{

    this.alarmService.deleteAlarm(alarm.id).subscribe({
      next:(result) =>{
        if(result == true) {
            this.getAlarms();
        }
      },
      error:(err) =>{

      }
    })
  }
}
