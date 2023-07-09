import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TagsService } from 'src/app/services/tags.service';

@Component({
  selector: 'app-create-analog-input',
  templateUrl: './create-analog-input.component.html',
  styleUrls: ['./create-analog-input.component.css']
})
export class CreateAnalogInputComponent {


  createForm = new FormGroup({
    tagName: new FormControl('', [Validators.required, Validators.minLength(1)]),
    description: new FormControl('', [Validators.required]),
    units: new FormControl('', [Validators.required]),
    currentValue: new FormControl('', [Validators.required]),
    scanTime: new FormControl('', [Validators.required]),
    lowLimit: new FormControl('', [Validators.required]),
    highLimit: new FormControl('', [Validators.required])

  });
  
  constructor( private tagService: TagsService, ){

  }

  createAi():void{

  }
}
