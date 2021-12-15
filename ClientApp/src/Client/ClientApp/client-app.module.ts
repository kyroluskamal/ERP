import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/SharedModules/shared/shared.module';
import { MaterialModule } from 'src/SharedModules/material/material.module';
import { ClientAppDashboardComponent } from './Components/Dashboard/client-app-dashboard/client-app-dashboard.component';
import { ClientAppRoutingModule } from './client-app-routing.module';
import { ClientAppHomeNavbarComponent } from './Components/ClientAppHome/client-app-home-navbar/client-app-home-navbar.component';
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
import { HttpClientXsrfModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandlingInterceptor } from 'src/Interceptors/ErrorHandling/error-handling.interceptor';
import { TokenInterceptorInterceptor } from 'src/Interceptors/TokenInterceptor/token-interceptor.interceptor';
import { RegisterOnAppComponent } from './Components/register-on-app/register-on-app.component';
import { AddNewItemComponent } from './Components/Dashboard/Items/add-new-item/add-new-item.component';
import { InventoriesComponent } from './Components/Dashboard/Inventories/inventories/inventories.component';
import { AddNewInventoryAddressComponent } from './Components/Dashboard/Inventories/add-new-inventory-address/add-new-inventory-address.component';
import { EditInventoryComponent } from './Components/Dashboard/Inventories/edit-inventory/edit-inventory.component';
import { BadgeComponent } from 'src/CommonComponents/badge/badge.component';
import { StylePaginatorDirective } from 'src/Directives/style-paginator.directive';
import { GenericTableComponent } from 'src/CommonComponents/generic-table/generic-table.component';
import { GenericFormComponent } from '../../CommonComponents/generic-form/generic-form.component';
import { MatCardTitleOnlyComponent } from 'src/CommonComponents/mat-card-title-only/mat-card-title-only.component';
import { AddInventAddressComponent } from './Components/Dashboard/Inventories/add-invent-address/add-invent-address.component';

const Commponents = [MatCardTitleOnlyComponent,
  ClientAppDashboardComponent, ClientAppHomeNavbarComponent, CLientAppHomeComponent,
  ClientDashboardHomeComponent, BadgeComponent, GenericTableComponent, GenericFormComponent,
  ItemMainCategoriesComponent, ItemsComponentComponent, IconButtonRendererComponent,
  SelectableEditroAgFramweworkComponent, ItemUnitsComponent, NumberCellEditorComponent,
  ItemBrandsComponent, RegisterOnAppComponent, AddNewItemComponent, InventoriesComponent,
  AddNewInventoryAddressComponent, EditInventoryComponent, StylePaginatorDirective]
@NgModule({
  declarations: [Commponents, AddInventAddressComponent],
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
  exports: [Commponents],

})
export class ClientAppModule { }
