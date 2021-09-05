import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../SharedModules/material/material.module';
import { SharedModule } from '../SharedModules/shared/shared.module';
import { OwnerModule } from '../Owners/owner.module';
import { CommonModule } from '@angular/common';
import { ClientModule } from '../Client/client.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule, AppRoutingModule, BrowserAnimationsModule,
    MaterialModule, SharedModule, OwnerModule, CommonModule, ClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
