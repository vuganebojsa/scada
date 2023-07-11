
import {Component, OnInit} from '@angular/core';
import { HubConnectionBuilder } from '@microsoft/signalr/dist/esm/HubConnectionBuilder';
import { ActivatedAlarm, Alarm } from 'src/app/models/Alarm';
import { AlarmsService } from 'src/app/services/alarms.service';

@Component({
  selector: 'app-alarm-display',
  templateUrl: './alarm-display.component.html',
  styleUrls: ['./alarm-display.component.css']
})
export class AlarmDisplayComponent implements OnInit{

  hasLoaded: boolean = false;
  hasActivatedLoaded:boolean = false;
  alarms:Alarm[] = [];
  activatedAlarms:ActivatedAlarm[] = [];
  createdSelected = false;
  ngOnInit(): void {
    
    
    // load with websocket usage
    this.alarmService.createdState$.subscribe({
      next:(result) =>{
        this.createdSelected = false;
        this.getAlarms();
        this.getActivatedAlarms();
      }
    });
    this.initWebSocket();

  }
  initWebSocket() {
    console.log('Alo?');
    let connection = new HubConnectionBuilder()
      .withUrl('https://localhost:7253/hubs/alarms')
      .withAutomaticReconnect()
      .build();
    connection.on('ReceiveMessage', (from: string, body: string) => {
      //this.getActivatedAlarms();
    });
    
    connection.start().then(result => {
      console.log('Connected to alarms');
    })
    .catch(e => console.log('Connection failed: ', e));

  }
  constructor(private alarmService: AlarmsService){

  }

  getAlarms():void {
    this.hasLoaded = false;

    this.alarmService.getAllAlarms().subscribe({
      next:(res) =>{
        this.alarms = res['$values'];
        this.hasLoaded = true;
      },
      error:(err) =>{

      }
    });
  }

  getActivatedAlarms():void {
    this.hasActivatedLoaded = false;

    this.alarmService.getAllActivatedAlarms().subscribe({
      next:(res) =>{
        this.activatedAlarms = res['$values'];
        this.hasActivatedLoaded = true;
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
