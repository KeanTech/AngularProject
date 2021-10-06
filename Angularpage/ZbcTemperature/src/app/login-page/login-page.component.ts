import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { RoomsandtempsService } from '../roomsandtemps.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  constructor(public data:RoomsandtempsService, private cookieService: CookieService,
    private router: Router) { }

  currentUser:any

  //Sets the cookie if the login is succesful.
  SetCookie(username:String,password:String){
      this.data.GetValuesForCookie(username,password).subscribe(e=>{
        this.currentUser = e[0]['userName'];
        console.log(this.currentUser)
        this.cookieService.set("zbcRoomInfo",e[0]['password']);
        console.log(e)
    });
  }
  //Checks if the cookie already is created, and if it does you dont need to login. Redirect to main site.
  GetCookie(){
    let cookieValue = this.cookieService.get('zbcRoomInfo'); // To Get Cookie
    if(cookieValue.length > 0){
      this.router.navigate(['./Main']);
      return true;
    }
    else{
      console.log("false")
      return false;
    }
  }
  ngOnInit(): void {
    this.SetCookie("alex","alex");
    this.GetCookie();
  }

}

