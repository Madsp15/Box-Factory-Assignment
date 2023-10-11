import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BoxService} from "../boxservice";
import {firstValueFrom, Subject} from "rxjs";
import {Router} from "@angular/router";




@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  searchQuery: string = '';
  searchResults: Box[] = [];
  private searchTerms = new Subject<string>();


  constructor(private http: HttpClient, public service: BoxService, private router: Router) {
    this.getData();
  }


  async getData() {
    if (this.searchQuery) {
      // If there is a search query, use it to construct the URL
      const url = `http://localhost:5054/api/inventory/search?q=${this.searchQuery}`;
      const call = this.http.get<Box[]>(url);
      const result = await firstValueFrom<Box[]>(call);
      this.service.boxes = result;
    } else {
      // If there is no search query, use the default URL
      const call = this.http.get<Box[]>('http://localhost:5054/api/inventory');
      const result = await firstValueFrom<Box[]>(call);
      this.service.boxes = result;
    }
  }

  clickCreateBox() {
    this.router.navigate(["home/create-box"])
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
  name: string;
}
