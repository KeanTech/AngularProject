import { Component, OnInit } from '@angular/core';
import { RoomsandtempsService } from '../roomsandtemps.service';
import { Observable } from 'rxjs';
import { Data } from '@angular/router';
import { AppComponent } from '../app.component';
import { NgxJsonViewModule } from 'ng-json-view';

export interface Room {
  Name: string;
  Temperature: number;
}
/*
const RoomData: Room[] = [
  {Name: 'H.01', Temperature: 23.1},
  {Name: 'H.02', Temperature: 24.1},
];
*/


var appComp:AppComponent;
let roomData: string[];


@Component({
  selector: 'app-main-website',
  templateUrl: './main-website.component.html',
  styleUrls: ['./main-website.component.css']
})


export class MainWebsiteComponent implements OnInit {

  roomData = appComp.GetData();
  data = roomData;
  displayedColumns = ['Name', 'Temperature'];

  ngOnInit(): void {
  }
}
