import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/SharedModules/shared/shared.module';
import { MaterialModule } from 'src/SharedModules/material/material.module';
import { ClientAppDashboardComponent } from './Components/Dashboard/client-app-dashboard/client-app-dashboard.component';
import { ClientAppRoutingModule } from './client-app-routing.module';
import { ClientAppHomeNavbarComponent } from './Components/ClientAppHome/client-app-home-navbar/client-app-home-navbar.component';
import { ClientAppLoginComponent } from './Components/client-app-login/client-app-login.component';
import { ClientAppRegisterComponent } from './Components/client-app-register/client-app-register.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { CLientAppHomeComponent } from './Components/ClientAppHome/client-app-home/client-app-home.component';
import { ClientDashboardHomeComponent } from './Components/Dashboard/client-dashboard-home/client-dashboard-home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ItemMainCategoriesComponent } from './Components/Dashboard/Items/item-main-categories/item-main-categories.component';
import { ItemsComponentComponent } from './Components/Dashboard/Items/items-component/items-component.component';
import { IconButtonRendererComponent } from './Components/Dashboard/AgFrameworkComponents/button-renderer-component/Icon-button-renderer.component';
import { SelectableEditroAgFramweworkComponent } from './Components/Dashboard/AgFrameworkComponents/selectable-editro-ag-framwework/selectable-editro-ag-framwework.component';
import { ItemUnitsComponent } from './Components/Dashboard/Items/item-units/item-units.component';
import { NumberCellEditorComponent } from './Components/Dashboard/AgFrameworkComponents/number-cell-editor/number-cell-editor.component';
import { ItemBrandsComponent } from './Components/Dashboard/Items/item-brands/item-brands.component';
import { LoginOnAppComponent } from './Components/Dashboard/login-on-app/login-on-app.component';
import { HttpClientXsrfModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandlingInterceptor } from 'src/Interceptors/ErrorHandling/error-handling.interceptor';
import { TokenInterceptorInterceptor } from 'src/Interceptors/TokenInterceptor/token-interceptor.interceptor';


const Commponents = [
  ClientAppDashboardComponent, ClientAppHomeNavbarComponent, CLientAppHomeComponent,
  ClientAppLoginComponent, ClientAppRegisterComponent, ClientDashboardHomeComponent,
  ItemMainCategoriesComponent, ItemsComponentComponent, IconButtonRendererComponent,
  SelectableEditroAgFramweworkComponent, ItemUnitsComponent, NumberCellEditorComponent,
  ItemBrandsComponent, LoginOnAppComponent
]
@NgModule({
  declarations: [Commponents],
  imports: [
    SharedModule, MaterialModule, ClientAppRoutingModule, CommonModule, AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientXsrfModule.withOptions({
      cookieName: 'XSRF-TOKEN',
      headerName: 'scfD1z5dp2',
    })
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorHandlingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorInterceptor, multi: true },

  ],
  exports: [Commponents]
})
export class ClientAppModule { }
