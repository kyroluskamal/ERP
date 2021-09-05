import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OwnerBodyComponent } from '../Owners/Components/owner-body/owner-body.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: "owners", component: OwnerBodyComponent },
  { path: "", component: AppComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
