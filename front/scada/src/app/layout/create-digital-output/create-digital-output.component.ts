import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TagsService } from 'src/app/services/tags.service';

@Component({
  selector: 'app-create-digital-output',
  templateUrl: './create-digital-output.component.html',
  styleUrls: ['./create-digital-output.component.css']
})
export class CreateDigitalOutputComponent {
  digitalOutput = new FormGroup({

    email: new FormControl('', [Validators.required, Validators.email]),
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    surname: new FormControl('', [Validators.required, Validators.minLength(3)]),
    password: new FormControl('', [Validators.required, Validators.minLength(10)]),
    birthDate: new FormControl('', [Validators.required]),
    username: new FormControl('', [Validators.required, Validators.minLength(3)])
  });

  constructor(private tagService: TagsService)
  {

  }
  createDigitalOutputTag():void{

  }
}
