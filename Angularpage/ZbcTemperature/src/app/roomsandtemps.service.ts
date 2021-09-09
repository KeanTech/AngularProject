import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Data } from '@angular/router';
import { Dataclass } from './Classes/roomandtemp-data';

export class Room {
  Id: number;
  Room: string;
  Temperature: number;
  TimeStamp: string;
}

@Injectable({
  providedIn: 'root',
})
export class RoomsandtempsService {
  private data: Room;

  constructor(private http: HttpClient) {}
  /*
  getData(){
    let url = "http://localhost:61950/api/values?id=0";
    console.log(this.http.get(url));
    return this.http.get(url);
  }
  */
  async getData() {
    const url = 'http://localhost:61950/api/values?id=0';
    let test = this.http.get<Room>(url);
    test.subscribe(e=>{
      this.data = e[0];
      console.log(this.data)
    })
  }
}
