import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/security/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginForm = new FormGroup(
    {
      email: new FormControl('', [Validators.required, Validators.minLength(4)]),
      password: new FormControl('', [Validators.required, Validators.minLength(4)])
    }
  );
  hasError = false;


  constructor(private router:Router,
    private authenticationService: AuthenticationService){}


   
  login(){
    if(!this.loginForm.valid) {this.hasError = true; return;}
    else this.hasError = false;
    
    let email:string | null | undefined = this.loginForm.value.email;
    let password:string | null | undefined = this.loginForm.value.password;
    
    this.authenticationService.login(email, password).subscribe({
      next:(result) =>{
        localStorage.setItem('user', JSON.stringify(result["role"]));
        this.router.navigate(['home']);
      },
      error:(err) =>{
        alert(err.error.message);
      }
    })
    

  }

}
