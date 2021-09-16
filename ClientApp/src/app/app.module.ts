import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../SharedModules/material/material.module';
import { SharedModule } from '../SharedModules/shared/shared.module';
import { OwnerModule } from '../Owners/owner.module';
import { CommonModule, Location } from '@angular/common';
import { ClientModule } from '../Client/client.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandlingInterceptor } from '../Interceptors/ErrorHandling/error-handling.interceptor';
import { NotFoundComponent } from '../CommonComponents/not-found/not-found.component';
import { TokenInterceptorInterceptor } from '../Interceptors/TokenInterceptor/token-interceptor.interceptor';
import { CommoneResetPasswordComponent } from '../CommonComponents/commone-reset-password/commone-reset-password.component';

@NgModule({
  declarations: [
    AppComponent, NotFoundComponent,  CommoneResetPasswordComponent
  ],
  imports: [
    BrowserModule, AppRoutingModule, BrowserAnimationsModule,
    MaterialModule, SharedModule, OwnerModule, CommonModule, ClientModule  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorHandlingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  exports: [NotFoundComponent]
})
export class AppModule { }
