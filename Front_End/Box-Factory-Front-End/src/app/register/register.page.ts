import {Component} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";

@Component({
  selector: 'app-register',
  templateUrl: 'register.page.html',
  styleUrls: ['register.page.scss'],
})

export class RegisterPage {
  usernameInput = new FormControl('', Validators.required);
  emailInput = new FormControl('', Validators.required);
  passwordInput = new FormControl('', Validators.required);

  formGroup = new FormGroup({
    username: this.usernameInput,
    email: this.emailInput,
    password: this.passwordInput
  });

  constructor(private http: HttpClient) {

  }

  async register(){

  }

  navigateToLogin(){
    
  }
}
