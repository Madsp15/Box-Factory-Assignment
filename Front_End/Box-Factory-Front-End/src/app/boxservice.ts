import {Injectable} from "@angular/core";
import {Box} from "./home/home.page";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})

export class BoxService{
  boxes: Box[] = [];
  private SearchAPI = '/api/inventory/search';

  constructor(private http: HttpClient) {}

  searchBoxes(query: string): Observable<Box[]> {
    return this.http.get<Box[]>(`${this.SearchAPI}?query=${query}`);
  }
}
