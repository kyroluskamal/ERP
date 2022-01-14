import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../SharedModules/material/material.module';
import { SharedModule } from '../SharedModules/shared/shared.module';
import { OwnerModule } from '../Owners/owner.module';
import { CommonModule } from '@angular/common';
import { ClientModule } from '../Client/client.module';
import { HttpClient, HttpClientXsrfModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandlingInterceptor } from '../Interceptors/ErrorHandling/error-handling.interceptor';
import { NotFoundComponent } from '../CommonComponents/not-found/not-found.component';
import { TokenInterceptorInterceptor } from '../Interceptors/TokenInterceptor/token-interceptor.interceptor';
import { CommoneResetPasswordComponent } from '../CommonComponents/commone-reset-password/commone-reset-password.component';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { ClientAppModule } from 'src/Client/ClientApp/client-app.module';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
  declarations: [
    AppComponent, NotFoundComponent, CommoneResetPasswordComponent,
  ],
  imports: [FontAwesomeModule,
    BrowserModule, BrowserAnimationsModule, MaterialModule, SharedModule, NgxSpinnerModule,
    OwnerModule, CommonModule, ClientModule, ClientAppModule, AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: httpTranslateLoader,
        deps: [HttpClient]
      }
    }),
    HttpClientXsrfModule.withOptions({
      cookieName: 'XSRF-TOKEN',
      headerName: 'scfD1z5dp2',
    }),
    SweetAlert2Module.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorHandlingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorInterceptor, multi: true },

  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent],
  exports: [NotFoundComponent, FontAwesomeModule]
})
export class AppModule { }
// AOT compilation support
export function httpTranslateLoader(http: HttpClient)
{
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}
