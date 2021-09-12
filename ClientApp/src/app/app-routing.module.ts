import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientMainComponent } from '../Client/Components/client-main/client-main.component';
import { NotFoundComponent } from '../CommonComponents/not-found/not-found.component';
import { ServerErrorComponent } from '../CommonComponents/server-error/server-error.component';
import { OwnerBodyComponent } from '../Owners/Components/owner-body/owner-body.component';
import { OwnerMainComponent } from '../Owners/Components/owner-main/owner-main.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: "owners", component: OwnerMainComponent },
  { path: "not-found", component: NotFoundComponent },
  { path: "server-error", component: ServerErrorComponent},
  { path: "", component: ClientMainComponent },
  { path: "**", component: NotFoundComponent, pathMatch: 'prefix' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
