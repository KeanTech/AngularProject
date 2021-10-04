import { Component, OnInit } from '@angular/core';
import { RoomsandtempsService } from '../roomsandtemps.service';
import { Observable, ObservedValueOf } from 'rxjs';
import { Data } from '@angular/router';
import { AppComponent } from '../app.component';
import { Dataclass } from '../Classes/roomandtemp-data';
import { NgModule } from '@angular/core';
import { Variable } from '@angular/compiler/src/render3/r3_ast';





@Component({
  selector: 'app-main-website',
  templateUrl: './main-website.component.html',
  styleUrls: ['./main-website.component.css']
})

export class MainWebsiteComponent implements OnInit {


  displayData : any;
  displayedColumns = ['Id','Roomname','Temperature','Timestamp'];

  constructor(public data:RoomsandtempsService){
  }

  GetData(){
    this.data.GetData().subscribe(e=>{
      this.displayData = e;
    });
  }

  ngOnInit(): void {
    this.data.GetData().subscribe(e=>{
      this.displayData = e;
    });
  }
}
