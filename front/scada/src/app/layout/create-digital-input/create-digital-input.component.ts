import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DigitalInputDTO } from 'src/app/models/Tags';
import { TagsService } from 'src/app/services/tags.service';

@Component({
  selector: 'app-create-digital-input',
  templateUrl: './create-digital-input.component.html',
  styleUrls: ['./create-digital-input.component.css']
})
export class CreateDigitalInputComponent {

  digitalInput = new FormGroup({
    tagName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    description: new FormControl('', [Validators.required, Validators.minLength(3)]),
    initialValue: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(1)]),
    scanTime: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(8)]),
  });

  constructor(private tagService: TagsService)
  {

  }
  createDigitalInputTag():void{
    if(!this.digitalInput.valid){
      alert('Please fulfill al the fields corectly');
      return;
    }
    let digin: DigitalInputDTO = {
      tagName: this.digitalInput.value.tagName,
      description: this.digitalInput.value.description,
      initialValue: Number(this.digitalInput.value.initialValue),
      scanTime: Number(this.digitalInput.value.scanTime),
    }

    this.tagService.createDigitalInputTag(digin).subscribe({
      next:(res) =>{
        alert('Successfully created a tag with name: ' + this.digitalInput.value.tagName)
        this.tagService.setCreated();
      },
      error:(err) =>{
        alert(err['error']);
      }
    })
  }
}
