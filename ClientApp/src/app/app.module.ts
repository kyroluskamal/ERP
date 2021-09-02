import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../SharedModules/material/material.module';
import { SharedModule } from '../SharedModules/shared/shared.module';
import { NavBarComponent } from '../CommonComponents/nav-bar/nav-bar.component';
import { LoginComponent } from '../CommonComponents/login/login.component';
import { RegisterComponent } from '../CommonComponents/register/register.component';
import { OwnersLoginComponent } from '../Owners/Components/owners-login/owners-login.component';
import { OwnerRegisterComponent } from '../Owners/Components/owner-register/owner-register.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    LoginComponent,
    RegisterComponent,
    OwnersLoginComponent,
    OwnerRegisterComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    SharedModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
