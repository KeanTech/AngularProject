import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainWebsiteComponent } from './main-website/main-website.component';
/*----------------------------------------/*
/*Material imports */
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [AppComponent, MainWebsiteComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: /*Default route*/ '', component: MainWebsiteComponent },
    ]),
    BrowserAnimationsModule,
    /* Material import and exports */
    MatCardModule,
    MatToolbarModule,
  ],
  exports: [MatCardModule, MatToolbarModule],

  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
