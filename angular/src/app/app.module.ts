import { CleverBitInterceptor } from './interceptors/cleverbit-interceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import CleverbitAuthGuard from './auth/cleverbit-guard-auth';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NoopAnimationsModule,
    MatTableModule,
    MatGridListModule,
    MatCardModule,
    MatButtonModule,
    
  ],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: CleverBitInterceptor, multi: true}, CleverbitAuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
