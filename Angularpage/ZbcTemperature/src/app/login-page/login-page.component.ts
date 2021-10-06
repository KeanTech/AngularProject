import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RoomsandtempsService } from '../roomsandtemps.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  constructor(public data:RoomsandtempsService) { }

  ngOnInit(): void {
    console.log(this.data.GetCookie())
  }

  }

