import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router'; // CLI imports router
import { AppComponent } from './app.component';
import { MainWebsiteComponent } from './main-website/main-website.component';
import { HttpClientModule } from '@angular/common/http';
import { NgxJsonViewModule } from 'ng-json-view';
import { CookieService } from 'ngx-cookie-service';
import { FormsModule } from '@angular/forms'

/*----------------------------------------/*
/*Material imports */
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { LoginPageComponent } from './login-page/login-page.component';
import { MatInputModule } from '@angular/material/input';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

//All possible routes in the application.
const routes: Routes = [
  { path: 'Main', component: MainWebsiteComponent},
  { path: '', component: LoginPageComponent},
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
    FormsModule,
    /* Material import and exports */
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    MatListModule,
    MatGridListModule,
    MatTableModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  exports: [MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    MatListModule,
    MatGridListModule,
    MatTableModule,
    MatIconModule,
    MatFormFieldModule ],

  providers: [CookieService],
  bootstrap: [AppComponent],
})
export class AppModule {}
