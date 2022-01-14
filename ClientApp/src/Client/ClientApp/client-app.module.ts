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
import { ItemsComponentComponent } from './Components/Dashboard/Items/items-component/items-component.component';
import { IconButtonRendererComponent } from './Components/Dashboard/AgFrameworkComponents/button-renderer-component/Icon-button-renderer.component';
import { SelectableEditroAgFramweworkComponent } from './Components/Dashboard/AgFrameworkComponents/selectable-editro-ag-framwework/selectable-editro-ag-framwework.component';
import { NumberCellEditorComponent } from './Components/Dashboard/AgFrameworkComponents/number-cell-editor/number-cell-editor.component';
import { HttpClientXsrfModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandlingInterceptor } from 'src/Interceptors/ErrorHandling/error-handling.interceptor';
import { TokenInterceptorInterceptor } from 'src/Interceptors/TokenInterceptor/token-interceptor.interceptor';
import { RegisterOnAppComponent } from './Components/register-on-app/register-on-app.component';
import { AddNewItemComponent } from './Components/Dashboard/Items/add-new-item/add-new-item.component';
import { InventoriesComponent } from './Components/Dashboard/Inventories/inventories/inventories.component';
import { EditInventoryComponent } from './Components/Dashboard/Inventories/edit-inventory/edit-inventory.component';
import { BadgeComponent } from 'src/CommonComponents/badge/badge.component';
import { StylePaginatorDirective } from 'src/Directives/style-paginator.directive';
import { GenericTableComponent } from 'src/CommonComponents/generic-table/generic-table.component';
import { GenericFormComponent } from '../../CommonComponents/generic-form/generic-form.component';
import { MatCardTitleOnlyComponent } from 'src/CommonComponents/mat-card-title-only/mat-card-title-only.component';
import { AddInventAddressComponent } from './Components/Dashboard/Inventories/InventoryAddress/add-invent-address/add-invent-address.component';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { EditInventAddressComponent } from './Components/Dashboard/Inventories/InventoryAddress/edit-invent-address/edit-invent-address.component';
import { AddNewInventoryComponent } from './Components/Dashboard/Inventories/add-new-inventory/add-new-inventory.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { SuppliersComponent } from './Components/Dashboard/Suppliers/suppliers/suppliers.component';
import { AddNewSupplierComponent } from './Components/Dashboard/Suppliers/add-new-supplier/add-new-supplier.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { EditSupplierComponent } from './Components/Dashboard/Suppliers/edit-supplier/edit-supplier.component';
import { AddNewItemBrandComponent } from './Components/Dashboard/Items/item-brands/add-new-item-brand/add-new-item-brand.component';
import { EditItemBrandComponent } from './Components/Dashboard/Items/item-brands/edit-item-brand/edit-item-brand.component';
import { ItemBrandsComponent } from './Components/Dashboard/Items/item-brands/item-brands/item-brands.component';
import { ItemUnitsComponent } from './Components/Dashboard/Items/item-units/item-units/item-units.component';
import { AddNewItemUnitsComponent } from './Components/Dashboard/Items/item-units/add-new-item-units/add-new-item-units.component';
import { EditItemUnitsComponent } from './Components/Dashboard/Items/item-units/edit-item-units/edit-item-units.component';
import { ItemCategoriesComponent } from './Components/Dashboard/Items/item-main-categories/item-categories/item-categories.component';
import { AddNewMainCatComponent } from './Components/Dashboard/Items/item-main-categories/add-new-main-cat/add-new-main-cat.component';
import { AddNewSubCatComponent } from './Components/Dashboard/Items/item-main-categories/add-new-sub-cat/add-new-sub-cat.component';
import { EditSubCatComponent } from './Components/Dashboard/Items/item-main-categories/edit-sub-cat/edit-sub-cat.component';
import { EditMainCatComponent } from './Components/Dashboard/Items/item-main-categories/edit-main-cat/edit-main-cat.component';
import { GenericStepperComponent } from 'src/CommonServices/generic-stepper/generic-stepper.component';


const Commponents = [MatCardTitleOnlyComponent, GenericStepperComponent,
  ClientAppDashboardComponent, ClientAppHomeNavbarComponent, CLientAppHomeComponent,
  ClientDashboardHomeComponent, BadgeComponent, GenericTableComponent, GenericFormComponent,
  ItemsComponentComponent, IconButtonRendererComponent,
  SelectableEditroAgFramweworkComponent, NumberCellEditorComponent,
  RegisterOnAppComponent, AddNewItemComponent, InventoriesComponent, ItemBrandsComponent,
  EditInventoryComponent, StylePaginatorDirective, AddInventAddressComponent, EditInventAddressComponent,
  AddNewInventoryComponent, SuppliersComponent, AddNewItemBrandComponent, EditItemBrandComponent,
  AddNewSupplierComponent, EditSupplierComponent, ItemUnitsComponent, AddNewItemUnitsComponent, EditItemUnitsComponent];
@NgModule({
  declarations: [Commponents, ItemCategoriesComponent, AddNewMainCatComponent, AddNewSubCatComponent, EditSubCatComponent, EditMainCatComponent],
  imports: [BreadcrumbModule, SweetAlert2Module, NgxSpinnerModule,
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
