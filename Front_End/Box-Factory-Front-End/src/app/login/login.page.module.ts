import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {IonicModule} from "@ionic/angular";
import {LoginPage} from "./login.page";
import {FormControl, ReactiveFormsModule} from "@angular/forms";


@NgModule({
  declarations: [LoginPage],
  imports: [
    CommonModule, IonicModule, FormControl, ReactiveFormsModule
  ]
})
export class LoginPageModule { }
