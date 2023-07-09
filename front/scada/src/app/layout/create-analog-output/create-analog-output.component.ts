import { Component } from '@angular/core';
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {TagsService} from "../../services/tags.service";
import {AnalogOutput} from "../../models/Tags";

@Component({
  selector: 'app-create-analog-output',
  templateUrl: './create-analog-output.component.html',
  styleUrls: ['./create-analog-output.component.css']
})
export class CreateAnalogOutputComponent {
  analogOutputForm = new FormGroup({

    tagName: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    initialValue: new FormControl('', [Validators.required]),
    lowLimit: new FormControl('', [Validators.required]),
    highLimit: new FormControl('', [Validators.required]),
    units: new FormControl('', [Validators.required])
  });

  constructor(private router: Router, private tagService: TagsService)
  {

  }



  ngOnInit() {
    // Adding the custom validators to the form controls
  }


  create():void{

    if(this.analogOutputForm.valid){
      let newAnalogOutput: AnalogOutput = {
        currentValue: Number(this.analogOutputForm.value.initialValue),
        tagName: this.analogOutputForm.value.tagName,
        description: this.analogOutputForm.value.description,
        initialValue: Number(this.analogOutputForm.value.initialValue),
        lowLimit: Number(this.analogOutputForm.value.lowLimit),
        highLimit: Number(this.analogOutputForm.value.highLimit),
        units: this.analogOutputForm.value.units,
        ioAddress: ""
      }
      if (newAnalogOutput.lowLimit > newAnalogOutput.highLimit){
        alert("Low limit can not be higher than high limit!");
      }
      else if(newAnalogOutput.initialValue> newAnalogOutput.highLimit){
        alert("Current value can not be higher than high limit!")
      }
      else if(newAnalogOutput.initialValue < newAnalogOutput.lowLimit){
        alert("Current value can not be lower than low limit!")
      }
      else{
        this.tagService.createAOTag(newAnalogOutput).subscribe(
          {
            next: (result) => {
              alert('Successfully created AI tag');
              this.tagService.setCreated();
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
