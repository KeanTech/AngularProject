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

  username:string
  password:string

  //Sets the cookie if the login is succesful.
  SetCookie(){
      this.data.GetValuesForCookie(this.username,this.password).subscribe(e=>{
        /*
        let temp = [e[0]['userName'],[e[0]['password']]]
        console.log(temp)
        */
        this.cookieService.set("zbcRoomInfo",e[0]['password']);
        console.log(e)
    });
  }
  //Checks if the cookie already is created, and if it does you dont need to login. Redirect to main site.
  GetCookie(){
    let cookieValue = this.cookieService.get('zbcRoomInfo'); // To Get Cookie
    if(cookieValue.length > 5){
      this.router.navigate(['./Main']);
      return true;
    }
    else{
      console.log("false")
      return false;
    }
  }
  ngOnInit(): void {
    this.GetCookie();
  }

}

