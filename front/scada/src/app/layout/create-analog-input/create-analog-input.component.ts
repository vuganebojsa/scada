import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AnalogInput, AnalogInputDto } from 'src/app/models/Tags';
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
    if(this.createForm.valid){
      const aiTag: AnalogInputDto = {
        tagName : this.createForm.value.tagName,
        description : this.createForm.value.description,
        units : this.createForm.value.units,
        currentValue : Number(this.createForm.value.currentValue),
        lowLimit: Number(this.createForm.value.lowLimit),
        highLimit : Number(this.createForm.value.highLimit),
        scanTime: this.createForm.value.scanTime
      };
      if (aiTag.lowLimit > aiTag.highLimit){
        alert("Low limit can not be higher than high limit!");
      }
      else if(aiTag.currentValue > aiTag.highLimit){
        alert("Current value can not be higher than high limit!")
      }
      else if(aiTag.currentValue < aiTag.lowLimit){
        alert("Current value can not be lower than low limit!")
      }
      else{
      this.tagService.createAITag(aiTag).subscribe(
        {
          next: (result) => {
            alert('Successfully created AI tag');
  
            console.log(result);
          },
          error: (error) => {
            alert(error);
            console.log(error);
          }
        }
      );
  }
}
}
}
