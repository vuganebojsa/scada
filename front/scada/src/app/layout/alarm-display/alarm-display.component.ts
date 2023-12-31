
import {Component, OnInit} from '@angular/core';
import { HubConnectionBuilder } from '@microsoft/signalr/dist/esm/HubConnectionBuilder';
import { ActivatedAlarm, ActivatedAlarmDTO, Alarm, GetAlarmDTO, GetAlarmsReq } from 'src/app/models/Alarm';
import { AlarmsService } from 'src/app/services/alarms.service';

@Component({
  selector: 'app-alarm-display',
  templateUrl: './alarm-display.component.html',
  styleUrls: ['./alarm-display.component.css']
})
export class AlarmDisplayComponent implements OnInit{

  hasLoaded: boolean = false;
  hasActivatedLoaded:boolean = false;
  alarms:GetAlarmDTO[] = [];
  activatedAlarms:ActivatedAlarm[] = [];
  createdSelected = false;
  ngOnInit(): void {
    
    
    // load with websocket usage
    this.alarmService.createdState$.subscribe({
      next:(result) =>{
        this.createdSelected = false;
        this.getAlarms();
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
      let act: ActivatedAlarmDTO = JSON.parse(from);
      let alarm: Alarm = {
        type:act.Type,
        priority:act.Priority,
        measureUnit:act.MeasureUnit,
        threshold:act.Threshold,
        message:act.Message
      }
      let actalarm: ActivatedAlarm = {
        timeStamp: act.Timestamp,
        alarm:alarm,
        type:alarm.type,
        priority:alarm.priority,
        measureUnit:alarm.measureUnit,
        

      }
      this.activatedAlarms.unshift(actalarm);
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
        console.log(res);

        this.alarms = res.$values;
        this.hasLoaded = true;

        this.getActivatedAlarms();
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
        for(let al of this.activatedAlarms){
          for(let i =0;i<this.alarms.length;i++){
            if(this.alarms[i].alarmId==al.alarmId){
              al.alarm = this.alarms[i];
              break;
            }
          }
        }
        this.hasActivatedLoaded = true;
      },
      error:(err) =>{

      }
    });
  }

  createAlarm():void{
    this.createdSelected = !this.createdSelected;
  }

  deleteAlarm(alarm: GetAlarmDTO):void{
    this.alarmService.deleteAlarm(alarm.alarmId).subscribe({
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
