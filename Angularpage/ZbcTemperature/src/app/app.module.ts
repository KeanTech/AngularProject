import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainWebsiteComponent } from './main-website/main-website.component';
import { HttpClientModule } from '@angular/common/http';
import { NgxJsonViewModule } from 'ng-json-view';
/*----------------------------------------/*
/*Material imports */
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatListModule} from '@angular/material/list';
import {MatGridListModule} from '@angular/material/grid-list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';
import { LoginPageComponent } from './login-page/login-page.component';


@NgModule({
  declarations: [AppComponent, MainWebsiteComponent, LoginPageComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgxJsonViewModule,
    RouterModule.forRoot([
      { path: /*Default route*/ '', component: MainWebsiteComponent },
    ]),
    BrowserAnimationsModule,
    /* Material import and exports */
    MatCardModule,
    MatToolbarModule,
    MatListModule,
    MatGridListModule,
    MatTableModule,
  ],
  exports: [MatCardModule, MatToolbarModule],

  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
