import { Component, OnInit } from '@angular/core';
import { RoomsandtempsService } from '../roomsandtemps.service';
import { Observable } from 'rxjs';
import { Data } from '@angular/router';
import { AppComponent } from '../app.component';
import { Dataclass } from '../Classes/roomandtemp-data';



export class Room {
  Id: number;
  Room: string;
  Temperature: number;
  Timestamp: string;
}

@Component({
  selector: 'app-main-website',
  templateUrl: './main-website.component.html',
  styleUrls: ['./main-website.component.css']
})

export class MainWebsiteComponent implements OnInit {

  displayedColumns = ['Id'];


  constructor(public data:RoomsandtempsService){
  }

  ngOnInit(): void {
  }
}
