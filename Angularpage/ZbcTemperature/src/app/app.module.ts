import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router'; // CLI imports router
import { AppComponent } from './app.component';
import { MainWebsiteComponent } from './main-website/main-website.component';
import { HttpClientModule } from '@angular/common/http';
import { NgxJsonViewModule } from 'ng-json-view';

/*----------------------------------------/*
/*Material imports */
import { MatCardModule } from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatListModule} from '@angular/material/list';
import {MatGridListModule} from '@angular/material/grid-list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';
import { LoginPageComponent } from './login-page/login-page.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', component: MainWebsiteComponent},
  { path: 'Loginpage', component: LoginPageComponent},
  //Page not found
  { path: '**', component: PageNotFoundComponent}
];

@NgModule({
  declarations: [AppComponent, MainWebsiteComponent, LoginPageComponent, PageNotFoundComponent],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    HttpClientModule,
    NgxJsonViewModule,
    BrowserAnimationsModule,
    /* Material import and exports */
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    MatListModule,
    MatGridListModule,
    MatTableModule,
    MatIconModule,
  ],
  exports: [MatCardModule, MatToolbarModule],

  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
