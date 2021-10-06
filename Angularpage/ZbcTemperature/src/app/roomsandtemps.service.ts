import { Injectable } from '@angular/core';
import { HttpClient, HttpResponseBase } from '@angular/common/http';
import { Dataclass } from './Classes/roomandtemp-data';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root',
})
export class RoomsandtempsService {
  data: any;

  constructor(private http: HttpClient, private cookieService: CookieService) {}

  GetData() {
    const url = 'https://localhost:44361/Temperature';
    return this.http.get<Dataclass>(url);
  }

  //hvis der kan blive sendt afsted fra api'et navn og value som streng/json istedet for hele cookie,
  //kan cookien oprettes i angular istedet.

  GetCookie() {
    const url = 'https://localhost:44361/Login?username=alex&password=alex';
    console.log('Request is sent!');
    this.http.get(url).subscribe(
      (response:HttpResponseBase) => {
        return response.headers.getAll('Cookie Value')
      }
    );
  }



}
