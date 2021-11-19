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


const Commponents = [
  ClientAppDashboardComponent, ClientAppHomeNavbarComponent, CLientAppHomeComponent,
  ClientAppLoginComponent, ClientAppRegisterComponent, ClientDashboardHomeComponent,
  ItemMainCategoriesComponent, ItemsComponentComponent, IconButtonRendererComponent
]
@NgModule({
  declarations: [Commponents, SelectableEditroAgFramweworkComponent, ItemUnitsComponent, NumberCellEditorComponent],
  imports: [
    SharedModule, MaterialModule, ClientAppRoutingModule, CommonModule, AppRoutingModule,
    BrowserAnimationsModule
  ],
  exports: [Commponents]
})
export class ClientAppModule { }
