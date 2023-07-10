import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateAlarmDTO } from 'src/app/models/Alarm';
import { AnalogInput, AnalogInputForDisplay } from 'src/app/models/Tags';
import { AlarmsService } from 'src/app/services/alarms.service';
import { TagsService } from 'src/app/services/tags.service';

@Component({
  selector: 'app-create-alarm',
  templateUrl: './create-alarm.component.html',
  styleUrls: ['./create-alarm.component.css']
})
export class CreateAlarmComponent implements OnInit{
  alarmFg = new FormGroup({
    priority: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(3)]),
    message: new FormControl('', [Validators.required, Validators.minLength(3)]),
    threshold: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(8)]),
    type: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(4)]),
    analogTag: new FormControl('', [Validators.required])
  });
  selectedAnalogTag:'';
  selectedPriority = 1;
  selectedType = "Low";
  analogTags: AnalogInputForDisplay[];
  hasLoaded = false;

  constructor(private tagService: TagsService, private alarmService: AlarmsService)
  {

  }
  ngOnInit(): void {
    this.tagService.getanalogInputTags().subscribe({
      next:(res) =>{
        this.analogTags = res['$values'];
        console.log(this.analogTags);
        this.hasLoaded = true;
      }
    });
  }

  createAlarm():void{
    if(!this.alarmFg.valid){
      alert('Invalid fields. please try again.')
      return;
    }

    let alarm: CreateAlarmDTO = {
      message:this.alarmFg.value.message,
      threshold:Number(this.alarmFg.value.threshold),
      analogId:Number(this.selectedAnalogTag.split(' ')[0]),
      priority:this.selectedPriority,
      type:this.selectedType
    };

    this.alarmService.createAlarm(alarm).subscribe({
      next:(result) =>{
        alert('Successfully created an alarm for ' + this.selectedAnalogTag.split(' ')[1] + ' tag' );
        this.alarmService.setCreated();
      },
      error:(err) =>{
        alert(err['error']);
      }
    })
    
  }
}
