import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AlarmsService } from 'src/app/services/alarms.service';
import { TagsService } from 'src/app/services/tags.service';

@Component({
  selector: 'app-create-alarm',
  templateUrl: './create-alarm.component.html',
  styleUrls: ['./create-alarm.component.css']
})
export class CreateAlarmComponent implements OnInit{
  alarmFg = new FormGroup({
    tagName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    description: new FormControl('', [Validators.required, Validators.minLength(3)]),
    initialValue: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(1)]),
    scanTime: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(8)]),
  });


  constructor(private tagService: TagsService, private alarmService: AlarmsService)
  {

  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  createAlarm():void{
    
  }
}
