
import {Component, OnInit} from '@angular/core';
import { Alarm } from 'src/app/models/Alarm';

@Component({
  selector: 'app-alarm-display',
  templateUrl: './alarm-display.component.html',
  styleUrls: ['./alarm-display.component.css']
})
export class AlarmDisplayComponent implements OnInit{

  hasLoaded: boolean = false;
  alarms:Alarm[];

  ngOnInit(): void {
    
    // load with websocket usage
    this.loadDummyData();

  }

  constructor(){

  }

  private loadDummyData() {
    this.alarms = [];
    let a1: Alarm = {
      type: 'high',
      timeOfActivation: new Date(),
      measureUnit: "KW"
    };
    this.alarms.push(a1);
    let a2: Alarm = {
      type: 'low',
      timeOfActivation: new Date(),
      measureUnit: "KW"
    };
    this.alarms.push(a2);

    let a3: Alarm = {
      type: 'medium',
      timeOfActivation: new Date(),
      measureUnit: "mA"
    };
    this.alarms.push(a3);
    console.log(this.alarms);
    this.hasLoaded = true;
  }
}
