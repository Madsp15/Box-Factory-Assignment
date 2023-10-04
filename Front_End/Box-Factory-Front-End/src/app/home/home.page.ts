import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BoxService} from "../boxservice";
import {firstValueFrom} from "rxjs";

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(private http: HttpClient, public service: BoxService) {
    this.getData();
  }

  async getData(){
    const call = this.http.get<Box[]>('http://localhost:5054/api/inventory');
    const result = await firstValueFrom<Box[]>(call);
    this.service.boxes = result;
  }




}

export interface Box{
  id: number,
  width: number,
  length: number,
  height: number,
  volume: number,
  material: string,
  inventoryCount: number,
  price: number
}
