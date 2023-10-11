import { Component } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: 'login.page.html',
  styleUrls: ['login.page.scss'],
})

export class LoginPage{
  usernameInput = new FormControl('', Validators.required);
  passwordInput = new FormControl('', Validators.required);

  formGroup = new FormGroup({
    username: this.usernameInput,
    password: this.passwordInput
  });

  constructor(private http: HttpClient) {

  }

  async login(){
    const call = this.http.post('http://localhost:5054/api/boxes/login', this.formGroup.value);
    //const result = await firstValueFrom<boolean>(call);

    if(!call){

    }

  }

  navigateToRegister(){

  }
}
