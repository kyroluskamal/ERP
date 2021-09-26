import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from '../CommonComponents/not-found/not-found.component';
import { ServerErrorComponent } from '../CommonComponents/server-error/server-error.component';


const routes: Routes = [
  { path: "not-found", component: NotFoundComponent },
  { path: "server-error", component: ServerErrorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes/*, { enableTracing: true }*/)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
