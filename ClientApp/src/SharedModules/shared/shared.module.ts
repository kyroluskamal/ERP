import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

const SharedModules = [
  ReactiveFormsModule,
  HttpClientModule,
  CommonModule, TranslateModule
];

@NgModule({
  declarations:[],
  imports: [SharedModules],
  exports: [SharedModules]
})
export class SharedModule { }
