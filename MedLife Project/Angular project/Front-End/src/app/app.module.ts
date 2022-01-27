import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminPageModule } from './admin-page/admin-page.module';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DoctorPageModule } from './doctor-page/doctor-page.module';
import { PatientPageModule } from './patient-page/patient-page.module';
import { AuthInterceptor } from './shared/auth.interceptor';
import { ApiService } from './shared/Services/api.service';
import { SharedModule } from './shared/shared.module';


@NgModule({
  declarations: [
    AppComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    AdminPageModule,
    PatientPageModule,
    DoctorPageModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatDialogModule,
    BrowserAnimationsModule,

  ],
  providers: [ApiService,{

    provide: HTTP_INTERCEPTORS,

    useClass: AuthInterceptor,

    multi: true

}],
  bootstrap: [AppComponent]
})
export class AppModule { }
