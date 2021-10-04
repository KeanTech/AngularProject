import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Data } from '@angular/router';
import { Dataclass } from './Classes/roomandtemp-data';

@Injectable({
  providedIn: 'root',
})
export class RoomsandtempsService {
  data: any;

  constructor(private http: HttpClient) {}

  GetData() {
    const url = 'https://localhost:44361/Temperature';
    return this.http.get<Dataclass>(url);
  }
}
