import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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


  GetValuesForCookie(username:String,password:String) {
    const url = 'https://localhost:44361/Login?username='+username+'&password='+password;
    console.log('Request is sent!');
    return this.http.get(url);
  }



}
