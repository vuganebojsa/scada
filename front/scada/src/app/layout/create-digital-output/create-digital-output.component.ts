import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TagsService } from 'src/app/services/tags.service';
import { DigitalOutputDTO } from 'src/app/models/Tags';
@Component({
  selector: 'app-create-digital-output',
  templateUrl: './create-digital-output.component.html',
  styleUrls: ['./create-digital-output.component.css']
})
export class CreateDigitalOutputComponent {
  digitalOutput = new FormGroup({
    tagName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    description: new FormControl('', [Validators.required, Validators.minLength(3)]),
    initialValue: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(1)]),
  });

  constructor(private tagService: TagsService)
  {

  }
  createDigitalOutputTag():void{
    if(!this.digitalOutput.valid){
      alert('Please fulfill al the fields corectly');
      return;
    }
    let digout: DigitalOutputDTO = {
      tagName: this.digitalOutput.value.tagName,
      description: this.digitalOutput.value.description,
      initialValue: Number(this.digitalOutput.value.initialValue),
    }

    this.tagService.createDigitalOutputTag(digout).subscribe({
      next:(res) =>{
        alert('Successfully created a tag with name: ' + this.digitalOutput.value.tagName)
        this.tagService.setCreated();
      },
      error:(err) =>{
        alert(err['error']);
      }
    })
  }
}
